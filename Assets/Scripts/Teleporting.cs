using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Teleporting : MonoBehaviour
{
	private RaycastHit lastRaycastHit;

	void start()
	{

		Cursor.visible = false;
	}

	private GameObject GetLookedAtObject()
	{

		Vector3 origin = transform.position;
		Vector3 direction = Camera.main.transform.forward;
		float range = 1000;

		if (Physics.Raycast(origin, direction, out lastRaycastHit, range))

			return lastRaycastHit.collider.gameObject;

		else

			return null;

	}

	private void TeleportToLookAt()
	{
		transform.position = lastRaycastHit.point + lastRaycastHit.normal * 2;

	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
			if (GetLookedAtObject() != null)
				TeleportToLookAt();
	}

}



