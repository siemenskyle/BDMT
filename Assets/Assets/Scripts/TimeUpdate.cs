using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeUpdate : MonoBehaviour {
    public GameObject timer;

	// Use this for initialization
	void Start () {
        //print(Time.realtimeSinceStartup);
         timer = GameObject.FindGameObjectWithTag("ScoreTimer");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        timer.GetComponent<Text>().text = Time.realtimeSinceStartup.ToString("F1");
    }
}
