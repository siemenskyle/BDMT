﻿using UnityEngine;
using System.Collections;

public class BirdieSpawn : MonoBehaviour {

	//Boolean used to flag if birdie is in play
	bool isPlaying;
	//Boolean used to flag if it is first player's serve
	bool firstPlayerServe;
	//Boolean used to flag if it is second player's serve
	bool secondPlayerServe;
	//Keycode for serving
	public KeyCode start;
	Transform birdTransform;
	GameObject playerOneSpawn;
	GameObject playerTwoSpawn;
	Rigidbody2D r_body;
	CircleCollider2D cil_col;
	BoxCollider2D box_col;
	//k_looks_good on the force to apply to the serve
	public int serveForce;

	// Use this for initialization
	void Start () {
		//Set required variables
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
		//If bird is in serve mode, keep moving it to the player one spawn position
		if (!isPlaying && firstPlayerServe) {
			birdTransform.position = playerOneSpawn.transform.position;
		}

		//If bird is in serve mode, keep moving it to the player two spawn position
		if (!isPlaying && secondPlayerServe) {
			birdTransform.position = playerTwoSpawn.transform.position;
		}

		//if it is possible to serve the bird, and key is inputted, then serve
		// the bird, enable colliders, and set boolean flags.
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

	//Function used when the birdie collides with something, in this case we only care about when it
	// collides with the ground.
	void OnTriggerEnter2D(Collider2D other)
	{
		//if collided with the ground, determine what the boolean flags should become, set boolean flags
		// and disable colliders on the birdie
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
