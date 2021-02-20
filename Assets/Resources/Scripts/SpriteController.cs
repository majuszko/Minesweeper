using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite mineSprite;
    public Sprite securedTileSprite;
    public Sprite deadlyMineSprite;
    public Sprite securedMineSprite;
    public Sprite[] emptyTileSprites;

    // private void Start()
    // {
    //     EmptySprite(8);   
    // }

    public void EmptySprite(int minesAround)
    {
        GetComponent<SpriteRenderer>().sprite = emptyTileSprites[minesAround];
        GetComponent<BoxCollider2D>().enabled = false;

    }
    public void MineSprite()
    {
        GetComponent<SpriteRenderer>().sprite = mineSprite;
        GetComponent<BoxCollider2D>().enabled = false;

    }
    public void SecuredSprite()
    {
        GetComponent<SpriteRenderer>().sprite = securedTileSprite;
        

    }
    public void DeadlyMineSprite()
    {
        GetComponent<SpriteRenderer>().sprite = deadlyMineSprite;
        GetComponent<BoxCollider2D>().enabled = false;

    }
    public void SecuderMineSprite()
    {
        GetComponent<SpriteRenderer>().sprite = securedMineSprite;
        GetComponent<BoxCollider2D>().enabled = false;

    }
    public void DefaultSprite()
    {
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
        

    }
}
