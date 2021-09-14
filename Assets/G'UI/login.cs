using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class login : MonoBehaviour
{
    private float time = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Application.LoadLevel("MainScene");
        }
    }
}
