using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerId : Photon.PunBehaviour
{

    private void OnPlayerConnected(PhotonPlayer player)
    {
        if(player.IsLocal)
        {
            GetComponent<HandDestroy>().SetPlayer();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
