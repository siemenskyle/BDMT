using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VideoPlay : MonoBehaviour {

	MovieTexture movie;

	// Use this for initialization
	void Start () {
		movie = GetComponent<RawImage> ().texture as MovieTexture;
		movie.Play ();
		movie.loop = true;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
