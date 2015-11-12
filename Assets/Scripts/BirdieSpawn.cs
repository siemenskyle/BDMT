using UnityEngine;
using System.Collections;

public class BirdieSpawn : MonoBehaviour {
	
	bool isPlaying;
	bool firstPlayerServe;
	bool secondPlayerServe;
	public KeyCode start;
	Transform birdTransform;
	GameObject playerOneSpawn;
	GameObject playerTwoSpawn;
	Rigidbody2D r_body;
	CircleCollider2D cil_col;
	BoxCollider2D box_col;
	public int serveForce;

	// Use this for initialization
	void Start () {
		isPlaying = false;
		birdTransform = transform;
		firstPlayerServe = true;
		secondPlayerServe = false;
		playerOneSpawn = GameObject.Find ("BirdSpawnOne");
		playerTwoSpawn = GameObject.Find ("BirdSpawnTwo");
		r_body = GetComponent<Rigidbody2D> ();
		cil_col = GetComponent<CircleCollider2D> ();
		box_col = GetComponent<BoxCollider2D> ();

		//Disable two colliders
		cil_col.enabled = false;
		box_col.enabled = false;





		//k_looks_good
		serveForce = 1000;
	}

	// Update is called once per frame
	void Update () {
		if (!isPlaying && firstPlayerServe) {
			birdTransform.position = playerOneSpawn.transform.position;
		}

		if (!isPlaying && secondPlayerServe) {
			birdTransform.position = playerTwoSpawn.transform.position;
		}

		if (Input.GetKey (start) && !isPlaying) {
			isPlaying = true;
			r_body.velocity = Vector2.zero;
			r_body.AddForce(new Vector2(0, serveForce));
			firstPlayerServe = false;
			secondPlayerServe = false;
			cil_col.enabled = true;
			box_col.enabled = true;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name.Contains("grass"))
		{
			isPlaying = false;
			cil_col.enabled = false;
			box_col.enabled = false;
			//player two scored, their serve
			if ((transform.position.x < 0 && transform.position.x >= -18) 
			       ||  transform.position.x > 18) {
				secondPlayerServe = true;
			//Player one scored, their serve
			} else if ((transform.position.x > 0 && transform.position.x <= 18) 
		           || transform.position.x < -18) {
				firstPlayerServe = true;
			}
		}
	}
}
