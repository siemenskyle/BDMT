using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class playermove : MonoBehaviour {
	// Public variables
    public bool hitMultiplier;
	public float foreward;
	public float backpedal;
    public float sprintMult;
	public float jumpforce;
    public float sprintCost;
    public float highGravity;
	public double specialPower;
	public PlayerIndex player;
	// Player Objects
	Rigidbody2D rbody;
	Animator ator;
	// Game Pad
	GamePadState prevState;
	GamePadState padState;
	// Flags
	bool grounded;
	bool serve;


	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		ator = GetComponentInChildren<Animator> ();
        specialPower = 10;
		grounded = false;
		serve = true;
        hitMultiplier = false;
	}
	
	// Update is called once per frame
	void Update () {
		prevState = padState;
		padState = GamePad.GetState (player);

		ator.SetBool("over", false);
		ator.SetBool("straight", false);
		ator.SetBool("under", false);


        // Move Lefts
        if (padState.DPad.Left == ButtonState.Pressed)
        {
			float movespeed;

			// Check if backpedaling
			if(player == PlayerIndex.One)
				movespeed = backpedal;
			else
				movespeed = foreward;

			// Check for sprint -- cannot sprint if serve
			if (padState.Buttons.RightShoulder == ButtonState.Pressed 
			    && specialPower > sprintCost * Time.fixedDeltaTime && !serve)
            {
				movespeed = movespeed * sprintMult;
                specialPower -= sprintCost * Time.fixedDeltaTime;
            }

            // Apply Move
            transform.Translate(Vector3.left * movespeed * Time.fixedDeltaTime);
            ator.SetBool("running", true);
        }
        // Move Right
        else if (padState.DPad.Right == ButtonState.Pressed)
        {
			float movespeed;
			
			// Check if backpedaling
			if(player == PlayerIndex.One)
				movespeed = foreward;
			else
				movespeed = backpedal;

			// Check for Sprint -- cannot sprint if serve
			if (padState.Buttons.RightShoulder == ButtonState.Pressed 
			    && specialPower > sprintCost * Time.fixedDeltaTime && !serve)
            {
				movespeed = movespeed * sprintMult;
                specialPower -= sprintCost * Time.fixedDeltaTime;
            }

            // Apply Move
			transform.Translate(Vector3.right * movespeed * Time.fixedDeltaTime); 
            ator.SetBool("running", true);
        }
        else
        {
            ator.SetBool("running", false);
        }

        // Swings
		if (prevState.Buttons.X == ButtonState.Released && padState.Buttons.X == ButtonState.Pressed)
        {
            // if button pressed, then multiplier is added to hit force.
            if (padState.Buttons.RightShoulder == ButtonState.Pressed)
                hitMultiplier = true;
            // over hit if up held
            if (padState.DPad.Up == ButtonState.Pressed)
                ator.SetBool("over", true);
            // under hit if down held
            else if (padState.DPad.Down == ButtonState.Pressed)
                ator.SetBool("under", true);
            // no direction held means normal hit
            else
                ator.SetBool("straight", true);
        }


		// Special move -- cannot if serving
		if (prevState.Buttons.LeftShoulder == ButtonState.Released && padState.Buttons.LeftShoulder == ButtonState.Pressed && !serve)
        {
			specialmove();
        }


		// Jump -- Cannot jump if serving
		if (prevState.Buttons.A == ButtonState.Released && padState.Buttons.A == ButtonState.Pressed
		    && grounded && !serve) 
		{
			rbody.AddForce (new Vector2 (0, jumpforce));
		}

	}
	
	// High Gravity Special
	// Cannot use if already activated by self or other player
	private void specialmove()
	{
		if(specialPower >= 5 && GameObject.FindGameObjectWithTag("Bird").GetComponent<Rigidbody2D>().gravityScale != highGravity)
		{
			GameObject.FindGameObjectWithTag("Bird").GetComponent<Rigidbody2D>().gravityScale = highGravity;
			GameObject.Find("circle").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("circle").GetComponent<AudioSource>().enabled = true;
			specialPower -= 5;
		}
	}

	// Check if grounded
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "ground"){
			grounded = true;
		}
	}
	void OnCollisionStay2D(Collision2D coll){
		if(coll.gameObject.tag == "ground"){
			grounded = true;
		}
	}
	void OnCollisionExit2D(){
		grounded = false;
	}


	// PUBLIC FUNCTIONS USED OUTSIDE THIS
	// Set serving flag
	public void setserve(bool set)
	{
		serve = set;
	}
	public void setplayer(PlayerIndex p)
	{
		player = p;
	}




}
