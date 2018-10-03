using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourSimple : MonoBehaviour {

	// Use this for initialization
	public float startSpeed;

	void Start () {

        //Aplica uma força de 10 vezes para diagonal direita superior.
		GetComponent<Rigidbody2D>().velocity = (Vector2.up+Vector2.right)*startSpeed;
        //Modifica a influência da gravidade sobre este corpo para que ele se comporte como esperado.
        //GetComponent<Rigidbody2D>().gravityScale = 0.01f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		print("OnCollisionEnter2D"+ collision.collider.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		print("OnTriggerEnter2D "+ other.name);
    }
}
