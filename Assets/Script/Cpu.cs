using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 这里是放所有蓝图通信的代码
/// <summary>
/// 总线调度器
/// 用于服务器客户端之间的数据同步
/// </summary>
public class Cpu : MonoBehaviour
{
    /// <summary>
    /// 当前角色是被否有任务
    /// </summary>
    public bool hasTask = false;//这个游戏就一个任务所以就不写数组了
    /// <summary>
    /// 任务是否完成
    /// </summary>
    public bool hasConpleteTask = false;
    private int botsSuccess = 0;
     
    //
    public static Cpu instance {
        get;
        private set;
    }
   
    //////////////////////////////////方法定义
    ///

    ///
    public void TaskSuccess()
    {
        botsSuccess++;
        //int a;//搜索所有npc
        if (botsSuccess >= 2)//为了避免错误还是保险点大于他
        {
            hasConpleteTask = true;//更新游戏
        }
    }
}
