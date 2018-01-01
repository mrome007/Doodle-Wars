using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoIndicator : MonoBehaviour 
{   
    private Animator goAnimator;

    private void Awake()
    {
        goAnimator = GetComponent<Animator>();
        ShowIndicator(false);
    }

    public void ShowIndicator(bool show)
    {
        goAnimator.Play(show ? "PulseSprite" : "PulseIdle", -1, 0f);
    }
}
