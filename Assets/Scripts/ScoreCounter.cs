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
            if (gameObject.transform.position.x < 0) rightScore++;
            else if (gameObject.transform.position.x > 0) leftScore++;
          }
        print("TRIGGER");

    }
    // Use this for initialization
    void Start () {
        leftScore = 0;
        rightScore = 0;
        leftTimer = GameObject.FindGameObjectWithTag("LeftScore");
        rightTimer = GameObject.FindGameObjectWithTag("RightScore");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        leftTimer.GetComponent<Text>().text = leftScore.ToString();
        rightTimer.GetComponent<Text>().text = rightScore.ToString();
    }
}
