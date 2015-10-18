using UnityEngine;
using System.Collections;

public class BirdieSpawn : MonoBehaviour {

	public float x_spawn;
	public float y_spawn;
	public bool isPlaying;
	public KeyCode start;
	Transform birdTransform;

	// Use this for initialization
	void Start () {
		isPlaying = false;
		birdTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPlaying) {
			birdTransform.position = new Vector2(x_spawn, y_spawn);
		}

		if (Input.GetKey (start)) {
			isPlaying = true;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name.Contains("grass"))
		{
			isPlaying = false;

			if (birdTransform.position.x < 0) {
				x_spawn = Mathf.Abs(x_spawn);
			} else if (birdTransform.position.x > 0) {
				x_spawn = -1 * Mathf.Abs (x_spawn);
			}
		}
	}











}
