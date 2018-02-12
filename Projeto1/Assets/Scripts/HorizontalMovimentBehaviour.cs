﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovimentBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 currentPosition = transform.position;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            currentPosition.x = currentPosition.x + 1;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            currentPosition.x = currentPosition.x - 1;

        transform.position = currentPosition;
    }
}