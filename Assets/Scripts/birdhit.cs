using UnityEngine;
using System.Collections;

public class birdhit : MonoBehaviour {
	Rigidbody2D rbody;
	CircleCollider2D coll;
	public float x;
	public float y;
	public float jumpx;
	public float jumpy;
	public float hitMul;
	public int specialcost;
	// Use this for initialization
	
	public static int lastPlayerToHit;
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		// Bird is only thing this can collide with now that we fixed it
		Rigidbody2D bird = coll.attachedRigidbody;
		int hitter;
		
		if (transform.parent.position.x < 0)
		{
			hitter = 1;
		}
		else
		{
			hitter = 2;
		}
		

		if (hitter != lastPlayerToHit)
		{
			float hitx;
			float hity;

			if(GetComponentInParent<playermove>().grounded){
				hitx = x*2;
				hity = y*2;
			} else {
				hitx = jumpx*2;
				hity = jumpy*2;
			}

			bird.velocity = Vector2.zero;
			// check if the multiplier is been activated by the player, if so and it can be done then activate special move
			if (GetComponentInParent<playermove>().hitMultiplier == true && GetComponentInParent<playermove>().specialPower >= specialcost)
			{
				// if can multiply the hit force
				bird.AddForce(new Vector2(hitMul * hitx, hity));
				
				// if hits the bird, take the power away from the hit and play sound
				GetComponentInParent<playermove>().supercolor();
				this.enabled = false;
				this.GetComponentInParent<playermove>().specialPower -= specialcost;
				AudioSource a = coll.attachedRigidbody.gameObject.GetComponent<AudioSource>();
				a.Play();
                lastPlayerToHit = hitter;
            }
            else
			{
				// if no multiplier, then just use regular hit force
				bird.AddForce(new Vector2(hitx, hity));
				
				// if hits the bird, take the power away from the hit and play sound
				if (coll.tag == "Bird")
				{
					this.enabled = false;
					this.GetComponentInParent<playermove>().specialPower += 1;
					if (this.GetComponentInParent<playermove>().specialPower > 10)
						this.GetComponentInParent<playermove>().specialPower = 10;
				}
				AudioSource a = coll.attachedRigidbody.gameObject.GetComponent<AudioSource>();
				a.Play();
				lastPlayerToHit = hitter;
			}
		}
		// make sure hit multiplier is off
		GetComponentInParent<playermove>().hitMultiplier = false;
		
		GameObject.FindGameObjectWithTag("PlayerLeft").GetComponent< playermove >().setserve(false);
		GameObject.FindGameObjectWithTag("PlayerRight").GetComponent< playermove >().setserve(false);
	}

	public void reset(){
		lastPlayerToHit = 0;
	}

	// Flip X force, used if on P2 side
	public void flipx(){
		x *= -1;
	}
}