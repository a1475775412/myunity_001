using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    /// <summary>
    /// 背景
    /// </summary>
    public AudioClip audio001;
    /// <summary>
    /// 发射音效
    /// </summary>
    public AudioClip audioLaunch;

    /// <summary>
    /// 受到伤害音效
    /// </summary>
    public AudioClip audioHit;
    /// <summary>
    /// 加血音效
    /// </summary>
    public AudioClip audioaddBlood;

    public AudioSource audioSource;
    // Start is called before the first frame update
    ///public static PlaySound intstance { get;private set;}//实例化

    
    void Awake()//初始化操作
    {

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="audioClip">传入音乐资源</param>
    public void setSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
