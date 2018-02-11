using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.Translate(Vector2.left);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.Translate(Vector2.right);
    }
}
