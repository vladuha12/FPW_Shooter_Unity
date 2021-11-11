using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openingScript : MonoBehaviour
{

    public Vector3 endPos;
    public float speed = 1.0f;

    private bool moving = false;
    private bool opening = true;
    private Vector3 startPos;
    private float delay = 0.0f;
    private bool soundPlayed = false;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (opening)
            {
                moveDoor(endPos);
            }
            else
            {
                moveDoor(startPos);
            }
        }
    }

    void moveDoor(Vector3 goalPos)
    {
        float dist = Vector3.Distance(transform.localPosition, goalPos);
        
        if(dist > 0.00001f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, goalPos, speed * Time.deltaTime);
            if (!soundPlayed)
            {
                source.Play();
                soundPlayed = true;
            }
        }
        else
        {
            if (opening)
            {
                delay += Time.deltaTime;
                if (delay > 0.5f)
                {
                    opening = false;
                    soundPlayed = false;

                }
                
            }
            else
            {
                moving = false;
                opening = true;
                
            }
        }

    }
    public bool Moving
    {
        get { return moving; }
        set { moving = value; soundPlayed = false; }
    }
}
