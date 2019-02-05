using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;
using System;

public class HandDestroy : Photon.MonoBehaviour
{
    public float impactForce;
    VRTK_ControllerEvents controllerEvents;
    int playerId;

    // Start is called before the first frame update
    void Start()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
        controllerEvents.TriggerClicked += ControllerEvents_TriggerClicked;
        playerId = Array.IndexOf(PhotonNetwork.playerList, PhotonNetwork.player);
    }

    void OnPhotonConnect()
    {

    }

    private void ControllerEvents_TriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log(photonView.ownerId);
        if (playerId == 0)
        {
            CreateObject();
        }
        else if (playerId == 1)
        {
            // BreakObject();
        }
    }

    private void CreateObject()
    {
        GameObject cube = PhotonNetwork.Instantiate("cube01", transform.position, transform.rotation, 0);
        cube.GetComponent<SpawnRandomColor>().SpawnRandom(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        Debug.Log("collided");
        if (collision.gameObject.name.Contains ("cube01"))
        {
            Debug.Log("hit a cube, owner is: " + playerId);
            if (playerId == 1)
            {
                Debug.Log("i am owner 1");
                 BreakObject(collision.transform.gameObject);
      
            }
        }
        
    }

    private void BreakObject(GameObject toDestroy)
    {
        Color cubeColor = toDestroy.GetComponent<Renderer>().material.color;
        PhotonNetwork.Destroy(toDestroy);
        GameObject newCube = PhotonNetwork.Instantiate("Cube02", transform.position, transform.rotation, 0);
        newCube.GetComponent<SetChildrenColor>().SetColorOfChildren(cubeColor.r, cubeColor.g, cubeColor.b);
    }
}
