using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

[RequireComponent(typeof(InteractionView))]

public class InteractionObject : MonoBehaviour {

	public bool canPickUp = false;
	public bool canToggle = false;

	Rigidbody rBody;
	UIEnergyUsingObject uiObj;
	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody>();
		if (canToggle) {
			uiObj = GetComponent<UIEnergyUsingObject> ();
		}

	}
		
	public Rigidbody RBody
	{
		get{return rBody;}
	}

	public UIEnergyUsingObject UIctrl
	{
		get{return uiObj; }
	}
}
