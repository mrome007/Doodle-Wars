using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
    [SerializeField]
    private PlayerSword heavySword;

    [SerializeField]
    private PlayerSword lightSword;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            if(!heavySword.IsSwinging && !lightSword.IsSwinging)
            {
                heavySword.SwingSword();
            }
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            if(!lightSword.IsSwinging && !heavySword.IsSwinging)
            {
                lightSword.SwingSword();
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

    public void SetLightSwordIsSwinging(int swing)
    {
        lightSword.SetIsSwordSwinging(swing == 1);
    }

    public void EnableLightSwordCollider(int enable)
    {
        lightSword.EnableSwordCollider(enable == 1);
    }
}
