using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
    [SerializeField]
    private PlayerSword playerSword;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            if(!playerSword.IsSwinging)
            {
                playerSword.SwingSword();
            }
        }
    }
}
