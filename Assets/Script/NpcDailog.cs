using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcDailog : MonoBehaviour
{
    public GameObject dialogBox;

    public float displaytimer = 4.0f;
    private float timerdisplayer;
    public Text textEditor;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        timerdisplayer = displaytimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerdisplayer >= 0)
        {
            timerdisplayer -= Time.deltaTime;//计时器 timer
        }
        
        if (timerdisplayer <= 0)
        {
            dialogBox.SetActive(false);
        }
    }

    public void DisplayDialog()
    {
        
        dialogBox.SetActive(true);
        timerdisplayer = displaytimer;
        if (!Cpu.instance.hasTask)
        {
            Cpu.instance.hasTask = true;
        }
        if (Cpu.instance.hasConpleteTask)
        {
            textEditor.text = "恭喜你完成任务";
        }


    }
}
