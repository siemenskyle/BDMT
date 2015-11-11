using UnityEngine;
using System.Collections;

public class ShowPower : MonoBehaviour {

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

    public GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
