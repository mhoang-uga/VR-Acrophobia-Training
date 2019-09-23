using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public OVRInput.Controller myController;

    public GameManager gameManager;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            this.transform.Translate(0f, 0f, (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) + OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger)) * .4f);
            this.transform.Rotate(0f, Input.GetAxis("Horizontal"), 0f);
 
            player.transform.parent = this.transform;


    }
}
