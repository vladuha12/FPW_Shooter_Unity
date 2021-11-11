using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolScript : MonoBehaviour
{
    public int speed;
    public Transform[] waypoints;

    private int waypointIndex;
    private float dist;
    private bool moving = true;
    private Animator animator;

    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].localPosition);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (moving)
        {
            animator.SetBool("Stop", false);
            dist = Vector3.Distance(transform.localPosition, waypoints[waypointIndex].localPosition);
            if (dist < 0.5f)
            {
                increaseIndex();
            }
            patrol();
        }
        else
        {
            animator.SetBool("Stop",true);
        }
            
    }

    void patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    void increaseIndex()
    {
        waypointIndex++;
        if(waypointIndex>= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].localPosition);
    }

    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }
}