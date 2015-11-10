using UnityEngine;
using System.Collections;

public class BirdieSpawn : MonoBehaviour {
	
	public bool isPlaying;
	public bool firstPlayerServe;
	public bool secondPlayerServe;
	public KeyCode start;
	Transform birdTransform;
	GameObject playerOneSpawn;
	GameObject playerTwoSpawn;
	Rigidbody2D r_body;
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

		if (Input.GetKey (start)) {
			isPlaying = true;
			r_body.velocity = Vector2.zero;
			r_body.AddForce(new Vector2(0, serveForce));
			firstPlayerServe = false;
			secondPlayerServe = false;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name.Contains("grass"))
		{
			isPlaying = false;

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
