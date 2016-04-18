using UnityEngine;
using System.Collections;

public class InteractionController : MonoBehaviour {

	bool nearObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(NearObject)
		{
			InteractionControl();
		}
	}

	public bool NearObject
	{
		get{ return nearObject;}
		set{nearObject = value;}
	}

	public void InteractionControl()
	{
		
	}
}
