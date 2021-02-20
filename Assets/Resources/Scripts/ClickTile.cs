using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClickTile : MonoBehaviour
{
    private MineField mf;
    private SpriteController sc;
    private Tile tile;
    
    void Start()
    {
        this.mf = GameObject.FindGameObjectWithTag("MF").GetComponent<MineField>();
        this.sc = this.GetComponent<SpriteController>();
        this.tile = this.GetComponent<Tile>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (this.tile.isSecured)
            {
                this.sc.DefaultSprite();
                this.tile.isSecured = false;
                this.mf.minesLeft++;
                
            }
            else
            {
                this.sc.SecuredSprite();
                this.tile.isSecured = true;
                this.mf.minesLeft--;
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        this.TileClick();
    }

    void TileClick()
    {
        if (!this.mf.gameStarted)
        {
            this.mf.gameStarted = true;
            this.Mines();
            this.mf.timer.TimerStart();
        }

        if (this.tile.isMine)
        {
            this.mf.GameLost();
            
        }
        else
        {
            this.TileReveal();
            if (this.mf.isWon())
            {
                this.mf.GameWon();
            }
        }
    }

    void Mines()
    {
        
        int minesLeft = this.mf.mines;
        int tileLeft = this.mf.tilesUnrevealed;

        for (int x = 0; x < this.mf.xAll; x++)
        {
            for (int y = 0; y < this.mf.yAll; y++)
            {
                if (!(x == this.tile.x && y == this.tile.y))
                {
                    Tile aTile = this.mf.tiles[x, y];
                    float chanceOfMine = (float)minesLeft / (float)tileLeft;
                    if (Random.value <= chanceOfMine)
                    {
                        aTile.isMine = true;
                        minesLeft--;
                    }
                }

                tileLeft--; 
            }
        }
    }

    public void TileReveal()
    {
        if (!this.tile.isRevealed && !this.tile.isMine)
        {
            this.tile.isRevealed = true;
            this.mf.tilesUnrevealed--;
            int minesNearby = this.GetMineAmount();
            this.sc.EmptySprite(minesNearby);

            if (minesNearby == 0)
            {
                this.RevealIfValid(this.tile.x-1, this.tile.y-1);
                this.RevealIfValid(this.tile.x-1, this.tile.y);
                this.RevealIfValid(this.tile.x-1, this.tile.y+1);
                this.RevealIfValid(this.tile.x, this.tile.y-1);
                this.RevealIfValid(this.tile.x, this.tile.y+1);
                this.RevealIfValid(this.tile.x+1, this.tile.y-1);
                this.RevealIfValid(this.tile.x+1, this.tile.y);
                this.RevealIfValid(this.tile.x+1, this.tile.y+1);
            }
        }
    }

    void RevealIfValid(int x, int y)
    {
        if (x >= 0 && x < this.mf.xAll && y >= 0 && y < this.mf.yAll)
        {
            this.mf.tiles[x, y].click.TileReveal();
        }
    }

    public int GetMineAmount()
    {
        int counter = 0;
        if (this.hasMine(this.tile.x - 1, this.tile.y - 1))
            counter++;
        if (this.hasMine(this.tile.x - 1, this.tile.y ))
            counter++;
        if (this.hasMine(this.tile.x - 1, this.tile.y + 1))
            counter++;
        if (this.hasMine(this.tile.x , this.tile.y - 1))
            counter++;
        if (this.hasMine(this.tile.x , this.tile.y + 1))
            counter++;
        if (this.hasMine(this.tile.x + 1, this.tile.y - 1))
            counter++;
        if (this.hasMine(this.tile.x + 1, this.tile.y))
            counter++;
        if (this.hasMine(this.tile.x + 1, this.tile.y + 1))
            counter++;
        
        return counter;
    }

    bool hasMine(int x, int y)
    {
        bool hasMine = false;
        if (x >= 0 && x < this.mf.xAll&&y>=0&&y<this.mf.yAll)
        {
                hasMine = this.mf.tiles[x, y].isMine;
            
        }
        return hasMine;
    }
}
