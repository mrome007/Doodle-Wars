using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public int EnemyIndex;

    public event EventHandler<EnemyDestroyedEventArgs> EnemyDestroyed;

    private void OnDestroy()
    {
        var handler = EnemyDestroyed;
        if(handler != null)
        {
            handler(this, new EnemyDestroyedEventArgs(EnemyIndex));
        }
    }
}
