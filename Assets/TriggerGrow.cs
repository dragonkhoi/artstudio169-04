﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class TriggerGrow : Photon.MonoBehaviour
{
    VRTK_ControllerEvents controllerEvents;

    // Start is called before the first frame update
    void Start()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
        controllerEvents.TriggerPressed += ControllerEvents_TriggerPressed;
    }

    private void ControllerEvents_TriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        if (photonView.ownerId == 1)
        {
            GrowObject();
        }
    }

    private void GrowObject()
    {
        // grow the object

    }
}
