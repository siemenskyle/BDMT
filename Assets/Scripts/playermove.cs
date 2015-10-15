using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour {

	public float speed;
	public float jumpforce;
	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	public KeyCode hit;
	Rigidbody2D rbody;
	BoxCollider2D coll;
	Animator ator;


	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		coll = GetComponent<BoxCollider2D> ();
		ator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate Left
		if (Input.GetKey (left)) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		
		// Rotate Right
		if (Input.GetKey (right)) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
	}

	void FixedUpdate () {
		ator.SetBool ("swing", false);
		if (Input.GetKey (jump) && transform.position.y < -2.3) {
			rbody.AddForce (new Vector2 (0, jumpforce));
		}

		if (Input.GetKey (hit)) {
			ator.SetBool("swing", true);
		}
	}
}
