using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeOne : MonoBehaviour {

	bool flagUp 	= false;
	bool flagDown 	= false;

	public Vector2 Position;
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
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			flagDown = true;

			flagUp = false;
		}

		if (flagUp) {
			transform.position = Position;
			Position.y += 0.05F;
		}

		if (flagDown) {
			transform.position = Position;
			Position.y -= 0.05F;
		}
	}
}
