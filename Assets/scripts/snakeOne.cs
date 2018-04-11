using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeOne : MonoBehaviour {

	bool flagUp 	= false;
	bool flagDown 	= false;
    bool flagRight  = false;
    bool flagLeft   = false;
    int rotateState = 0;

    public CircleCollider2D colli;

	Vector2 Position;
	public float Velocity = 0.5f;

	// Use this for initialization
	void Start () {
		Position = new Vector2 (0, 0);
        colli = GetComponent<CircleCollider2D>();
	}

    public char buttonUp        = 'w';
    public char buttonDown      = 's';
    public char buttonRight     = 'd';
    public char buttonLeft      = 'a';    

    void randomizeButtonTrigger(){
        buttonUp = (char)(Random.Range(0, 25) + (int)('a'));
        buttonDown = (char)((Random.Range(1, 25) + (int)(buttonUp) - (int)('a')) % 26 + (int)('a'));

        buttonLeft = (char)(Random.Range(0, 25) + (int)('a'));
        while(buttonLeft == buttonUp || buttonLeft == buttonDown) buttonLeft = (char)(Random.Range(0, 25) + (int)('a'));
        buttonRight = (char)((Random.Range(1, 25) + (int)(buttonLeft) - (int)('a')) % 26 + (int)('a'));
        while(buttonRight == buttonUp || buttonRight == buttonDown || buttonRight == buttonLeft) buttonRight = (char)(Random.Range(0, 25) + (int)('a'));

        print(buttonUp.ToString() + " " + buttonRight + " " + buttonDown + " " + buttonLeft);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // Debug.Log(collisionInfo.collider.name);
        if(collisionInfo.collider.tag == "Wall"){
            Destroy(gameObject);
        }        

        if(collisionInfo.collider.name == "food"){
            Velocity *= 1.1f;
            randomizeButtonTrigger();
            // Debug.Log("Velocity: " + Velocity);
        }
    }

    string keString(char x){
        string haha = x.ToString();
        return haha;
    }

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(keString(buttonUp))) {
			flagUp = true;
			flagDown = false;
            flagLeft = false;
            flagRight = false;
        }
		if (Input.GetKeyDown(keString(buttonDown))) {
			flagDown = true;
			flagUp = false;
            flagLeft = false;
            flagRight = false;
        }
        if (Input.GetKeyDown(keString(buttonRight))) {
            flagRight = true;
            flagLeft = false;
            flagDown = false;
            flagUp = false;
        }
        if(Input.GetKeyDown(keString(buttonLeft))) {
            flagRight = false;
            flagLeft = true;
            flagDown = false;
            flagUp = false;
        }

        if (flagUp) {
			transform.position = Position;
			Position.y += 0.1F * Velocity;
            this.gameObject.transform.Rotate(0, 0, rotateState);
            rotateState = 0;
        }

		if (flagDown) {
            transform.position = Position;
			Position.y -= 0.1F * Velocity;
            this.gameObject.transform.Rotate(0, 0, rotateState+180);
            rotateState = 180;
		}
        if (flagLeft) {
            transform.position = Position;
            Position.x -= 0.1F * Velocity;
            this.gameObject.transform.Rotate(0, 0, rotateState + 90);
            rotateState = -90;
        }
        if (flagRight) {
            transform.position = Position;
            Position.x += 0.1F * Velocity;
            this.gameObject.transform.Rotate(0, 0, rotateState - 90);
            rotateState = 90;
        }
    }
}
