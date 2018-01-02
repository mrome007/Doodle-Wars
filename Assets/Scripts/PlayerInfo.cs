using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour 
{
    public static PlayerInfo Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (PlayerInfo)FindObjectOfType(typeof(PlayerInfo));
            }
            return instance;
        }
    }

    private static PlayerInfo instance = null;
}
