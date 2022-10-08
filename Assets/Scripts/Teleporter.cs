using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Vector3 destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            StartCoroutine(other.GetComponent<CharacterMovement>().PauseMovementTemporarily());
            /// If we try to change position without pausing movement, it won't work
            other.transform.position = transform.TransformPoint(destination);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Allows us to visualize where the patrolling points are
        Gizmos.color = Color.magenta;

        Gizmos.DrawCube(transform.TransformPoint(destination), new Vector3(.1f, 1f, .1f));
    }
}
