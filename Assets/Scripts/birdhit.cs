using UnityEngine;
using System.Collections;

public class birdhit : MonoBehaviour {
    Rigidbody2D rbody;
    CircleCollider2D coll;
	public float x;
	public float y;
    public float hitMul;

    public static int lastPlayerToHit;
	public static int lastToHitNOW;

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
			bird.velocity = Vector2.zero;
            // check if the multiplier is been activated by the player, if so and it can be done then activate special move
            if (GetComponentInParent<playermove>().hitMultiplier == true && GetComponentInParent<playermove>().specialPower >= 5)
            {
                // if can multiply the hit force
                bird.AddForce(new Vector2(hitMul * x, hitMul * y));

                // if hits the bird, take the power away from the hit and play sound
                this.enabled = false;
                this.GetComponentInParent<playermove>().specialPower -= 5;
                AudioSource a = coll.attachedRigidbody.gameObject.GetComponent<AudioSource>();
                a.Play();
            }
            else
            {
                // if no multiplier, then just use regular hit force
                bird.AddForce(new Vector2(x, y));
                // if hits the bird, take the power away from the hit and play sound
                if (coll.tag == "Bird")
                {
                    if (lastToHitNOW != hitter)
                    {
                        this.enabled = false;
                        this.GetComponentInParent<playermove>().specialPower += 1;
                        if (this.GetComponentInParent<playermove>().specialPower > 10)
                            this.GetComponentInParent<playermove>().specialPower = 10;
						lastToHitNOW = hitter;
                    }
                }
                AudioSource a = coll.attachedRigidbody.gameObject.GetComponent<AudioSource>();
                a.Play();
                //lastPlayerToHit = hitter;
				Invoke ("lasthitchange", 0.2f);
            }
        }
        // make sure hit multiplier is off
        GetComponentInParent<playermove>().hitMultiplier = false;

        GameObject.FindGameObjectWithTag("PlayerLeft").GetComponent< playermove >().setserve(false);
		GameObject.FindGameObjectWithTag("PlayerRight").GetComponent< playermove >().setserve(false);
    }

	void FixedUpdate(){
		if(GameObject.FindGameObjectWithTag("Bird").GetComponent< BirdieSpawn >().isPlaying == false)
			lastPlayerToHit = 0;
			lastToHitNOW = 0;
	}

	void lasthitchange(){
		int hitter;
		if (transform.parent.position.x < 0)
		{
			hitter = 1;
		}
		else
		{
			hitter = 2;
		}
		
		lastPlayerToHit = hitter;
	}

	// Flip X force, used if on P2 side
	public void flipx(){
		x *= -1;
	}
}
