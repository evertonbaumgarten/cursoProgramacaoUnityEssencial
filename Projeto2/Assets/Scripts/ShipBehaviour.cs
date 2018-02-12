using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour {

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 currentPosition = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
            currentPosition.x -= 0.5f;
        else if (Input.GetKey(KeyCode.RightArrow))
            currentPosition.x +=  0.5f;

        transform.position = currentPosition;
    }
}
