using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopB : MonoBehaviour
{
    private MineField mf;
    void Start()
    {
        this.mf = GameObject.FindGameObjectWithTag("MF").GetComponent<MineField>();
        
    }
    
    void FixedUpdate()
    {
        this.transform.position = new Vector2(0, ((this.mf.yAll+1f)/2f+20f));

        RectTransform rectT = (RectTransform)this.transform;
        rectT.sizeDelta = new Vector2((this.mf.xAll)*30, 50);
    }
}
