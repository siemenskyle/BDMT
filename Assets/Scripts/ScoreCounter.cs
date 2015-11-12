using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    public static int leftScore;
    public static int rightScore;

    GameObject leftTimer;
    GameObject rightTimer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("grass"))
        {
			print(transform.position.x);
            if ((transform.position.x < 0 && transform.position.x >= -18) 
			    ||  transform.position.x > 18) 
					rightScore++;
            else if ((transform.position.x > 0 && transform.position.x <= 18) 
			    || transform.position.x < -18) 
					leftScore++;
          }

    }
    // Use this for initialization
    void Start () {
        leftScore = 0;
        rightScore = 0;
        leftTimer = GameObject.FindGameObjectWithTag("LeftScore");
        rightTimer = GameObject.FindGameObjectWithTag("RightScore");
        GameObject.FindGameObjectWithTag("ScoreBelt").GetComponent<TimeUpdate>().deltaTime = Time.realtimeSinceStartup;
    }
	
	// Update is called once per frame
	void Update () {

		//checks the current score of each player
		if (leftScore == 11 || rightScore == 11) {
            //game ends when score of either player is 11
            Application.LoadLevel (3);
		}
	}

    void FixedUpdate()
    {
        leftTimer.GetComponent<Text>().text = leftScore.ToString();
        rightTimer.GetComponent<Text>().text = rightScore.ToString();
    }
}
