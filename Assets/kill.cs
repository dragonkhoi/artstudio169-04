using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : Photon.MonoBehaviour
{
    public float lifespan;
    private double timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifespan)
        {
            PhotonNetwork.Destroy(this.gameObject);
        }

    }
}
