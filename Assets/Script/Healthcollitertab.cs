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
        if (rubyController.maxHealth <= rubyController.health)//������ھ�˵����������
        {
            Debug.Log("��Ѫ�޷��������");
            return;
        }
        Debug.Log(collision);
        rubyController.ChangeHealth(1);//��Ѫ
        Debug.Log("��Ѫ"+ rubyController.health);
        Instantiate(particleSystem, transform.position, Quaternion.identity);//����������Ч
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        
    }
}
