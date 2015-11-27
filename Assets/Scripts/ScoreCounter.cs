using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    // Variables for the left player and right players scores
    public static int leftScore;
    public static int rightScore;

    // The object of the score on the left and right side of the timer
    GameObject leftTimer;
    GameObject rightTimer;

	public int getscore(int player){
		if(player == 1)
			return leftScore;
		if(player == 2)
			return rightScore;
		return -1;
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        // if the bird hits the grass
        if (other.name.Contains("grass"))
        {
            // This is to reset the gravity on the bird incase the special move was used that increased it's gravitational force
            GameObject.FindGameObjectWithTag("Bird").GetComponent<Rigidbody2D>().gravityScale = 0.7F;

            // If the bird lands on the left side, AND it's not out then right player gets a score
            if ((transform.position.x < 0 && transform.position.x >= -18) 
			    ||  transform.position.x > 18) 
					rightScore++;
            // If the bird lands on the right side AND it's not out, the left player gets a score
            else if ((transform.position.x > 0 && transform.position.x <= 18) 
			    || transform.position.x < -18) 
					leftScore++;
          }

    }
    // Use this for initialization
    void Start () {
        // reset the scores to 0 for both players on startup
        leftScore = 0;
        rightScore = 0;
        // get the game objects from tag, so we can update the UI layer with the scores
        leftTimer = GameObject.FindGameObjectWithTag("LeftScore");
        rightTimer = GameObject.FindGameObjectWithTag("RightScore");
        // This delta time is updated so we know when a round starts. Then the current time in round is the difference
        // between this and the time since the program started up (See TimerUpdate.cs)
        GameObject.FindGameObjectWithTag("ScoreBelt").GetComponent<TimeUpdate>().deltaTime = Time.realtimeSinceStartup;
    }
	
	// Update is called once per frame
	void Update () {

		//checks the current score of each player
		//game ends when score of either player is 11
		//if player 1 won, load player 1 win screen

	}

    void FixedUpdate()
    {
        // convert current score to string and post it on the correct place of the UI
        leftTimer.GetComponent<Text>().text = leftScore.ToString();
        rightTimer.GetComponent<Text>().text = rightScore.ToString();
    }
}
