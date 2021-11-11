using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControler : MonoBehaviour
{
    public Animator anim;
    Vector3 prevPos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (prevPos == transform.position)
        {
            anim.SetBool("moving", false);
        }
        else
        {
            anim.SetBool("moving", true);
        }
        prevPos = transform.position;
        
        
    }
}
