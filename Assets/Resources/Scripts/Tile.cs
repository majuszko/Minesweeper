using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x;
    public int y;
    public bool isMine = false;
    public bool isRevealed = false;
    public bool isSecured = false;

    public ClickTile click;

    void Start()
    {
        this.click = this.GetComponent<ClickTile>();
    }
    
    public static Tile NewTile(int x, int y)
    {
        GameObject tile = (GameObject)Instantiate(Resources.Load("Prefabs/Tile"));
        GameObject tiles = GameObject.FindGameObjectWithTag("Tiles");

        MineField mf = GameObject.FindGameObjectWithTag("MF").GetComponent<MineField>();
        
        tile.GetComponent<Tile>().x = x;
        tile.GetComponent<Tile>().y = y;

        tile.transform.parent = tiles.transform;


        tile.transform.position =
            new Vector2((float) x*1.49f - ((float) mf.xAll + 1f) / 1.5f, (float) y*1.49f - ((float) mf.yAll + 1f) / 1.5f);
        
        return tile.GetComponent<Tile>();
    }
    
}
