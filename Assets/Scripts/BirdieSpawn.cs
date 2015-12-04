using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class BirdieSpawn : MonoBehaviour {

	//Boolean used to flag if birdie is in play
	public bool isPlaying;
	//Boolean used to flag if it is first player's serve
	bool firstPlayerServe;
	//Boolean used to flag if it is second player's serve
	bool secondPlayerServe;

	Transform birdTransform;

    public float ForceServeTime;
	public float gravscale;

	Animator pointAnim;

	Transform playerOneSpawn;
	Transform playerTwoSpawn;
	Rigidbody2D r_body;
	CircleCollider2D cil_col;
	BoxCollider2D box_col;
	GamePadState prevState;
	GamePadState padState;
	//k_looks_good on the force to apply to the serve
	public int serveForce;
	bool wait;


	// Use this for initialization
	void Start () {
		// Get components
		r_body = GetComponent<Rigidbody2D> ();
		cil_col = GetComponent<CircleCollider2D> ();
		box_col = GetComponent<BoxCollider2D> ();
		playerOneSpawn = GameObject.FindGameObjectWithTag("PlayerLeft").GetComponentsInChildren<Transform> ()[4];
		playerTwoSpawn = GameObject.FindGameObjectWithTag("PlayerRight").GetComponentsInChildren<Transform> ()[4];
		pointAnim = GameObject.Find ("Indicators").GetComponent<Animator>();
        //Set required variables
        wait = true;
		isPlaying = false;
		birdTransform = transform;

		r_body.gravityScale = gravscale;

        pointAnim.SetBool("start", true);
		//Random first serve
		if (Random.value > 0.5f) {
			firstPlayerServe = true;
			secondPlayerServe = false;
			pointAnim.SetBool("p1", true);
		} else {
			firstPlayerServe = false;
			secondPlayerServe = true;
			pointAnim.SetBool("p2", true);
		}

		//Disable two colliders
		cil_col.enabled = false;
		box_col.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (isPlaying) {
			cil_col.enabled = true;
			box_col.enabled = true;
		}

		//If bird is in serve mode, keep moving it to the player one spawn position
		if (!isPlaying && firstPlayerServe) {
			birdTransform.position = playerOneSpawn.position;

        }

        //If bird is in serve mode, keep moving it to the player two spawn position
        if (!isPlaying && secondPlayerServe) {
			birdTransform.position = playerTwoSpawn.position;

        }

        //if it is possible to serve the bird, and key is inputted, serve
        if (!isPlaying && !wait){
			prevState = padState;

			if(firstPlayerServe){
				padState = GamePad.GetState(PlayerIndex.One);
			}
			if(secondPlayerServe){
				padState = GamePad.GetState(PlayerIndex.Two);
			}

			if(prevState.Buttons.A == ButtonState.Released && padState.Buttons.A == ButtonState.Pressed)

				servebird();

        }
    }

    // Serve the bird, enable colliders, and set boolean flags.
    void servebird()
	{
		r_body.gravityScale = gravscale;
		isPlaying = true;
		r_body.velocity = Vector2.zero;
		r_body.AddForce(new Vector2(0, serveForce));
		firstPlayerServe = false;
		secondPlayerServe = false;
		cil_col.enabled = true;
		box_col.enabled = true;
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
			if(transform.position.x > 18 || transform.position.x < -18)
				pointAnim.SetBool("out", true);

			//player two scored, their serve
			if ((transform.position.x < 0 && transform.position.x >= -18) 
			       ||  transform.position.x > 18) {
				secondPlayerServe = true;
				pointAnim.SetBool("p2", true);
			//Player one scored, their serve
			} else if ((transform.position.x > 0 && transform.position.x <= 18) 
		           || transform.position.x < -18) {
				firstPlayerServe = true;
				pointAnim.SetBool("p1", true);
			}
			wait = true;
			GameObject.FindGameObjectWithTag("PlayerLeft").GetComponent< playermove >().setserve(true);
			GameObject.FindGameObjectWithTag("PlayerRight").GetComponent< playermove >().setserve(true);
			GameObject.FindGameObjectWithTag("PlayerLeft").GetComponent< playermove >().setwait(true);
			GameObject.FindGameObjectWithTag("PlayerRight").GetComponent< playermove >().setwait(true);

			GameObject.Find("circle").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("circle").GetComponent<AudioSource>().enabled = false;

        }
    }

	public void setwait(bool set){
		wait = set;
	}
}
