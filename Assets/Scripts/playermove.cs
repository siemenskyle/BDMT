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
	public double specialPower;
	public PlayerIndex player;
	public Color sprintcolor;
	public Color s_hitcolor;
	public Color specialcolor;
	public int specialcost;
	// Player Objects
	Rigidbody2D rbody;
	Animator ator;
	Transform groundchk;
	// Game Pad
	GamePadState prevState;
	GamePadState padState;
	// Flags
	public bool grounded;
	bool serve;
	bool wait;
	bool wassprint;
    public static float standardGravity;
    public float GravityMultiply;

    // Use this for initialization
    void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		ator = GetComponentInChildren<Animator> ();
        specialPower = 10;
		grounded = false;
		serve = true;
        hitMultiplier = false;
		groundchk = GetComponentsInChildren<Transform> ()[5];
        standardGravity = 1;
    }

    // Update is called once per frame
    void Update () {
		prevState = padState;
		padState = GamePad.GetState (player);

		ator.SetBool("over", false);
		ator.SetBool("straight", false);
		ator.SetBool("under", false);

		if(wait)
			return;

		if(wassprint)
			resetcolor();
		wassprint = false;

        // Move Lefts
        if (padState.DPad.Left == ButtonState.Pressed || padState.ThumbSticks.Left.X <= -0.5f)
        {
			float movespeed;

			// Check if backpedaling
			if(player == PlayerIndex.One){
				movespeed = backpedal;
				ator.SetBool("backpedal", true);
				ator.SetBool("running", false);
			}
			else{
				movespeed = foreward;
				ator.SetBool("running", true);
				ator.SetBool("backpedal", false);
			}

			// Check for sprint -- cannot sprint if serve
			if (padState.Buttons.RightShoulder == ButtonState.Pressed 
			    && specialPower > sprintCost * Time.fixedDeltaTime && !serve)
            {
				movespeed = movespeed * sprintMult;
                specialPower -= sprintCost * Time.fixedDeltaTime;
				this.GetComponentsInChildren<SpriteRenderer>()[4].color = sprintcolor;
				wassprint = true;
            }

            // Apply Move
            transform.Translate(Vector3.left * movespeed * Time.fixedDeltaTime);
            
        }
        // Move Right
		else if (padState.DPad.Right == ButtonState.Pressed || padState.ThumbSticks.Left.X >= 0.5f)
        {
			float movespeed;
			
			// Check if backpedaling
			if(player == PlayerIndex.One){
				ator.SetBool("running", true);
				ator.SetBool("backpedal", false);
				movespeed = foreward;
			} 
			else {
				movespeed = backpedal;
				ator.SetBool("backpedal", true);
				ator.SetBool("running", false);
			}

			// Check for Sprint -- cannot sprint if serve
			if (padState.Buttons.RightShoulder == ButtonState.Pressed 
			    && specialPower > sprintCost * Time.fixedDeltaTime && !serve)
            {
				movespeed = movespeed * sprintMult;
                specialPower -= sprintCost * Time.fixedDeltaTime;
				this.GetComponentsInChildren<SpriteRenderer>()[4].color = sprintcolor;
				wassprint = true;
            }

            // Apply Move
			transform.Translate(Vector3.right * movespeed * Time.fixedDeltaTime); 
        }
        else
        {
            ator.SetBool("running", false);
			ator.SetBool("backpedal", false);
        }

        // Swings
		if (prevState.Buttons.X == ButtonState.Released && padState.Buttons.X == ButtonState.Pressed)
        {
            // if button pressed, then multiplier is added to hit force.
            if (padState.Buttons.RightShoulder == ButtonState.Pressed)
                hitMultiplier = true;
            // over hit if up held
			if (padState.DPad.Up == ButtonState.Pressed || padState.ThumbSticks.Left.Y >= 0.5f)
                ator.SetBool("over", true);
            // under hit if down held
			else if (padState.DPad.Down == ButtonState.Pressed || padState.ThumbSticks.Left.Y <= -0.5f)
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
		if(specialPower >= specialcost && GameObject.FindGameObjectWithTag("Bird").GetComponent<Rigidbody2D>().gravityScale != (GravityMultiply * standardGravity))
		{
			GameObject.FindGameObjectWithTag("Bird").GetComponent<Rigidbody2D>().gravityScale = (GravityMultiply * standardGravity);
			GameObject.Find("circle").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("circle").GetComponent<AudioSource>().enabled = true;
			specialPower -= specialcost;
			this.GetComponentsInChildren<SpriteRenderer>()[4].color = specialcolor;
			Invoke("resetcolor", 0.7f);
		}
	}

	void resetcolor()
	{
		this.GetComponentsInChildren<SpriteRenderer>()[4].color = new Color(0f, 0f, 0f, 0f);
	}

	public void supercolor()
	{
		this.GetComponentsInChildren<SpriteRenderer>()[4].color = s_hitcolor;
		Invoke("resetcolor", 0.3f);
	}

	// Check if grounded
	void FixedUpdate()
	{
		//print (groundchk.position);
		grounded = Physics2D.Linecast(rbody.position, groundchk.position, 1 << LayerMask.NameToLayer("Ground"));
		if(grounded)
			ator.SetBool("jump", false);
		else
			ator.SetBool("jump", true);

	}

	// PUBLIC FUNCTIONS USED OUTSIDE THIS
	// Set serving flag
	public void setserve(bool set)
	{
		serve = set;
	}
	public void setwait(bool set)
	{
		wait = set;
	}
	public void setplayer(PlayerIndex p)
	{
		player = p;
	}




}
