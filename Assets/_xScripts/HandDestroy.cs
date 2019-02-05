using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class HandDestroy : Photon.MonoBehaviour
{
    public float impactForce;
    VRTK_ControllerEvents controllerEvents;

    // Start is called before the first frame update
    void Start()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
        controllerEvents.TriggerClicked += ControllerEvents_TriggerClicked;
    }

    private void ControllerEvents_TriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log(photonView.ownerId);
        if (photonView.ownerId == 0)
        {
            CreateObject();
        }
        else if (photonView.ownerId == 1)
        {
            // BreakObject();
        }
    }

    private void CreateObject()
    {
        GameObject cube = PhotonNetwork.Instantiate("cube01", transform.position, transform.rotation, 0);
        cube.GetComponent<SpawnRandomColor>().SpawnRandom(Random.value, Random.value, Random.value);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains ("cube"))
        {
            if (photonView.ownerId == 1)
            {
                if (collision.relativeVelocity.magnitude > impactForce)
                {
                    BreakObject(collision.transform.gameObject);
                }
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
