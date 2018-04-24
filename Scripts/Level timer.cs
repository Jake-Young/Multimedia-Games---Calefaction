using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour {
    private float ElapsedTime;
    private float BestTime;
    private bool TimerOn = false;

	// Use this for initialization
	void Start () {
        StartTimer();
	}

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    void TriggerWinOnLevelComplete()
    {
        StopTimer();
    }

    // Update is called once per frame
    void Update () {
		if (TimerOn)
        {
            Timer();
        }
	}

    public void StartTimer()
    {
        TimerOn = true;
    }

    public void StopTimer()
    {
        TimerOn = false;
    }

    private void Timer()
    {
        ElapsedTime += Time.deltaTime;
       // ScoreKeeper.instance.SetLevelTime(ElapsedTime);

        if (ElapsedTime < BestTime)
        {
            BestTime += Time.deltaTime;
            // ScoreKeeper.instance.SetBestTime(BestTime);
        }
    }
}
