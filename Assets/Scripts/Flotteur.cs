using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotteur : Robot
{
    public override void Action() { }

    private void Update()
    {
        if (this.isWalking == false)
        {
            switch (this.currentStatus)
            {
                case Stat.up:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x, mapcoord.y + 1)) || tilemap.checkVoid(new Vector2Int(mapcoord.x, mapcoord.y + 1)))
                    {
                        mapcoord.y += 1;
                        position = position + (Vector3.forward * this.tileSize);
                    }
                    else
                    {
                        this.currentStatus = Stat.down;
                    }
                    break;
                case Stat.down:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x, mapcoord.y - 1)) || tilemap.checkVoid(new Vector2Int(mapcoord.x, mapcoord.y - 1)))
                    {
                        mapcoord.y -= 1;
                        position = position + (Vector3.back * this.tileSize);
                    }
                    else
                    {
                        this.currentStatus = Stat.up;
                    }
                    break;
                case Stat.left:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x - 1, mapcoord.y)) || tilemap.checkVoid(new Vector2Int(mapcoord.x - 1, mapcoord.y)))
                    {
                        mapcoord.x -= 1;
                        position = position + (Vector3.left * this.tileSize);
                    }
                    else
                    {
                        this.currentStatus = Stat.right;
                    }
                    break;
                case Stat.right:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x + 1, mapcoord.y)) || tilemap.checkVoid(new Vector2Int(mapcoord.x + 1, mapcoord.y)))
                    {
                        mapcoord.x += 1;
                        position = position + (Vector3.right * this.tileSize);
                    }
                    else
                    {
                        this.currentStatus = Stat.left;
                    }
                    break;
            }
        }
        if (this.isWalking == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.position, Time.deltaTime * this.robotSpeed);
        }
        if (Vector3.Distance(this.transform.position, this.position) == 0)
        {
            this.isWalking = false;
            if (tilemap.checkKill(mapcoord) && !tilemap.checkVoid(mapcoord))
                Death();
            if (tilemap.checkWin(mapcoord))
                Goal();
        }
        else
        {
            this.isWalking = true;
        }


    }

}
