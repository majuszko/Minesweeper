using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffBtns : MonoBehaviour
{
    private MineField mf;
    public string Difficulty = "Easy";
    
    void Start()
    {
        this.mf = GameObject.FindGameObjectWithTag("MF").GetComponent<MineField>();
        this.Easy();
    }

    public void Easy()
    {
        this.mf.CreateMinefield(10,10,10);
        this.Difficulty = "Easy";
        
    }
    public void Medium()
    {
        this.mf.CreateMinefield(20,20,60);
        this.Difficulty = "Medium";
    }
    public void Hard()
    {
        this.mf.CreateMinefield(30,20,99);
        this.Difficulty = "Hard";
    }
    public void ResetGame()
    {

        if (this.Difficulty == "Easy")
        {
            Easy();
        }
        else if (this.Difficulty == "Medium")
        {
            Medium();
        }
        else if (this.Difficulty == "Hard")
        {
            Hard();
        }
    }


}
