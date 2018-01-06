using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleCollision : MonoBehaviour 
{
    [SerializeField]
    private OctoBubbleBoss boss;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        boss.OnTriggerEnter2D(other);
    }
}
