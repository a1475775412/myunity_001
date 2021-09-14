using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();//获取
        if (rigidbody2d != null)//
        {//失败时不启用
            rigidbody2d_fu();//启动方法初始化操作
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

    void rigidbody2d_fu()//初始化
    {

    }

    public void Launch(Vector2 direction, float force)//发射子弹
    {
        rigidbody2d.AddForce(direction * force);//
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("子弹击中物体" + collision.gameObject);//输出碰撞
        EnemyRebot enemyRebot = collision.gameObject.GetComponent<EnemyRebot>();
        if (enemyRebot != null)//是不是机器人
        {
            enemyRebot.fix();
        }
        Destroy(gameObject);//删除自身

    }
}
