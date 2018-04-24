using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    private float StartTime;//tracks current time
    private float CurrentTime;
    public TextMeshProUGUI TimerText;
	// Use this for initialization
	void Start () {
        StartTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        //current time in the level
        CurrentTime = Time.time - StartTime;
        //gets the current amount of mins
        string Minutes = ((int)CurrentTime / 60).ToString();
        string Seconds = ((int)CurrentTime % 60).ToString();
        TimerText.text = Minutes + ":" + Seconds;
	}
}
