using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinesLeft : MonoBehaviour
{
    private MineField MF;
    public Text minesLeftText;
    void Start()
    {
        this.MF = GameObject.FindGameObjectWithTag("MF").GetComponent<MineField>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.minesLeftText.text = this.MF.minesLeft.ToString();
    }
}
