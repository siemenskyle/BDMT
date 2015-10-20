using UnityEngine;
using System.Collections;

public class birdhit : MonoBehaviour {
    Rigidbody2D rbody;
    CircleCollider2D coll;
	public float x;
	public float y;
    // Use this for initialization

    void OnTriggerEnter2D(Collider2D coll)
    {
		Rigidbody2D bird = coll.attachedRigidbody;
		float angle = -1 * transform.rotation.z;
		float forcemult = (angle / 100 + 1) * 1.2f; 
		bird.AddForce (new Vector2 (x * forcemult, y * 1/forcemult));
    }
}
