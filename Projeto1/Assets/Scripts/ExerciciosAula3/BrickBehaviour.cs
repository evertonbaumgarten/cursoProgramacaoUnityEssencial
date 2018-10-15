using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour {
    //Vamos utilizar o conceito de lista/Array para armazenar as cores
    public Color[] damageColor;
    //public Color color1;
    //public Sprite sprite1;
	int maxHits;
	protected int hitNumbers;

	// Use this for initialization
	void Start () {
		hitNumbers = 0;
        maxHits = damageColor.Length;

    }
	
	private void OnCollisionExit2D(Collision2D collision)
	{
       GetComponent<SpriteRenderer> ().color = damageColor [hitNumbers];

       //GetComponent<SpriteRenderer>().sprite = sprite1;
        hitNumbers++;

		if (hitNumbers >= maxHits)
			Destroy (gameObject);
	}
}
