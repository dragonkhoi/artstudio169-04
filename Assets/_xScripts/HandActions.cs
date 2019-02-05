﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using Photon;

public class HandActions : Photon.MonoBehaviour
{
    VRTK_ControllerEvents controllerEvents;

    // Start is called before the first frame update
    void Start()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
        controllerEvents.TriggerClicked += ControllerEvents_TriggerClicked;
    }

    private void ControllerEvents_TriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        CreateObject();
    }

    private void CreateObject()
    {
        PhotonNetwork.Instantiate("Cube01", transform.position, Quaternion.identity, 0);
    }
}
