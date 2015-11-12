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
		// Bird is only thing this can collide with now that we fixed it
		Rigidbody2D bird = coll.attachedRigidbody;

		bird.velocity = Vector2.zero;

		// Flip x force if on other side
		//x = -x * Mathf.Sign (transform.position.x);
		//print (x + ", " + y);
		// Add the force
		bird.AddForce (new Vector2 (x, y));
        if (coll.name == "birdie")
        {
            this.enabled = false;
            this.GetComponentInParent<playermove>().specialPower += 1;
            if (this.GetComponentInParent<playermove>().specialPower > 10)
                this.GetComponentInParent<playermove>().specialPower = 10;
        }
    }
}
