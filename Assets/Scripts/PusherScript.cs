using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherScript : EnemyScript
{
    [SerializeField]
    private float speed = 2.5f;

    private void Update()
    {
        PushTowardsPlayer(speed);
    }
}
