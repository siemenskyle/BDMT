using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeUpdate : MonoBehaviour {
    GameObject timer;
    public float deltaTime;

    //how long a match should go
    public float matchLength;

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
        timer.GetComponent<Text>().text = (matchLength - (Time.realtimeSinceStartup - deltaTime)).ToString("F1");

        if((matchLength - (Time.realtimeSinceStartup - deltaTime)) <= 0){
            if (ScoreCounter.leftScore > ScoreCounter.rightScore)
            {
                Application.LoadLevel(4);
            }
            //if player 2 won, load player 2 win screen
			else if(ScoreCounter.leftScore < ScoreCounter.rightScore)
            {
                Application.LoadLevel(5);
            }
			else
			{
				Application.LoadLevel(6);
			}
        }
    }
}
