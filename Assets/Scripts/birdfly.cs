using UnityEngine;
using System.Collections;

public class birdfly : MonoBehaviour {

	Rigidbody2D rbody;
	Transform tform;
	Quaternion rotation;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
		tform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//rotation = tform.rotation;
		//float angle = Mathf.Atan2(rbody.velocity.normalized.y, rbody.velocity.normalized.x);
		//angle = Mathf.Rad2Deg * angle;

		/*
		if(rbody.velocity != Vector2.zero)
			tform.rotation = Quaternion.LookRotation(rbody.velocity, Vector2.up);
        */
		Vector3 dir = rbody.velocity;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		tform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
