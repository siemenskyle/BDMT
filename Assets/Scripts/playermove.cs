using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour {

	public float speed;
	public float jumpforce;
	public KeyCode left;
	public KeyCode right;
	public KeyCode up;
	public KeyCode down;
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
		// Move Left
		if (Input.GetKey (left)) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		
		// Move Right
		if (Input.GetKey (right)) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}

		// Swings
		if (Input.GetKeyDown (hit)) {
			// over hit if up held
			if (Input.GetKey(up))
				ator.SetBool("over", true);
			// under hit if down held
			else if (Input.GetKey(down))
				ator.SetBool("under", true);
			// no direction held means normal hit
			else
				ator.SetBool("straight", true);
		}
	}

	void FixedUpdate () {
		ator.SetBool("over", false);
		ator.SetBool("straight", false);
		ator.SetBool("under", false);

		if (Input.GetKeyDown (jump) && transform.position.y < -2.3) {
			rbody.AddForce (new Vector2 (0, jumpforce));
		}


	}
}
