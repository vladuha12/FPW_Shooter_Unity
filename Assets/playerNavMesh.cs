using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public GameObject target;
    public float walkRadius=20f;
    private Vector3 randomDirection;
    private Vector3 finalPosition;
    public float targetDist = 5f;
    public int vieweingDistance = 30;
    private bool isWeaponFound=false;
    private bool isWeaponObtained = false;
    private RaycastHit hit;
    public GameObject player;
    public bool isMaster;
    public GameObject slaveNPC;
    private bool isEnemySeen = false;
    private Vector3 targetPostitionLookAt;
    public string whoToAttack = "Player";
    public GameObject weapon;

    //Shooting
    public int gunDamage = 5;
    public float fireRate = 0.25f;
    public float weaponRange = 30f;
    public Transform gunEnd;

    private WaitForSeconds shotDuration = new WaitForSeconds(.09f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        finalPosition = randomPoint();
        weapon.SetActive(false);

        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        navMeshAgent.destination = finalPosition;

        if (isWeaponFound == false)
        {
            if (navMeshAgent.remainingDistance < targetDist)
            {
                finalPosition = randomPoint();
            }

            // if raycast hits, it checks if it hit an object with the tag Weapon
            if (Physics.Raycast(transform.position, transform.forward, out hit, vieweingDistance) &&
                        hit.collider.gameObject.CompareTag("Weapon"))
            {
                //Debug.Log("I see the Weapon");
                isWeaponFound = true;
                finalPosition = hit.transform.position;
                
            }
        }
        if (isWeaponFound && navMeshAgent.remainingDistance < targetDist && isWeaponObtained == false)
        {
            try
            {
                hit.transform.gameObject.GetComponent<randomPos>().DestroyWeapon = true;
                isWeaponObtained = true;
                //Debug.Log("I echeived Weapon");
                weapon.SetActive(true);
            }
            catch 
            {
                isWeaponObtained = false;
                isWeaponFound = false;
            }
        }

        if (isWeaponObtained)
        {
            if (navMeshAgent.remainingDistance < targetDist && isEnemySeen == false)
            {
                finalPosition = randomPoint();
            }

            if (!isMaster)
            {
                if (slaveNPC != null)
                {
                    finalPosition = slaveNPC.transform.position;
                }
                else {
                    isMaster = !isMaster; 
                }  
            }

            //Shoot
            if (Physics.Raycast(transform.position, transform.forward, out hit, 50))
            {
                //Debug.Log(hit.transform.tag.ToString());
                if (hit.collider.gameObject.CompareTag(whoToAttack.ToString()))
                {
                    isEnemySeen = true;
                targetPostitionLookAt = new Vector3(hit.transform.position.x,
                                        this.transform.position.y,
                                        hit.transform.position.z);
                transform.LookAt(targetPostitionLookAt);
                if (isMaster)
                {
                    finalPosition = hit.transform.position;
                    //
                }

                if (isEnemySeen && Time.time > nextFire)
                {
                    
                    nextFire = Time.time + fireRate;

                    StartCoroutine(ShotEffect());

                    //Vector3 rayOrigin = transform.forward;
                    laserLine.SetPosition(0, gunEnd.position);

                    targetPostitionLookAt.y = targetPostitionLookAt.y + 1;
                    laserLine.SetPosition(1, targetPostitionLookAt);

                    Health health = hit.collider.GetComponent<Health>();

                    if (health != null)
                    {
                        health.Damage(gunDamage);
                    }
                }
                }
                else
                {
                    isEnemySeen = false;
                }
                

            }
            else
            {
                isEnemySeen = false;
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

    Vector3 randomPoint()
    {
        randomDirection = UnityEngine.Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        finalPosition = hit.position;
        return finalPosition;
    }

    public bool getIsMaster()
    {
        return isMaster;
    }

    public bool getIsWeaponObtained()
    {
        return isWeaponObtained;
    }
    public bool getIsWeaponFound()
    {
        return isWeaponFound;
    }
}
