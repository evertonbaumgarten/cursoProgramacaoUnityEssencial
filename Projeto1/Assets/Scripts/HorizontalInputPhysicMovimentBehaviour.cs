using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalInputPhysicMovimentBehaviour : MonoBehaviour {

	public float speed = 0.5f;
	public float screenLimit;

	float width;

	void Start()
	{
		width =  GetComponent<SpriteRenderer> ().size.x;
	}

	// Update is called once per frame
	void Update () {
		//Aqui ocorre uma atribuição por valor
		Vector2 currentPosition = transform.position;

		if (Input.GetKey(KeyCode.RightArrow))
			currentPosition.x += speed;
		else if (Input.GetKey(KeyCode.LeftArrow))
			currentPosition.x -= speed;

		if(currentPosition.x < screenLimit-width/2 && currentPosition.x > -(screenLimit-width/2))
			GetComponent<Rigidbody2D> ().MovePosition (currentPosition);
	}
}
