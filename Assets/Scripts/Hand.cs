using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
	public GameObject teleporterIndicatorPrefab;
	public List<GameObject> teleporterIndicators = new List<GameObject>();
	bool teleporterActive = false;
	public Vector3 teleporterSelectionPoint;
	public float teleporterPower;
	public Transform head;
	public Player player;
	public OVRInput.Controller myController;
	public float teleTriggerSqueezeThreshold;
	public float teleTriggerReleaseThreshold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float triggerSqueeze = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, myController);

		if (triggerSqueeze > teleTriggerSqueezeThreshold && !teleporterActive) {
			teleporterActive = true;
		} else if (teleporterActive && triggerSqueeze < teleTriggerReleaseThreshold) {
			player.teleport(teleporterSelectionPoint, Vector3.zero);
			for (int i = 0; i < teleporterIndicators.Count; i++) {
				GameObject.Destroy(teleporterIndicators[i]);
			}

			teleporterIndicators.Clear();
			teleporterActive = false;
		}
		int currPointInd = 1;
		Vector3 currPoint = this.transform.position;
		Vector3 currVel = this.transform.forward * teleporterPower;
		float t = 0;
		float time_increment = 0.1f;
		if(teleporterActive) {
			while(t < 5) {
				Vector3 nextPoint = currPoint + currVel * teleporterPower * time_increment;
				currVel = currVel + new Vector3(0, -10, 0) * time_increment;

				RaycastHit hit;
				bool gotHit = false;

				if (Physics.Raycast(currPoint, (nextPoint - currPoint).normalized, out hit, (nextPoint - currPoint).magnitude)) {
					teleporterSelectionPoint = hit.point + new Vector3(0, 0.5f, 0); //extra offset to prevent falling through floor
					gotHit = true;
				}

				if (currPointInd > teleporterIndicators.Count) {
					teleporterIndicators.Add(GameObject.Instantiate(teleporterIndicatorPrefab));
				}

				if (gotHit) {
					teleporterIndicators[teleporterIndicators.Count - 1].transform.position = hit.point;
					break;
				}

				teleporterIndicators[currPointInd - 1].transform.position = nextPoint;

				currPoint = nextPoint;
				currPointInd++;
				t += time_increment;
			}
			List<GameObject> temp = new List<GameObject>();
			for(int i = 0; i < teleporterIndicators.Count; i++) {
				if (i < currPointInd)
					temp.Add(teleporterIndicators[i]);
				else 
					GameObject.Destroy(teleporterIndicators[i]);
			}
			teleporterIndicators = temp;
		}
    }
}
