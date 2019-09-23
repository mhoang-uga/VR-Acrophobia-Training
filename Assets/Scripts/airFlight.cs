using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airFlight : MonoBehaviour
{
    public OVRInput.Controller myController;
	private float speed = .4f;
    public GameManager gameManager;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isFlying)
        {
            this.transform.Translate(0f, 0f, (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) + OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger)) * speed);
            this.transform.Rotate( Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0f);

            player.transform.parent = this.transform;

        }


    }
	public void increaseSpeed() {
		speed += 0.1f;
	}

	public void decreaseSpeed()
	{
		if (speed > 0) {
			speed -= 0.1f;
		}
	}
}
