using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAudioCubes : MonoBehaviour
{ 
    public GameObject cube;

    GameObject[] newCubes = new GameObject[256];
    public float maxscale;

    // Start is called before the first frame update

    void Start()
    {
        for(int i =0; i < 256; i++)
        {
            GameObject instanceNewCube = (GameObject)Instantiate(cube);
            instanceNewCube.transform.position = this.transform.position;
            instanceNewCube.transform.parent = this.transform;
            instanceNewCube.name = "New Cube" + i;
            this.transform.eulerAngles = new Vector3(0, -1f * i, 0);
            instanceNewCube.transform.position = Vector3.forward * 100;
            instanceNewCube.transform.localScale = new Vector3(1/10, 1/10, 1/10);
            newCubes[i] = instanceNewCube;

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0;i < 256; i++)
        {
            if(newCubes != null)
            {
                newCubes[i].transform.localScale = new Vector3(10, (AudioVizualizer._samples[i] * maxscale) + 2, 10);
            }
        }
    }
}
