using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int gunDamage = 5;
    public float fireRate = 0.25f;
    public float weaponRange = 30f;
    public Transform gunEnd;

    private WaitForSeconds shotDuration = new WaitForSeconds(.09f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;
    public Camera fpsCam;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        //fpsCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
            }
            else
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));

            Health health = hit.collider.GetComponent<Health>();

            if (health != null)
            {
                health.Damage(gunDamage);
            }
        }
    }
    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
