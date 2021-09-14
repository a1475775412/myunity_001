using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 寒小林的面向游戏对象编程
/// 2021 0509
/// </summary>

public class RubyController : MonoBehaviour
{
    //血量属性
    public int maxHealth = 5;//最大生命
    private int currentHealth;//当前生命


    private Rigidbody2D rigidbody2D;
    private Vector2 tran;
    /// <summary>
    /// 移动速度
    /// </summary>
    public float speed = 3;
    /// <summary>
    /// 走路音效
    /// </summary>
    public AudioClip walksound;

    //属性
    public float timeInvincible = 2.0f;//无敌时间常量

    private Vector2 LookDirection = new Vector2(0,1);//看向
    private Animator animator;
    /// <summary>
    /// 子弹预制体
    /// </summary>
    public GameObject projectilePrefab;

    /// <summary>
    /// 走路音效
    /// </summary>
    public AudioSource walkplay;

    

    private PlaySound playSound;//获取播放音效

    // Start is called before the first frame update
    void Start()//初始化
    {
        Application.targetFrameRate = 100;//帧数限制
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;//初始化血量
        animator = GetComponent<Animator>();//获取动画控制器
        if (animator == null)
        {
            Debug.LogError("获取动画控制器失败 ");
        }

        playSound = GetComponent<PlaySound>();
        
    }

    // Update is called once per frame
    void Update()
    {
        move();


        if(Cpu.instance.hasTask)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Launch();
            }
        }
        ///按钮检测 H
        
        ///按钮检测 T
        ///
        if (Input.GetKeyDown(KeyCode.T))
        {
            dialogue();
        }
        
    }

    /// <summary>
    /// 控制器 玩家移动
    /// </summary>
    /// <returns></returns>
    private void move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(x, y);

        if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(move.y, 0))//如果输入更新
        {
            LookDirection.Set(move.x, move.y);//LookDirection = move; 等效
            LookDirection.Normalize();//单位化向量
            if (!walkplay.isPlaying)
            {
                walkplay.Play();
                walkplay.clip = walksound;
            }
        }
        else
        {
            walkplay.Stop();
        }
        animator.SetFloat("Look X",LookDirection.x);
        animator.SetFloat("Look Y",LookDirection.y);//求出y位置
        animator.SetFloat("Speed", move.magnitude);//求出模长

        Vector2 position = transform.position;
        position = position + speed * Time.deltaTime * move;
        //移动
        rigidbody2D.MovePosition(position);
    }

    /// <summary>
    /// 加减血 需要int
    /// </summary>
    /// <param name="amount">血量操作参数</param>
   public void ChangeHealth(int amount)
   {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);//ti傲视
        if (amount < 0) {
            animator.SetTrigger("Hit");
            playSound.setSound(playSound.audioHit);//受到伤害
        }
        if (amount > 0)
        {
            playSound.setSound(playSound.audioaddBlood);
        }

        if (currentHealth <= 0) 
        {
            Destroy(gameObject);//game over;
            Debug.Log("游戏结束");
        }

        //血量计算
        float healthbar = (float)currentHealth / (float)maxHealth;
        Debug.Log(healthbar);
        UIhealth.intstance.SetValue(healthbar);//更新ui
   }

    /// <summary>
    /// 现在的血量
    /// </summary>
    /// <returns></returns>
   public int health {
        get
        {
            return currentHealth;
        }
    }
    /// <summary>
    /// 发射子弹
    /// </summary>
    private void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab,rigidbody2D.position,Quaternion.identity);//发射子弹
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(LookDirection, 300f);
        animator.SetTrigger("Launch");//播放动画
        playSound.setSound(playSound.audioLaunch);//发射音效
    }
    /// <summary>
    /// 对话系统
    /// </summary>
    private void dialogue()
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position+Vector2.up*0.2f, LookDirection, 1.5f, LayerMask.GetMask("NPC"));//发射射线检测
        if (hit != null)
        {
            Debug.Log("碰撞到了" + hit);
            NpcDailog npcDailog = hit.collider.GetComponent<NpcDailog>();//获取到npc 的ui界面
            if (npcDailog != null)
            {
                Debug.Log("npcDailog方法已经调用");
                npcDailog.DisplayDialog();//显示ui
            }
        }
    }
}
