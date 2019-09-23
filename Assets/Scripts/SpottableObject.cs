using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottableObject : MonoBehaviour
{
	int tags = 0;
	public Material spotMat;
	public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //once 100 raycast messages are received, change material
		if (tags == 50)
		{
			this.GetComponent<Renderer>().material = spotMat;
			gm.score += 1;
		}
    }

	public void tagged() // called by LaserEyes whenever it is looking at/hitting the board
	{
		tags++;
	}
}
