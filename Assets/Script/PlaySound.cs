using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    /// <summary>
    /// ����
    /// </summary>
    public AudioClip audio001;
    /// <summary>
    /// ������Ч
    /// </summary>
    public AudioClip audioLaunch;

    /// <summary>
    /// �ܵ��˺���Ч
    /// </summary>
    public AudioClip audioHit;
    /// <summary>
    /// ��Ѫ��Ч
    /// </summary>
    public AudioClip audioaddBlood;

    public AudioSource audioSource;
    // Start is called before the first frame update
    ///public static PlaySound intstance { get;private set;}//ʵ����

    
    void Awake()//��ʼ������
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
    /// ������Ч
    /// </summary>
    /// <param name="audioClip">����������Դ</param>
    public void setSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
