using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPos : MonoBehaviour
{
    public float rotateSpeed = 10f;
    private float x;
    private float y;
    private float z;
    private Vector3 pos;
    private bool destroy=false;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(20, 69);
        y = 1.5f;
        z = Random.Range(-19, 19);
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        if (destroy)
        {
            Destroy(gameObject);
        }
    }

    public bool DestroyWeapon
    {
        set { destroy = value;}
    }
}
