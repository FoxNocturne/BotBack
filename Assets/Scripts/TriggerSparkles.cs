using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSparkles : MonoBehaviour
{
    [SerializeField]
    private GameObject sparkles;

    private void OnTriggerEnter(Collider other)
    {
        var gameObject = Instantiate(sparkles);
        gameObject.transform.position = other.transform.position;
        gameObject.GetComponent<ParticleSystem>().Play();
    }
}
