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
	
	private void OnCollisionExit2D(Collision2D collision)
	{
		GetComponent<Renderer> ().material.color = damageColor [hitNumbers];
		
		hitNumbers++;

		if (hitNumbers >= maxHits)
			Destroy (gameObject);
	}
}
