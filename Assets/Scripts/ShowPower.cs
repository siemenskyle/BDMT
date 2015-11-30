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
	public Color spriteColor;

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
				this.GetComponent<SpriteRenderer>().color = spriteColor;
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = powerOne;
				this.GetComponent<SpriteRenderer>().color = spriteColor;
				break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = powerTwo;
				this.GetComponent<SpriteRenderer>().color = spriteColor;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = powerThree;
				this.GetComponent<SpriteRenderer>().color = spriteColor;
                break;
             case 4:
                this.GetComponent<SpriteRenderer>().sprite = powerFour;
				this.GetComponent<SpriteRenderer>().color = spriteColor;
                break;
            case 5:
                this.GetComponent<SpriteRenderer>().sprite = powerFive;
				this.GetComponent<SpriteRenderer>().color = spriteColor;
				break;
            case 6:
                this.GetComponent<SpriteRenderer>().sprite = powerSix;
				this.GetComponent<SpriteRenderer>().color = spriteColor;
				break;
            case 7:
                this.GetComponent<SpriteRenderer>().sprite = powerSeven;
				this.GetComponent<SpriteRenderer>().color = spriteColor;
				break;
            case 8:
                this.GetComponent<SpriteRenderer>().sprite = powerEight;
				this.GetComponent<SpriteRenderer>().color = spriteColor;
				break;
            case 9:
                this.GetComponent<SpriteRenderer>().sprite = powerNine;
				this.GetComponent<SpriteRenderer>().color = spriteColor;
				break;
            case 10:
                this.GetComponent<SpriteRenderer>().sprite = powerTen;
				this.GetComponent<SpriteRenderer>().color = spriteColor;
				break;
        }
	}
}
