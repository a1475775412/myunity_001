using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRebot : MonoBehaviour
{
    public bool isYZ;//开始垂直
    /// <summary>
    /// 速度
    /// </summary>
    public float speed = 3.0f;

    /// <summary>
    /// 伤害
    /// </summary>
    public int health = 1;
    public AudioClip reperasuccess;//背景音乐

    public AudioClip[] audioHit;
   
    private Rigidbody2D rigidbody2d;

   
    /// <summary>
    /// 转向时间
    /// </summary>
    public float time = 2.0f;//转向时间
    /// <summary>
    /// 粒子系统
    /// </summary>
    public ParticleSystem smokEffect;

    public AudioClip[] audioClipHit;

    private float timeer;

    private bool istime;

    private int rotation = 1;

    private Animator animator;

    //是否损坏
    private bool broken = true;

    private AudioSource audioSource;//获取到组件
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();//获取刚体类
        timeer = time;//初始化
        health = -health;
        animator = GetComponent<Animator>();
        if (animator == null) {
            animator.SetFloat("MoveX", rotation);
        }
        animator.SetFloat("MoveY", 0.0f);//初始化
        animator.SetFloat("MoveX", 0.0f);//初始化
        animator.SetBool("fix", broken);//播放修好动画
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            
            return;
        }
        timeer -= Time.deltaTime;
        if (timeer <= 0)
        {
            rotation = -rotation;//切换方向
           
            timeer = time;
        }
        
        Vector2 position = rigidbody2d.transform.position;


        if (isYZ)
        {//垂直
            animator.SetFloat("MoveY", rotation);//是否垂直
            animator.SetFloat("MoveX", 0.0f);//是否垂直
            position.y += speed * Time.deltaTime * rotation;
        }
        else
        {//平行
            animator.SetFloat("MoveX", rotation);//是否垂直
            animator.SetFloat("MoveY", 0.0f);//是否垂直
            position.x += speed * Time.deltaTime * rotation;//垂直
        }
        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        //转换到
        RubyController rubyController = collision.gameObject.GetComponent<RubyController>();//获取组件
        if (rubyController != null)//判断是不是能获取到
        {
            rubyController.ChangeHealth(health);
        }

        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        ///受到伤害
        if (projectile != null)//转换成功
        {
            int randomHit = Random.Range(0, 2);//随机播放
            Audio_play(audioClipHit[randomHit]);//播放攻击声音
            Invoke("success",0.1F);
        }
    }
    /// <summary>
    /// 完成修复
    /// </summary>
    public void fix()//
    {
        smokEffect.Stop();
        broken = false;
        animator.SetFloat("MoveX", 0.0f);//是否垂直
        animator.SetFloat("MoveY", 0.0f);//是否垂直
        rigidbody2d.simulated = false;
        animator.SetBool("fix", broken);//播放修好动画

        Cpu.instance.TaskSuccess();//修好动作游戏主要线程发送操作
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="audioClip">音频资源</param>
    void Audio_play(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);//播放音效
    }

    void success()
    {
        audioSource.PlayOneShot(reperasuccess);
    }
}
