using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesLoad : MonoBehaviour
{

    private ScenesLoad scenesLoad;
    /// <summary>
    /// 关卡加载系统
    /// </summary>
    


    // Start is called before the first frame update
    void Start()
    {
        Application.LoadLevel("MainScene");//加载地图
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
