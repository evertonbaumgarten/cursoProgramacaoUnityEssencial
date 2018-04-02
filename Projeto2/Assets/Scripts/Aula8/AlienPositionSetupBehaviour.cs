using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPositionSetupBehaviour : MonoBehaviour {

    public GalagaGameManager.AlienType alienType;

    private void OnDrawGizmos()
    {
        Debug.Log((int)alienType);
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}
