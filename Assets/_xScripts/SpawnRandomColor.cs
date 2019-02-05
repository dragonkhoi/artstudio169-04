using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomColor : Photon.MonoBehaviour
{

    public void SpawnRandom(float r, float g, float b)
    {
        photonView.RPC("SetRandomColor", PhotonTargets.All, r, g, b);
    }
    
    [PunRPC]
    void SetRandomColor(float r, float g, float b)
    {
        GetComponent<Renderer>().material.color = new Color(r, g, b);
    }
}
