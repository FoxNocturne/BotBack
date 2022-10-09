using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausticsAnimation : MonoBehaviour
{
    [SerializeField]
    float wavesSpeed;

    private float distance = 0.3f;
    private Light _light;
    private Vector3 target;


    void Start()
    {
        target = transform.position;
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target) <= distance)
        {
            SetTarget();
        }

        transform.position = Vector3.Slerp(transform.position, target, Time.deltaTime * wavesSpeed);
    }

    private void SetTarget()
    {
        target = transform.position;
        var x = UnityEngine.Random.Range(target.x -1, target.x + 1);
        var z = UnityEngine.Random.Range(target.z -1, target.z + 1);
        target.x = x;
        target.z = z;
    }
}
