using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class HandDestroy : MonoBehaviour
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
       BreakObject();
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
