using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMousePhysicMovimentBehaviour : MonoBehaviour {
    
	public float screenLimit;

	float width;

	// Update is called once per frame
	void Update () {

        width = GetComponent<SpriteRenderer>().size.x;
        //Aqui ocorre uma atribuição por valor
        Vector2 currentPosition = transform.position;
       // print(Input.mousePosition.x);
        print(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        currentPosition.x = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,-screenLimit,screenLimit);// Mathf.Clamp(Input.mousePosition.x, -screenLimit, screenLimit);

        GetComponent<Rigidbody2D> ().MovePosition (currentPosition);
	}
}
