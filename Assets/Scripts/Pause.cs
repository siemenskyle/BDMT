using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Pause : MonoBehaviour {

	GamePadState prevState;
	GamePadState padState;
	GameObject quitbutton;
	GameObject resumebutton;
	GameObject dimback;
	playermove p1;
	playermove p2;
	BirdieSpawn bird;

	void getplayers (){
		p1 = GameObject.FindGameObjectWithTag ("PlayerLeft").GetComponent< playermove > ();
		p2 = GameObject.FindGameObjectWithTag ("PlayerRight").GetComponent< playermove > ();
		bird = GameObject.FindGameObjectWithTag ("Bird").GetComponent< BirdieSpawn > ();
	}

	// Use this for initialization
	void Start () {
		dimback = GameObject.Find ("dimback");
		quitbutton = GameObject.Find ("QuitB");
		resumebutton = GameObject.Find ("ResumeB");
		Invoke ("getplayers", 0.5f);
		quitbutton.SetActive (false);
		resumebutton.SetActive (false);
		//GameUnpause ();
	}


	// Update is called once per frame, check for pause
	void Update () {
		prevState = padState;
		padState = GamePad.GetState (PlayerIndex.One);
		if (padState.Buttons.Start == ButtonState.Pressed && prevState.Buttons.Start == ButtonState.Released)
			GamePause ();

		prevState = padState;
		padState = GamePad.GetState (PlayerIndex.Two);
		if (padState.Buttons.Start == ButtonState.Pressed && prevState.Buttons.Start == ButtonState.Released)
			GamePause ();
	}
	
	void GamePause() {
		Time.timeScale = 0;
		quitbutton.SetActive (true);
		resumebutton.SetActive (true);
		dimback.SetActive (true);
		p1.setwait (true);
		p2.setwait (true);
		bird.setwait (true);
	}

	public void GameUnpause() {
		GameObject.Find("SpeedSelectCanvas").SetActive(false);
		Time.timeScale = 1;
		quitbutton.SetActive (false);
		resumebutton.SetActive (false);
		dimback.SetActive (false);
		p1.setwait (false);
		p2.setwait (false);
		bird.setwait (false);
	}
}
