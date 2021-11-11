using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpdate : MonoBehaviour
    {
    public GameObject healthFromWho;

    private TextMesh text;
    private string health;
    private bool isMaster;
    private bool isWeaponFound;
    private bool isWeaponObtained;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMesh>();
        health = healthFromWho.GetComponent<Health>().GetHealth().ToString();
        isMaster = healthFromWho.GetComponent<playerNavMesh>().getIsMaster();
    }

    // Update is called once per frame
    void Update()
    {
        health = healthFromWho.GetComponent<Health>().GetHealth().ToString();
        isMaster = healthFromWho.GetComponent<playerNavMesh>().getIsMaster();

        if (isMaster)
            text.text = health + " Master\n";
        else
            text.text = health + " Slave\n";
    }
}
