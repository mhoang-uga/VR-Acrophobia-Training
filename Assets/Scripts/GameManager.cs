using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMesh text;
    public int score;
	public float timeElapsed;
    public GameObject player;
    public bool isFlying;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
		timeElapsed = 0;
	}

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
		if (score > 3 && score < 14) //for all of Phase 2 (platforms)
		{
			timeElapsed += Time.deltaTime;
		}
    }



    
}
