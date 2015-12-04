using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class OnLevelLoad : MonoBehaviour {
	public GameObject player1prefab;
	public GameObject player2prefab;
	public GameObject bird;

	GameObject p1;
	GameObject p2;
	GameObject gamebird;

	public float turboforward;
	public float turbobackpedal;
	public float turbojumpforce;
	public float turboplayergravscale;
	public float turbobirdgravscale;
	public float turbobirddrag;

	// Use this for initialization
	void Start () {
		// Spawn players into the level
		p1 = Instantiate<GameObject>(player1prefab);
		p1.GetComponent<playermove>().setplayer(PlayerIndex.One);
		p1.transform.position = new Vector2(-7f, -3.68f);
		p1.tag = "PlayerLeft";
		GameObject.FindGameObjectWithTag("LeftPower").GetComponent<ShowPower>().setplayer(p1);

		p2 = Instantiate<GameObject>(player2prefab);
		p2.GetComponent<playermove>().setplayer(PlayerIndex.Two);
		p2.transform.position = new Vector2(7f, -3.68f);
		Vector3 p2scale = p2.transform.localScale;
		p2scale.x *= -1;
		p2.transform.localScale = p2scale;
		p2.tag = "PlayerRight";
		GameObject.FindGameObjectWithTag("RightPower").GetComponent<ShowPower>().setplayer(p2);
		foreach (birdhit h in p2.GetComponentsInChildren<birdhit>())
			h.flipx();

		gamebird = Instantiate<GameObject>(bird);		

		Time.timeScale = 0;
		p1.GetComponent<playermove>().setwait (true);
		p2.GetComponent<playermove>().setwait (true);
		bird.GetComponent<BirdieSpawn>().setwait (true);
	}

	public void turbo()
	{
		p1.GetComponent<playermove>().foreward = turboforward;
		p2.GetComponent<playermove>().foreward = turboforward;
		
		p1.GetComponent<playermove>().backpedal = turbobackpedal;
		p2.GetComponent<playermove>().backpedal = turbobackpedal;
		
		p1.GetComponent<playermove>().jumpforce = turbojumpforce;
		p2.GetComponent<playermove>().jumpforce = turbojumpforce;
		
		p1.GetComponent<Rigidbody2D>().gravityScale = turboplayergravscale;
		p2.GetComponent<Rigidbody2D>().gravityScale = turboplayergravscale;
		
		gamebird.GetComponent<BirdieSpawn>().gravscale = turbobirdgravscale;
		gamebird.GetComponent<Rigidbody2D>().angularDrag = turbobirddrag;
		gamebird.GetComponent<Rigidbody2D>().drag = turbobirddrag;
	}
}
