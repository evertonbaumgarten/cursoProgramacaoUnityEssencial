using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCrackBehaviour : MonoBehaviour {
	//Vamos utilizar o conceito de lista/Array para armazenar as cores
	public Sprite[] spriteList;
	public int maxHits;
	protected int hitNumbers;

	// Use this for initialization
	void Start () {
		hitNumbers = 0;	
		GetComponent<SpriteRenderer> ().sprite = spriteList [hitNumbers];
	}
	
	private void OnCollisionExit2D(Collision2D collision)
	{
		hitNumbers++;
		if (hitNumbers >= maxHits)
			Destroy (gameObject);
		else
			GetComponent<SpriteRenderer> ().sprite = spriteList [hitNumbers];
	}
}
