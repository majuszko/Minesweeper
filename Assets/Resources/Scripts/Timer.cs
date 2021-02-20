using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;

    private System.Diagnostics.Stopwatch _stopwatch = new System.Diagnostics.Stopwatch();

    public void TimerReset()
    {
        this._stopwatch.Reset();
    }

    public void TimerStart()
    {
        this.TimerReset();
        _stopwatch.Start();
        
    }
    public void TimerStop()
    {
        
        _stopwatch.Stop();
        
    }

    public int GetTime()
    {
        return (int) (this._stopwatch.ElapsedMilliseconds / 1000f);
    }

    private void FixedUpdate()
    {
        int time = this.GetTime();
        
        this.timer.text = time.ToString();
    }
}
