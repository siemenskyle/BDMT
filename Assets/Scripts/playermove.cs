using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class playermove : MonoBehaviour {

	public float foreward;
	public float backpedal;
    public float sprintMult;
	public float jumpforce;
    public float sprintCost;
    public float highGravity;
	Rigidbody2D rbody;
//	BoxCollider2D coll;
	Animator ator;
    public KeyCode smash;
    public double specialPower;
	GamePadState prevState;
	GamePadState padState;
	public PlayerIndex player;
	bool grounded;
	bool serve;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		//coll = GetComponent<BoxCollider2D> ();
		ator = GetComponentInChildren<Animator> ();
        specialPower = 10;
		grounded = false;
		serve = true;
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

			// Check for sprint
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

			// Check for Sprint
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

		// Special
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

	public void setserve(bool set)
	{
		serve = set;
	}

	// High Gravity Special
	private void specialmove()
	{
		if(specialPower >= 5 && GameObject.FindGameObjectWithTag("Bird").GetComponent<Rigidbody2D>().gravityScale != highGravity)
		{
			GameObject.FindGameObjectWithTag("Bird").GetComponent<Rigidbody2D>().gravityScale = highGravity;
			specialPower -= 5;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "ground"){
			grounded = true;
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "ground"){
			grounded = true;
		}
	}

	void OnCollisionExit2D()
	{
		grounded = false;
	}
}
