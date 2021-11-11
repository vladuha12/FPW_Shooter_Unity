using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deth : MonoBehaviour
{
    public GameObject player;
    public GameObject capsule;
    private int healthFromCapsule;
    // Start is called before the first frame update
    void Start()
    {
        healthFromCapsule = GetComponent<Health>().GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthFromCapsule = capsule.GetComponent<Health>().GetHealth();
        Debug.Log(healthFromCapsule);
        if (healthFromCapsule ==0)
        {
            Destroy(player);
        }
    }
}
