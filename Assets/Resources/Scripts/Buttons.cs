using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Sprite happy;
    public Sprite neutral;
    public Sprite sad;

    public Button resetBut;

    public void SetHappy()
    {
        this.resetBut.image.sprite = this.happy;
    }
    public void SetSad()
    {
        this.resetBut.image.sprite = this.sad;
    }
    public void SetNeutral()
    {
        this.resetBut.image.sprite = this.neutral;
    }
}
