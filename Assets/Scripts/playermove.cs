using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class playermove : MonoBehaviour {

	public float speed;
    public float sprintSpeed;
	public float jumpforce;
    public float sprintCost;
    public float highGravity;
    public KeyCode left;
	public KeyCode right;
	public KeyCode up;
	public KeyCode down;
	public KeyCode jump;
	public KeyCode hit;
	public KeyCode sprint;
    public KeyCode specialGravity;
	Rigidbody2D rbody;
	BoxCollider2D coll;
	Animator ator;
    public double specialPower;
	GamePadState prevState;
	GamePadState padState;
	public PlayerIndex player;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		coll = GetComponent<BoxCollider2D> ();
		ator = GetComponentInChildren<Animator> ();
        specialPower = 10;
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
            if (Input.GetKey(sprint) && specialPower > sprintCost * Time.fixedDeltaTime)
            {
                transform.Translate(Vector3.left * sprintSpeed * Time.fixedDeltaTime);
                specialPower -= sprintCost * Time.fixedDeltaTime;
            }
            else
                transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
            ator.SetBool("running", true);

        }
        // Move Right
        else if (padState.DPad.Right == ButtonState.Pressed)
        {
            if (Input.GetKey(sprint) && specialPower > sprintCost * Time.fixedDeltaTime)
            {
                transform.Translate(Vector3.right * sprintSpeed * Time.fixedDeltaTime);
                specialPower -= sprintCost * Time.fixedDeltaTime;
            }
            else
                transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            ator.SetBool("running", true);
        }
        else
        {
            ator.SetBool("running", false);
        }

        // Swings
        if (Input.GetKeyDown(hit))
        {
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

        if (Input.GetKeyDown(specialGravity) && specialPower >= 5 && GameObject.FindGameObjectWithTag("Bird").GetComponent<Rigidbody2D>().gravityScale != highGravity)
        {
            GameObject.FindGameObjectWithTag("Bird").GetComponent<Rigidbody2D>().gravityScale = highGravity;
            specialPower -= 5;
        }

        if (Input.GetKeyDown (jump) && transform.position.y < -2.3) {
			rbody.AddForce (new Vector2 (0, jumpforce));
		}


	}
}
