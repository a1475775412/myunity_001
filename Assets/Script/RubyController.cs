using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��С�ֵ�������Ϸ������
/// 2021 0509
/// </summary>

public class RubyController : MonoBehaviour
{
    //Ѫ������
    public int maxHealth = 5;//�������
    private int currentHealth;//��ǰ����


    private Rigidbody2D rigidbody2D;
    private Vector2 tran;
    /// <summary>
    /// �ƶ��ٶ�
    /// </summary>
    public float speed = 3;
    /// <summary>
    /// ��·��Ч
    /// </summary>
    public AudioClip walksound;

    //����
    public float timeInvincible = 2.0f;//�޵�ʱ�䳣��

    private Vector2 LookDirection = new Vector2(0,1);//����
    private Animator animator;
    /// <summary>
    /// �ӵ�Ԥ����
    /// </summary>
    public GameObject projectilePrefab;

    /// <summary>
    /// ��·��Ч
    /// </summary>
    public AudioSource walkplay;

    

    private PlaySound playSound;//��ȡ������Ч

    // Start is called before the first frame update
    void Start()//��ʼ��
    {
        Application.targetFrameRate = 100;//֡������
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;//��ʼ��Ѫ��
        animator = GetComponent<Animator>();//��ȡ����������
        if (animator == null)
        {
            Debug.LogError("��ȡ����������ʧ�� ");
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
        ///��ť��� H
        
        ///��ť��� T
        ///
        if (Input.GetKeyDown(KeyCode.T))
        {
            dialogue();
        }
        
    }

    /// <summary>
    /// ������ ����ƶ�
    /// </summary>
    /// <returns></returns>
    private void move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(x, y);

        if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(move.y, 0))//����������
        {
            LookDirection.Set(move.x, move.y);//LookDirection = move; ��Ч
            LookDirection.Normalize();//��λ������
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
        animator.SetFloat("Look Y",LookDirection.y);//���yλ��
        animator.SetFloat("Speed", move.magnitude);//���ģ��

        Vector2 position = transform.position;
        position = position + speed * Time.deltaTime * move;
        //�ƶ�
        rigidbody2D.MovePosition(position);
    }

    /// <summary>
    /// �Ӽ�Ѫ ��Ҫint
    /// </summary>
    /// <param name="amount">Ѫ����������</param>
   public void ChangeHealth(int amount)
   {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);//ti����
        if (amount < 0) {
            animator.SetTrigger("Hit");
            playSound.setSound(playSound.audioHit);//�ܵ��˺�
        }
        if (amount > 0)
        {
            playSound.setSound(playSound.audioaddBlood);
        }

        if (currentHealth <= 0) 
        {
            Destroy(gameObject);//game over;
            Debug.Log("��Ϸ����");
        }

        //Ѫ������
        float healthbar = (float)currentHealth / (float)maxHealth;
        Debug.Log(healthbar);
        UIhealth.intstance.SetValue(healthbar);//����ui
   }

    /// <summary>
    /// ���ڵ�Ѫ��
    /// </summary>
    /// <returns></returns>
   public int health {
        get
        {
            return currentHealth;
        }
    }
    /// <summary>
    /// �����ӵ�
    /// </summary>
    private void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab,rigidbody2D.position,Quaternion.identity);//�����ӵ�
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(LookDirection, 300f);
        animator.SetTrigger("Launch");//���Ŷ���
        playSound.setSound(playSound.audioLaunch);//������Ч
    }
    /// <summary>
    /// �Ի�ϵͳ
    /// </summary>
    private void dialogue()
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position+Vector2.up*0.2f, LookDirection, 1.5f, LayerMask.GetMask("NPC"));//�������߼��
        if (hit != null)
        {
            Debug.Log("��ײ����" + hit);
            NpcDailog npcDailog = hit.collider.GetComponent<NpcDailog>();//��ȡ��npc ��ui����
            if (npcDailog != null)
            {
                Debug.Log("npcDailog�����Ѿ�����");
                npcDailog.DisplayDialog();//��ʾui
            }
        }
    }
}
