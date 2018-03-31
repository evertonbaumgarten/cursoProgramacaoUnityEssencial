using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPositionSetupBehaviour : MonoBehaviour {

    public GalagaGameManager.AlienType alienType;

    private void OnDrawGizmos()
    {
         Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}
