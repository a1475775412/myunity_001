using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();//��ȡ
        if (rigidbody2d != null)//
        {//ʧ��ʱ������
            rigidbody2d_fu();//����������ʼ������
        }

        

    }



    // Update is called once per frame

    void Update()
    {
        if (transform.position.magnitude > 100)
        {
            Destroy(gameObject);
        }
    }

    void rigidbody2d_fu()//��ʼ��
    {

    }

    public void Launch(Vector2 direction, float force)//�����ӵ�
    {
        rigidbody2d.AddForce(direction * force);//
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�ӵ���������" + collision.gameObject);//�����ײ
        EnemyRebot enemyRebot = collision.gameObject.GetComponent<EnemyRebot>();
        if (enemyRebot != null)//�ǲ��ǻ�����
        {
            enemyRebot.fix();
        }
        Destroy(gameObject);//ɾ������

    }
}
