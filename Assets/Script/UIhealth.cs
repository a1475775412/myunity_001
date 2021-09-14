using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIhealth : MonoBehaviour
{

    public Image mask;
    float originsize;
    public static UIhealth intstance { get; private set; }

    void Awake()
    {
        intstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        originsize = mask.rectTransform.rect.width;//获取宽度
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 血条UI显示
    /// </summary>
    /// <param name="fillPercent">血量百分比</param>
    public void SetValue(float fillPercent)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originsize * fillPercent);
    }
}
