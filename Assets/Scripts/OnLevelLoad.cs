using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class OnLevelLoad : MonoBehaviour {
	public GameObject player1prefab;
	public GameObject player2prefab;
	public GameObject bird;


	// Use this for initialization
	void Start () {
		// Spawn players into the level
		GameObject p1 = Instantiate<GameObject>(player1prefab);
		p1.GetComponent<playermove>().setplayer(PlayerIndex.One);
		p1.transform.position = new Vector2(-7f, -3.68f);
		p1.tag = "PlayerLeft";
		GameObject.FindGameObjectWithTag("LeftPower").GetComponent<ShowPower>().setplayer(p1);

		GameObject p2 = Instantiate<GameObject>(player2prefab);
		p2.GetComponent<playermove>().setplayer(PlayerIndex.Two);
		p2.transform.position = new Vector2(7f, -3.68f);
		Vector3 p2scale = p2.transform.localScale;
		p2scale.x *= -1;
		p2.transform.localScale = p2scale;
		p2.tag = "PlayerRight";
		GameObject.FindGameObjectWithTag("RightPower").GetComponent<ShowPower>().setplayer(p2);
		foreach (birdhit h in p2.GetComponentsInChildren<birdhit>())
			h.flipx();

		Instantiate(bird);
	}
}
