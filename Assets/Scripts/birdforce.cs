using UnityEngine;
using System.Collections;

public class birdforce : MonoBehaviour {

	Rigidbody2D rbody;
	public float x;
	public float y;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
		rbody.AddForce(new Vector2(x, y));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
