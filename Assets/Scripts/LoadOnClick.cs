using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	//loads the selected game scene
	public void LoadScene(int level){
		
		Application.LoadLevel (level);
		
	}
}
