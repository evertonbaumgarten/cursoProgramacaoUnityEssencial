using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPositionSetupBehaviour : MonoBehaviour {

    public GalagaGameManager.AlienType alienType;
    public Texture textureGuizmo;

    private void OnDrawGizmos()
    {
        if(textureGuizmo)
            Gizmos.DrawGUITexture(new Rect(transform.position.x,transform.position.y, textureGuizmo.width, textureGuizmo.height), textureGuizmo);
        else
            Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}
