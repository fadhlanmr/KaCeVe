using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeOne : MonoBehaviour {

	bool flagUp 	= false;
	bool flagDown 	= false;
    bool flagRight  = false;
    bool flagLeft   = false;
    bool rotated    = false;

	public Vector2 Position;
    public Sprite facing;
	public Vector2 Velocity;

	// Use this for initialization
	void Start () {
		Position = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			flagUp = true;
			flagDown = false;
            flagLeft = false;
            flagRight = false;
            rotated = false;
        }
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			flagDown = true;
			flagUp = false;
            flagLeft = false;
            flagRight = false;
            rotated = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            flagRight = true;
            flagLeft = false;
            flagDown = false;
            flagUp = false;
            rotated = false;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            flagRight = false;
            flagLeft = true;
            flagDown = false;
            flagUp = false;
            rotated = false;
        }

        if (flagUp) {
			transform.position = Position;
			Position.y += 0.1F;
            this.gameObject.transform.Rotate(0, 0, 0);
		}

		if (flagDown) {
			transform.position = Position;
			Position.y -= 0.1F;
            if (!rotated){
                this.gameObject.transform.Rotate(0, 0, 180);
                rotated = true;
            }
        }
        if (flagLeft) {
            transform.position = Position;
            Position.x -= 0.1F;
            if (!rotated)
            {
                this.gameObject.transform.Rotate(0, 0, 90);
                rotated = true;
            }
        }
        if (flagRight)
        {
            transform.position = Position;
            Position.x += 0.1F;
            if (!rotated)
            {
                this.gameObject.transform.Rotate(0, 0, -90);
                rotated = true;
            }
        }
    }
}
