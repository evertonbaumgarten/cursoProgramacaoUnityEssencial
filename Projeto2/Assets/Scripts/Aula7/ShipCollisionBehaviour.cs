using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollisionBehaviour : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Shoot")
            GalagaGameManager.instance.OnShipHited(other);
    }
}
