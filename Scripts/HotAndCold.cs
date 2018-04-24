using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAndCold : MonoBehaviour {

    public static HotAndCold instance;
    public enum Temperature { hot, cold };
    Temperature CurrentTemperature = Temperature.hot;

    private void Awake()
    {
        //assign the class to the static variable on Awake
        instance = this;
    }


    private void Update()
    {
        //If player presses T they will swap between being hot and cold
        if (Input.GetKeyDown(KeyCode.T) && CurrentTemperature == Temperature.hot)
        {
            CurrentTemperature = Temperature.cold;
            Debug.Log("Changed temperature");

        }
        else if (Input.GetKeyDown(KeyCode.T) && CurrentTemperature == Temperature.cold)
        {
            CurrentTemperature = Temperature.hot;
            Debug.Log("Changed temperature");

        }
    }

    public bool IsWarm()
    {
        if (CurrentTemperature == Temperature.hot)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void TurnCold()
    {
        CurrentTemperature = Temperature.cold;
    }
}



