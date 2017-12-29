using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyedEventArgs : EventArgs
{
    public int EnemyIndex { get; private set; }

    public EnemyDestroyedEventArgs(int index)
    {
        EnemyIndex = index;
    }
}
