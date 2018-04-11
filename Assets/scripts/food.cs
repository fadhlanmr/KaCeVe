using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour {

	Vector2 Position;

	Rigidbody2D pgn;
	public BoxCollider2D haha;

	// Use this for initialization
	void Start () {
		pgn = GetComponent<Rigidbody2D>();
		haha = GetComponent<BoxCollider2D>();
	
		Position = new Vector2(Random.Range(-36, 36), Random.Range(-15, 15));
	}

	void OnCollisionEnter2D(Collision2D collisionInfo){
		if(collisionInfo.collider.name == "snakeOne"){
			Position = new Vector2(Random.Range(-36, 36), Random.Range(-15, 15));
			pgn.position = Position;
        }
	}

	// Update is called once per frame
	void Update () {
		pgn.position = Position;
	}
}
