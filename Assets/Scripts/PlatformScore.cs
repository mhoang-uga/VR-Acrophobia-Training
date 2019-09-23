using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScore : MonoBehaviour
{
	public int value;

	public GameManager gameManager;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter(Collider other)
	{

		gameManager.score += value;

	}
}
