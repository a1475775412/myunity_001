using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    /// <summary>
    /// �˺���С
    /// </summary>
    public int subH = 1;
    public float timeInvincible_time = 3.0f;

    private float invincibleTime;


    private void Start()
    {
        subH = subH * -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)//����ʱ��ʼ��ϵͳ
    {
        RubyController rubyController = collision.GetComponent<RubyController>();
        invincibleTime = rubyController.timeInvincible;//��ȡ ��ʱ��ʱ
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        RubyController rubyController = collision.GetComponent<RubyController>();
        if (rubyController == null)//����֮�ڵĴ���
        {
            Debug.Log("δ��ȡ�� ");
            return;
        }
        
        
        invincibleTime -= Time.deltaTime;
        if(invincibleTime <= 0)
        {
            if (rubyController.health == 0)
            {
                Debug.Log("��ɫ�Ѿ�ûѪ��");
                return;
            }
            rubyController.ChangeHealth(subH);
            Debug.Log("��Ѫ-1"+"������"+ rubyController);
            invincibleTime = rubyController.timeInvincible;//��λ
            
        }
       
        
        //rubyController.ChangeHealth(-1);//��Ѫ
        //Debug.Log("��Ѫ�¼�" + rubyController.health);
    }

}
