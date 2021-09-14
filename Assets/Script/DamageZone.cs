using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    /// <summary>
    /// 伤害大小
    /// </summary>
    public int subH = 1;
    public float timeInvincible_time = 3.0f;

    private float invincibleTime;


    private void Start()
    {
        subH = subH * -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)//触发时初始化系统
    {
        RubyController rubyController = collision.GetComponent<RubyController>();
        invincibleTime = rubyController.timeInvincible;//获取 计时器时
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        RubyController rubyController = collision.GetComponent<RubyController>();
        if (rubyController == null)//意料之内的错误
        {
            Debug.Log("未获取到 ");
            return;
        }
        
        
        invincibleTime -= Time.deltaTime;
        if(invincibleTime <= 0)
        {
            if (rubyController.health == 0)
            {
                Debug.Log("角色已经没血了");
                return;
            }
            rubyController.ChangeHealth(subH);
            Debug.Log("减血-1"+"对象是"+ rubyController);
            invincibleTime = rubyController.timeInvincible;//复位
            
        }
       
        
        //rubyController.ChangeHealth(-1);//减血
        //Debug.Log("减血事件" + rubyController.health);
    }

}
