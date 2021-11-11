using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public Camera fpsCam;
    public GameObject player;

    public GameObject rifle;

    // Start is called before the first frame update
    void Start()
    {
        //rifle = player.GetComponent("M4A1 Sopmod");
        //shootingScript = player.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, 2) && hit.collider.gameObject.CompareTag("Weapon"))
        {
            if (Input.GetKeyDown("e") && rifle.activeSelf == false)
            {
                hit.transform.gameObject.GetComponent<randomPos>().DestroyWeapon = true;
                transform.GetComponent<Shooting>().enabled = true;
                rifle.SetActive(true);
                
            }
        }
    }
}
