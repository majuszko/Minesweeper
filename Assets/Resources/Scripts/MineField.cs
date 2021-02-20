using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineField : MonoBehaviour
{
    public int mines;
    public int tilesUnrevealed;
    public bool gameStarted = false;
    public int xAll;
    public int yAll;
    public Tile[,] tiles;

    public int minesLeft = 0;
    public Timer timer;
    public Buttons resetGame;

    public void CreateMinefield(int xAll, int yAll, int mines)
    {
        this.xAll = xAll;
        this.yAll = yAll;
        this.mines = mines;
        this.tilesUnrevealed = xAll * yAll;
        this.gameStarted = false;

        this.minesLeft = mines;
        this.timer.TimerReset();
        this.resetGame.SetNeutral();
        
        if (this.tiles != null)
        {
            foreach (Tile tile in this.tiles)
            {
                Destroy(tile.gameObject);
            }
        }

        this.tiles = new Tile[xAll, yAll];

        for (int x = 0; x < xAll; x++)
        {
            for (int y = 0; y < yAll; y++)
            {
                tiles[x, y] = Tile.NewTile(x, y);
            }
        }
    }

    public bool isWon()
    {
        if (tilesUnrevealed == this.mines)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GameLost()
    {
        Debug.Log("game lost");
        this.timer.TimerStop();
        this.resetGame.SetSad();
    }

    public void GameWon()
    {
        Debug.Log("won XDDDDD");
        
        this.timer.TimerStop();
        this.resetGame.SetHappy();
    }
}
