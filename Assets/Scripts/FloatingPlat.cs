using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlat : MonoBehaviour
{
	public float targetHeight;
	public float descentSpeed;
	public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		if (gm.score >= 3)
		{
			if ((transform.position.y + 88) > targetHeight) // add 88 for offset of Steps group
				transform.Translate(0, -descentSpeed, 0);
		}
	}



}
