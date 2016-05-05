using UnityEngine;
using System.Collections;



public class InteractionController : MonoBehaviour {

	bool nearObject = false;
	public bool carrying = false;
	Camera mainCam;
	[SerializeField]InteractionView view;
	InteractionObject selectedObject;
	Rigidbody carryingObject;
	Rigidbody nearObjectObject;
	[SerializeField]float distance;

	Quaternion carryingObjectRotation;
	SimObject so;

	void Awake() {

		so = GetComponent<SimObject>();

	}


	void Start()
	{
		mainCam = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () 
	{
		if(NearObject || carrying)
		{
			InteractionControl();
		}
	}

	public bool NearObject
	{
		get{ return nearObject;}
		set{nearObject = value;}
	}


	public Rigidbody NearObjectObject {
		get { return nearObjectObject; }
		set {nearObjectObject = value; }
	}


	public InteractionObject Selected
	{
		get{return selectedObject;}
		set{selectedObject = value;}
	}

	public void InteractionControl()
	{
		if(carrying)
		{
			Carry(carryingObject);
		}

		else
		{
			PickUp();
		}

	}

	void PickUp()
	{
		if(Input.GetButtonUp("PickUp"))
		{
			float x = Screen.width /2; 
			float y = Screen.height/2;

			
			Ray ray = mainCam.ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit))
			{
				selectedObject = hit.collider.GetComponent<InteractionObject>();

				if(selectedObject != null)
				{
					if (selectedObject.canPickUp) {
						carrying = true;
						carryingObject = selectedObject.RBody;
					}

					if (selectedObject.canToggle) {
						selectedObject.UIctrl.pressOnOff ();
					}
				}
			}

			if (nearObjectObject != null) {

				selectedObject = nearObjectObject.GetComponent<InteractionObject>();
				if (selectedObject != null) {
					carrying = true;
					carryingObject = selectedObject.RBody;
					carryingObjectRotation = selectedObject.transform.rotation;
				}

			}

		}
	}

	void Carry(Rigidbody x)
	{
		x.isKinematic = true;
		//x.transform.position = Vector3.Lerp(x.transform.position, transform.position + transform.forward * distance, Time.time);
		x.transform.position = transform.position + (transform.forward * distance);
		x.transform.rotation = Quaternion.Euler(carryingObjectRotation.eulerAngles.x, transform.rotation.eulerAngles.y - carryingObjectRotation.eulerAngles.y, carryingObjectRotation.eulerAngles.z);
		if(Input.GetKeyDown(KeyCode.P))
		{
			//added to make sure they can drop the object here.
			if (isAtDropZone())
				drop(x);
		}
	}





	//JUSTIN's METHODS

	bool isAtDropZone() {
		return true;
	}


	void drop(Rigidbody x) {

		x.isKinematic = false;
		carrying = false; 
		carryingObject = null;
		selectedObject = null;


		//successful drop
		//so.checkTaskCompletion();

	}


}
