using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeUpdate : MonoBehaviour {
    GameObject timer;
    public float deltaTime;

	// Use this for initialization
	void Start () {
        // Get the location of the timer UI element, where time is kept on screen
        timer = GameObject.FindGameObjectWithTag("ScoreTimer");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        // Put the difference of time between current game time and the time the last round started on screen
        // with 1 decimal place
        timer.GetComponent<Text>().text = (Time.realtimeSinceStartup - deltaTime).ToString("F1");
    }
}
