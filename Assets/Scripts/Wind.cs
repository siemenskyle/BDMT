using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

	public float windforcelow;
	public float windforcehigh;
	public float windfreqlow;
	public float windfreqhigh;
	Rigidbody2D bird;
	bool waitwind;
	Animator ator;
	float force;

	// Use this for initialization
	void Start () {
		waitwind = false;
		ator = GetComponent<Animator> ();
		Invoke ("setbird", 0.2f);
	}
	
	// Update is called once per frame
	void Update () {

		if (!waitwind) {
			waitwind = true;
			Invoke ("applywind", Random.Range (windfreqlow, windfreqhigh));
		} 
	}

	void applywind() {
		if(GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdieSpawn>().isPlaying)
		{
			force = Random.Range (windforcelow, windforcehigh);

			if (Random.value > 0.5) {
				ator.SetTrigger("windleft");
				force *= -1;
			} else {
				ator.SetTrigger("windright");
			}

			Invoke ("applyforce", 1.2f);
		}
		waitwind = false;
	}

	void applyforce() {
		print (force);
		if (!ator.GetCurrentAnimatorStateInfo(0).IsName("New State"))
			bird.AddForce (new Vector2(force, 0));
		//waitwind = false;
	}

	void setbird(){
		bird = GameObject.FindGameObjectWithTag ("Bird").GetComponent<Rigidbody2D> ();
	}
}
