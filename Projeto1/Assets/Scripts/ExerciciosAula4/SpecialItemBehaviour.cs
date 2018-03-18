using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemBehaviour : MonoBehaviour {

    public GameManagerBehaviour gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OnTriggerEnter2D STAR");
        gameManager.onSpecialItemCollision();
        Destroy(gameObject);
    }
}
