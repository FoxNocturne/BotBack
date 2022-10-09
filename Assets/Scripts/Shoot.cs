using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Robot
{
    public enum Stat
    {
        up,
        down,
        left,
        right,
        none
    }

    public Stat stat;
    public GameObject selectT;
    public GameObject selectF; 
    public Transform pointShoot;
    public LineRenderer lineRenderer;
    private Vector3 _directionLaser = Vector3.forward;
    private bool _shootLaser = false;
    private bool selected = false;
    private float size;
    public override void GoUp(float size)
    {
        stat = Stat.up;
        this._shootLaser = false;
        this.size = size;
        this._directionLaser = Vector3.forward;
    }
    public override void GoDown(float size)
    {
        stat = Stat.down;
        this._directionLaser = Vector3.back;
        this._shootLaser = false;
        this.size = size;
    }
    public override void GoLeft(float size)
    {
        stat = Stat.left;
        this._directionLaser = Vector3.left;
        this._shootLaser = false;
        this.size = size;
    }
    public override void GoRight(float size)
    {
        stat = Stat.right;
        this._directionLaser = Vector3.right;
        this._shootLaser = false;
        this.size = size;
    }

    public override void Action() { this._shootLaser = true;
        stat = Stat.none;
    }
    public override void Stop() {
        this._shootLaser = false;
        
    }
    public override void Select()
    {
        if ( selected )
        {
            selectF.SetActive(true);
            selectT.SetActive(false);
            selected = false;
        }
        else
        {
            selectF.SetActive(false);
            selectT.SetActive(true);
            selected = true;
        }
    }

    void Start()
    {
        position = transform.position;
    }

    private void Update()
    {
        if (this.isWalking == false)
        {
            switch (this.stat)
            {
                case Stat.up:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x, mapcoord.y - 1)))
                    {
                        mapcoord.y -= 1;
                        position = position + (Vector3.forward * size);
                    }
                    break;
                case Stat.down:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x, mapcoord.y + 1)))
                    {
                        mapcoord.y += 1;
                        position = position + (Vector3.back * size);
                    }
                    break;
                case Stat.left:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x - 1, mapcoord.y)))
                    {
                        mapcoord.x -= 1;
                        position = position + (Vector3.left * size);
                    }
                    break;
                case Stat.right:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x + 1, mapcoord.y)))
                    {
                        mapcoord.x += 1;
                        position = position + (Vector3.right * size);
                    }
                    break;
            }
        }
        if (this.isWalking == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.position, Time.deltaTime);
        }
        if (Vector3.Distance(this.transform.position, this.position) == 0)
        {
            this.isWalking = false;
        }
        else
        {
            this.isWalking = true;
        }
        if(this._shootLaser == true) {
            RaycastHit hit;
            if(Physics.Raycast(this.transform.position, this._directionLaser, out hit, 100)) {
                this.pointShoot.position = hit.point;
            }
            else {
                this.pointShoot.position = this.transform.position + (this._directionLaser * 100);
            }

            this.lineRenderer.SetPosition(0, this.transform.position);
            this.lineRenderer.SetPosition(1, this.pointShoot.position);
        }
        this.pointShoot.gameObject.SetActive(this._shootLaser);
        this.lineRenderer.enabled = this._shootLaser;
    }
}
