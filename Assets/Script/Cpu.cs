using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����Ƿ�������ͼͨ�ŵĴ���
/// <summary>
/// ���ߵ�����
/// ���ڷ������ͻ���֮�������ͬ��
/// </summary>
public class Cpu : MonoBehaviour
{
    /// <summary>
    /// ��ǰ��ɫ�Ǳ���������
    /// </summary>
    public bool hasTask = false;//�����Ϸ��һ���������ԾͲ�д������
    /// <summary>
    /// �����Ƿ����
    /// </summary>
    public bool hasConpleteTask = false;
    private int botsSuccess = 0;
     
    //
    public static Cpu instance {
        get;
        private set;
    }
   
    //////////////////////////////////��������
    ///

    ///
    public void TaskSuccess()
    {
        botsSuccess++;
        //int a;//��������npc
        if (botsSuccess >= 2)//Ϊ�˱�������Ǳ��յ������
        {
            hasConpleteTask = true;//������Ϸ
        }
    }
}
