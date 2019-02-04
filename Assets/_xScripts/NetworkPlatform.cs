using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlatform : MonoBehaviour
{
    public GameObject AndroidCameraPrefab;
    public GameObject ViveCameraPrefab;
    public GameObject WaitingRoom;

    private void Awake()
    {
        SpawnPlatformCamera();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlatformCamera()
    {
#if UNITY_ANDROID
        SpawnAndroidCamera();
#elif UNITY_STANDALONE_WIN
        SpawnStandaloneCamera();
#endif
    }

    void SpawnAndroidCamera()
    {
        Instantiate(AndroidCameraPrefab);
        Destroy(WaitingRoom);
    }

    void SpawnStandaloneCamera()
    {
        Instantiate(ViveCameraPrefab);
    }
    
}
