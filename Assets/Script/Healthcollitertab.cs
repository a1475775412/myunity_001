using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthcollitertab : MonoBehaviour
{

    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        RubyController rubyController = collision.GetComponent<RubyController>();
        if (rubyController == null)
        {
            return;
        }
        if (rubyController.maxHealth <= rubyController.health)//如果大于就说明有问题了
        {
            Debug.Log("满血无法继续添加");
            return;
        }
        Debug.Log(collision);
        rubyController.ChangeHealth(1);//加血
        Debug.Log("加血"+ rubyController.health);
        Instantiate(particleSystem, transform.position, Quaternion.identity);//生成粒子特效
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        
    }
}
