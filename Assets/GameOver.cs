using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Camera mainCam;
    public Camera secondaryCam;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = mainCam.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam == null)
        {
            secondaryCam.enabled = true;
        }
    }
}
