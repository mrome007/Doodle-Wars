using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
    [SerializeField]
    private PlayerSword heavySword;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            if(!heavySword.IsSwinging)
            {
                heavySword.SwingSword();
            }
        }
    }

    public void SetHeavySwordIsSwinging(int swing)
    {
        heavySword.SetIsSwordSwinging(swing == 1);
    }

    public void EnableHeavySwordCollider(int enable)
    {
        heavySword.EnableSwordCollider(enable == 1);
    }
}
