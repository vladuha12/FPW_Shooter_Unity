using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyEnableListener : MonoBehaviour
{
    public GameObject listener;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnDestroy()
    {
        listener.GetComponent<AudioListener>().enabled = true;
    }
}
