using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	//loads the selected game scene
	public void LoadScene(int level){

        ScoreCounter.leftScore = 0;
        ScoreCounter.rightScore = 0;
        Application.LoadLevel (level);
        GameObject.FindGameObjectWithTag("ScoreBelt").GetComponent<TimeUpdate>().deltaTime = Time.realtimeSinceStartup;
            }
}
