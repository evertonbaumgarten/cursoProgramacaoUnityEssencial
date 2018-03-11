using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour {
	//Vamos utilizar o conceito de lista/Array para armazenar as cores
	public Color[] damageColor;
	public int maxHits;
	protected int hitNumbers;

	// Use this for initialization
	void Start () {
		hitNumbers = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnCollisionExit2D()
	{
		GetComponent<Renderer> ().material.color = damageColor [hitNumbers];
		
		hitNumbers++;

		if (hitNumbers >= maxHits)
			Destroy (gameObject);
	}
}
