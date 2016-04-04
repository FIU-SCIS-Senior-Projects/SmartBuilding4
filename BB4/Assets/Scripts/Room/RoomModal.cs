using UnityEngine;
using System.Collections;

public class RoomModal : MonoBehaviour {

	[SerializeField]string rmName;
	[SerializeField]PlugLoad plugLoad;
	int _ID;

	public float TotalEnergyUsuage
	{
		get{return plugLoad.getAggregateUsage();}
	}

	public string RoomName
	{
		get{return rmName;}
	}

	public int ID
	{
		get{return _ID;}
		set{_ID = value;}
	}
}
