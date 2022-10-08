using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : BotBackManager
{
    public Sprite[] sprite;
    public Vector3 position;

    private void Start() {
        this.position = this.transform.position;
    }
    private void LateUpdate() {
        this.transform.eulerAngles = this.cam.transform.eulerAngles;
    }

    public virtual void GoUp(Vector3 pos) {
        
    }
    public virtual void GoLeft(Vector3 pos) {

    }
    public virtual void GoRight(Vector3 pos) {

    }
    public virtual void GoDown(Vector3 pos) {

    }
}
