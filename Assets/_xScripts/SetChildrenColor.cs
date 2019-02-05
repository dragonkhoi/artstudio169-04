using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChildrenColor : Photon.MonoBehaviour
{
    public void SetColorOfChildren(float r, float g, float b)
    {
        photonView.RPC("SetColor", PhotonTargets.All, r, g, b);
    }

    [PunRPC]
    void SetColor(float r, float g, float b)
    {
        Color setCol = new Color(r, g, b);
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Renderer>().material.color = setCol;
        }
    }
}
