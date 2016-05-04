using UnityEngine;
using System.Collections;

public class AutoAppInfo : MonoBehaviour {

	Transform mainCam;
	UIEnergyUsingObject viewObj;
	UIEnergyUsingObject prevViewObj;
	void Start(){
		
	}
	// Update is called once per frame
	void Update () {
		CheckforEnergyUsingObject ();
	}

	public void CheckforEnergyUsingObject()
	{
		float x = Screen.width /2; 
		float y = Screen.height/2;


		Ray ray = Camera.main.ScreenPointToRay(new Vector3(x,y));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 5f)) {
			viewObj = hit.collider.GetComponent<UIEnergyUsingObject> ();

			if (viewObj != null) {
				viewObj.showUI ();
				if (Input.GetButtonUp ("Toggle")) {
					viewObj.pressOnOff ();
				}
			}
		}
	}
}
