using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetCamera : MonoBehaviour
{
    private Vector2 offset;
    private Vector3 pos;
    public GameObject target;
    public float offsetspeed = 1.0f;
    
    void Update()
    {

        //offset = transform.position - target.transform.position;
        //Vector2 vector2;

        //vector2.x = target.gameObject.transform.position.x;
        //vector2.y = target.gameObject.transform.position.y;
        //Debug.Log(vector2);

        //pos.x = vector2.x + offset.x;
        //pos.y = vector2.y + offset.y;
        //pos.z = -10;
        //Debug.Log(offset);
        Vector3 vector3;//这是一个相机位置
        vector3.z = transform.position.z;
        vector3.x = target.gameObject.transform.position.x;
        vector3.y = target.gameObject.transform.position.y;
        



        transform.position = Vector3.Lerp(transform.position, vector3, offsetspeed);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
}
