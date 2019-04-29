using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text TimerText;
    private float startTime;
    private bool finnished = false;

	// Use this for initialization
	void Start () {
        //the time since the application has started is the same as the time that the application has started
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if (finnished)
            return;
        //storing the amount of time since that timer has started in float t
        float t = Time.time - startTime;
        //diding the amount of time in t by 60
        string minutes = ((int)t / 60).ToString();
        //geting the remainder of secconds after being devided by 60
        string seconds = (t % 60).ToString("f2");
        //haveing the text in game show the minutes  and seconds
        TimerText.text = minutes + ":" + seconds;
 	}
    public void Finnish()
    {

        //when the timer is done then change the text to red
        finnished = true;
        TimerText.color = Color.red;
    }
}
