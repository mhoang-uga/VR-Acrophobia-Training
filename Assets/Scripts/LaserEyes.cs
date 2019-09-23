using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyes : MonoBehaviour
{
	Camera cam;
	SpottableObject targetBillboard;
	// Start is called before the first frame update
	void Start()
    {
		cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
		Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit rayHit;
		if (Physics.Raycast(ray, out rayHit)) {
			if(rayHit.collider.gameObject.tag == "toSpot") {
				SpottableObject spotted = rayHit.collider.GetComponent<SpottableObject>();
				spotted.tagged();
			}
		}

    }
}
