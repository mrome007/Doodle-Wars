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

    private int currentWave = 0;

    private void Start()
    {
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
        StartCurrentWave();
    }

    private void StartCurrentWave()
    {
        levelWaves[currentWave].WaveBegin += HandleWaveBegin;
        levelWaves[currentWave].WaveEnd += HandleWaveEnd;
        levelWaves[currentWave].StartWave();
    }

    private void OnDestroy()
    {
        levelWaves[currentWave].WaveBegin -= HandleWaveBegin;
        levelWaves[currentWave].WaveEnd -= HandleWaveEnd;
    }
}
