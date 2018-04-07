using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollisionBehaviourSeven : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Shoot")
            GalagaGameManagerSeven.instance.OnShipHited(other);
    }
}
