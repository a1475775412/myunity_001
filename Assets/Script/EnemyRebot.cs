using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRebot : MonoBehaviour
{
    public bool isYZ;//��ʼ��ֱ
    /// <summary>
    /// �ٶ�
    /// </summary>
    public float speed = 3.0f;

    /// <summary>
    /// �˺�
    /// </summary>
    public int health = 1;
    public AudioClip reperasuccess;//��������

    public AudioClip[] audioHit;
   
    private Rigidbody2D rigidbody2d;

   
    /// <summary>
    /// ת��ʱ��
    /// </summary>
    public float time = 2.0f;//ת��ʱ��
    /// <summary>
    /// ����ϵͳ
    /// </summary>
    public ParticleSystem smokEffect;

    public AudioClip[] audioClipHit;

    private float timeer;

    private bool istime;

    private int rotation = 1;

    private Animator animator;

    //�Ƿ���
    private bool broken = true;

    private AudioSource audioSource;//��ȡ�����
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();//��ȡ������
        timeer = time;//��ʼ��
        health = -health;
        animator = GetComponent<Animator>();
        if (animator == null) {
            animator.SetFloat("MoveX", rotation);
        }
        animator.SetFloat("MoveY", 0.0f);//��ʼ��
        animator.SetFloat("MoveX", 0.0f);//��ʼ��
        animator.SetBool("fix", broken);//�����޺ö���
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
            rotation = -rotation;//�л�����
           
            timeer = time;
        }
        
        Vector2 position = rigidbody2d.transform.position;


        if (isYZ)
        {//��ֱ
            animator.SetFloat("MoveY", rotation);//�Ƿ�ֱ
            animator.SetFloat("MoveX", 0.0f);//�Ƿ�ֱ
            position.y += speed * Time.deltaTime * rotation;
        }
        else
        {//ƽ��
            animator.SetFloat("MoveX", rotation);//�Ƿ�ֱ
            animator.SetFloat("MoveY", 0.0f);//�Ƿ�ֱ
            position.x += speed * Time.deltaTime * rotation;//��ֱ
        }
        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        //ת����
        RubyController rubyController = collision.gameObject.GetComponent<RubyController>();//��ȡ���
        if (rubyController != null)//�ж��ǲ����ܻ�ȡ��
        {
            rubyController.ChangeHealth(health);
        }

        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        ///�ܵ��˺�
        if (projectile != null)//ת���ɹ�
        {
            int randomHit = Random.Range(0, 2);//�������
            Audio_play(audioClipHit[randomHit]);//���Ź�������
            Invoke("success",0.1F);
        }
    }
    /// <summary>
    /// ����޸�
    /// </summary>
    public void fix()//
    {
        smokEffect.Stop();
        broken = false;
        animator.SetFloat("MoveX", 0.0f);//�Ƿ�ֱ
        animator.SetFloat("MoveY", 0.0f);//�Ƿ�ֱ
        rigidbody2d.simulated = false;
        animator.SetBool("fix", broken);//�����޺ö���

        Cpu.instance.TaskSuccess();//�޺ö�����Ϸ��Ҫ�̷߳��Ͳ���
    }
    /// <summary>
    /// ������Ч
    /// </summary>
    /// <param name="audioClip">��Ƶ��Դ</param>
    void Audio_play(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);//������Ч
    }

    void success()
    {
        audioSource.PlayOneShot(reperasuccess);
    }
}
