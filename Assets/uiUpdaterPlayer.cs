using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiUpdaterPlayer : MonoBehaviour
{
    public GameObject player;
    public string whoIs;
    public Text myText1;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            myText1.text = whoIs + " health = " + player.GetComponent<Health>().GetHealth().ToString();
        else
            myText1.text = whoIs + " is dead";
    }
}
