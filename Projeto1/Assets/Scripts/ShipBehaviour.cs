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
            Debug.Log("Move para Esquerda");
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            Debug.Log("Move para Direita");
    }
}
