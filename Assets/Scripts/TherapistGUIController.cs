using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TherapistGUIController : MonoBehaviour
{
	public GameManager gm;
	public Player playa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonClicked(){
        SceneManager.LoadScene("PlaneScene");   
    }

        public void buttonClicked01(){
		if (gm.score >= 3)
		{
			playa.transform.position = new Vector3(328.266f, -67.802f, -46f);
            gm.score = 3;
		}
		else
            SceneManager.LoadScene("FreeMountain");
	}
    public void buttonClicked02() {
        SceneManager.LoadScene("FreeMountain");
    }
}
