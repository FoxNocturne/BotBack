using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class PatrolAI : EnemyAI
{
    [SerializeField]
    List<Vector3> patrollingPositions;

    [SerializeField]
    float goalDistance = 0.1f;

    int currentTargetIndex;
    Vector3 target;

    private void Start()
    {
        currentTargetIndex = 0;
        target = patrollingPositions[currentTargetIndex];

        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while(Vector3.Distance(transform.position, target) > goalDistance) {
            var movement = (target - transform.position).normalized;
            _movementVector = new Vector2(movement.x, movement.z); // This line moves the enemy!
            yield return null;
        }

        currentTargetIndex++;
        if(currentTargetIndex >= patrollingPositions.Count)
        {
            currentTargetIndex = 0;
        }
        target = patrollingPositions[currentTargetIndex];
        
        StartCoroutine(Patrol());
    }

    protected override void Update() 
    {
        base.Update();
    }

    void OnDrawGizmosSelected()
    {
        // Allows us to visualize where the patrolling points are
        Gizmos.color = Color.yellow;
        foreach(var point in patrollingPositions)
        {
            Gizmos.DrawCube(point, new Vector3(.1f, .6f, .1f));
        }
    }
}

