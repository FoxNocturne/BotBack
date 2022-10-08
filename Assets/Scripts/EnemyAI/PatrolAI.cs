using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class PatrolAI : EnemyAI
{
    [SerializeField]
    List<Vector3> patrollingPositions;

    protected override void Update() 
    {
        ExecuteAI();
        base.Update();
    }

    private void ExecuteAI()
    {
        throw new NotImplementedException();
    }
}

