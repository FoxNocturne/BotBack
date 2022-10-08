using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class FollowPlayerAI : EnemyAI
{
    GameObject _playerGameObject;

    private void Start()
    { 
        StartCoroutine(FollowPlayer());
    }

    private IEnumerator FollowPlayer()
    {
        while (Vector3.Distance(transform.position, PlayerPosition()) > 0.1f) {
            var movement = (PlayerPosition() - transform.position).normalized;
            _movementVector = new Vector2(movement.x, movement.z); // This line moves the enemy!
            yield return null;
        }
    }

    private Vector3 PlayerPosition()
    {
        if (_playerGameObject != null) return _playerGameObject.transform.position;

        var player = GameObject.FindWithTag("Player");
        if (player == null) return transform.position;
        _playerGameObject = player.gameObject;
        return _playerGameObject.transform.position;
    }

    protected override void Update() 
    {
        base.Update();
    }

}

