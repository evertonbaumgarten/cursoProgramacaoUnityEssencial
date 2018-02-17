﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovimentBehaviour : MonoBehaviour {

    public float speed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 currentPosition = transform.position;

        if (Input.GetKey(KeyCode.RightArrow))
            currentPosition.x += speed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            currentPosition.x -= speed;

        transform.position = currentPosition;
    }
}