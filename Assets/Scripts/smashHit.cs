using UnityEngine;
using System.Collections;

public class smashHit : MonoBehaviour {
    Rigidbody2D rbody;
    CircleCollider2D coll;
    public GameObject player;
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
            // cost 5 special to smash hit
            this.GetComponentInParent<playermove>().specialPower -= 5;

			AudioSource a = coll.attachedRigidbody.gameObject.GetComponent<AudioSource> ();
			a.Play();
        }

		GameObject.FindGameObjectWithTag("PlayerLeft").GetComponent< playermove >().setserve(false);
		GameObject.FindGameObjectWithTag("PlayerRight").GetComponent< playermove >().setserve(false);
    }
}
