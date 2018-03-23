using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBehaviour : MonoBehaviour {

	// Use this for initialization
	public float startSpeed;
    public GameManagerBehaviour gameManager;
    
	void Start () {

        //Aplica uma força de 10 vezes para diagonal direita superior.
		GetComponent<Rigidbody2D>().velocity = (Vector2.up+Vector2.right)*startSpeed;
        //Modifica a influência da gravidade sobre este corpo para que ele se comporte como esperado.
        //GetComponent<Rigidbody2D>().gravityScale = 0.01f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.onBallHit(other);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.onBallHit(collision.collider);
       
    }
}
