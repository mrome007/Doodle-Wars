using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour 
{
    [SerializeField]
    private List<LevelWave> levelWaves;

    [SerializeField]
    private Transform leftWorldConstraint;

    [SerializeField]
    private Transform rightWorldConstraint;

    [SerializeField]
    private GoIndicator indicator;

    private int currentWave = 0;
    private Coroutine moveleftConstraintCoroutine = null;
    private Vector3 currentLeftConstraint;

    private void Start()
    {
        currentLeftConstraint = Vector3.zero;
        StartCurrentWave();
    }

    private void HandleWaveBegin(object sender, EventArgs e)
    {
        levelWaves[currentWave].WaveBegin -= HandleWaveBegin;
    }

    private void HandleWaveEnd(object sender, EventArgs e)
    {
        levelWaves[currentWave].WaveEnd -= HandleWaveEnd;
        currentWave++;

        if(currentWave >= levelWaves.Count)
        {
            Debug.Log("Waves HAVE ENDED");
            return;
        }

        rightWorldConstraint.position = levelWaves[currentWave].RightBorder.position;
        currentLeftConstraint = levelWaves[currentWave].LeftBorder.position;
        MoveLeftConstraint();
    }

    private void StartCurrentWave()
    {
        levelWaves[currentWave].WaveBegin += HandleWaveBegin;
        levelWaves[currentWave].WaveEnd += HandleWaveEnd;
        levelWaves[currentWave].StartWave();
    }

    private void OnDestroy()
    {
        if(moveleftConstraintCoroutine != null)
        {
            StopCoroutine(moveleftConstraintCoroutine);
        }

        for(int index = 0; index < levelWaves.Count; index++)
        {
            levelWaves[index].WaveBegin -= HandleWaveBegin;
            levelWaves[index].WaveEnd -= HandleWaveEnd;
        }
    }

    private IEnumerator MoveLeftConstraintRoutine()
    {
        indicator.ShowIndicator(true);
        while(PlayerInfo.Instance.transform.position.x < currentLeftConstraint.x)
        {
            yield return null;
        }
        indicator.ShowIndicator(false);
        leftWorldConstraint.position = currentLeftConstraint;

        StartCurrentWave();
    }

    private void MoveLeftConstraint()
    {
        if(moveleftConstraintCoroutine != null)
        {
            StopCoroutine(moveleftConstraintCoroutine);
        }

        moveleftConstraintCoroutine = StartCoroutine(MoveLeftConstraintRoutine());
    }
}
