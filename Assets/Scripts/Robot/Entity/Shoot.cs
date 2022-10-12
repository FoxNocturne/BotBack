using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Robot
{
    [Header("Robot Shoot Specifics")]
    public Transform pointShoot;
    public LineRenderer lineRenderer;
    private Vector3 _directionLaser = Vector3.forward;
    private bool _shootLaser = false;

    private void Update()
    {
        this.Move();
        if (this._shootLaser) {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, this._directionLaser, out hit, 100)) {
                this.pointShoot.position = hit.point;
            } else {
                this.pointShoot.position = this.transform.position + (this._directionLaser * 100);
            }
            this.lineRenderer.SetPosition(0, this.transform.position);
            this.lineRenderer.SetPosition(1, this.pointShoot.position);
        }
        this.pointShoot.gameObject.SetActive(this._shootLaser);
        this.lineRenderer.enabled = this._shootLaser;
    }

    public override void Stop()
    {
        base.Stop();
        this._shootLaser = false;
    }

    public override void Action() {
        this._shootLaser = true;
        this.currentStatus = Stat.none;
    }

    protected override bool CanGoOnTile(TileObject tile)
    {
        return tile.isWalkable;
    }
}
