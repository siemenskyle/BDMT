using UnityEngine;
using System.Collections;

public class birdhit : MonoBehaviour {
    Rigidbody2D rbody;
    CircleCollider2D coll;
    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (coll.gameObject.tag == "racket")
        {


            rbody.AddForce(new Vector2(10,10));




        }

    }
    public class hit : MonoBehaviour
    {
        public bool birdhit;
        void OnTriggerEnter2D(Collider2D hit)
        {
            birdhit = true;
        }
    }
}
