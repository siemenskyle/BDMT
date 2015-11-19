using UnityEngine;
using System.Collections;

public class ShowPower : MonoBehaviour {


    // List of sprites that will have each the graph of how much special power a player has
    public Sprite powerTen;
    public Sprite powerNine;
    public Sprite powerEight;
    public Sprite powerSeven;
    public Sprite powerSix;
    public Sprite powerFive;
    public Sprite powerFour;
    public Sprite powerThree;
    public Sprite powerTwo;
    public Sprite powerOne;
    public Sprite powerZero;

    // The player of whom will have special power to be displayed in the graph
    public GameObject player;

	// Use this for initialization
	public void setplayer (GameObject p) {
		player = p;

	}
	
	// Update is called once per frame
	void Update () {
        // Get special power, and switch between the sprites depending on how much power is left
        switch ((int)player.GetComponent<playermove>().specialPower)
        {
            case 0:
                this.GetComponent<SpriteRenderer>().sprite = powerZero;
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = powerOne;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = powerTwo;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = powerThree;
                break;
             case 4:
                this.GetComponent<SpriteRenderer>().sprite = powerFour;
                break;
            case 5:
                this.GetComponent<SpriteRenderer>().sprite = powerFive;
                break;
            case 6:
                this.GetComponent<SpriteRenderer>().sprite = powerSix;
                break;
            case 7:
                this.GetComponent<SpriteRenderer>().sprite = powerSeven;
                break;
            case 8:
                this.GetComponent<SpriteRenderer>().sprite = powerEight;
                break;
            case 9:
                this.GetComponent<SpriteRenderer>().sprite = powerNine;
                break;
            case 10:
                this.GetComponent<SpriteRenderer>().sprite = powerTen;
                break;
        }
	}
}
