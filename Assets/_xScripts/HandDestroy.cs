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
        if (photonView.ownerId == 1)
        {
            CreateObject();
        }
        else if (photonView.ownerId == 2)
        {
            BreakObject();
        }
    }

    private void CreateObject()
    {
        PhotonNetwork.Instantiate("cube01", transform.position, transform.rotation, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > impactForce)
        {
            BreakObject();
        }
    }

    private void BreakObject()
    {
        PhotonNetwork.Destroy(gameObject);
        PhotonNetwork.Instantiate("Cube02", transform.position, transform.rotation, 0);
    }
}
