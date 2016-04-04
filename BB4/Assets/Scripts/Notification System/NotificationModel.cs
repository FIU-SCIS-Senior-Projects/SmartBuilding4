using UnityEngine;
using System.Collections;

public class NotificationModel : MonoBehaviour 
{
	public RoomModal[] _rooms;		//room class that will hold name of room, plugload, and room lightemission. 
	NotificationController ctrl;


	// Use this for initialization
	void Start () {
		ctrl = GetComponent<NotificationController>();

		for(int i = 0; i < _rooms.Length; i++)
		{
			_rooms[i].ID = i;
		}
		//testEmissions = new float[rmNames.Length];
	}
	
	// Update is called once per frame
	void Update () {
	}

	public string GetRoomName(int index)
	{
		//return rmNames[index];
		return _rooms[index].RoomName;
	}

	public float GetEmission(int index)
	{
		//return testEmissions[index];
		return _rooms[index].TotalEnergyUsuage;
	}

	public int Size
	{
		//get{return rmNames.Length;}
		get{return _rooms.Length;}
	}
//
//	void Emit()
//	{
//		for(int i = 0; i < testEmissions.Length; i++)
//		{
//			testEmissions[i] += Time.deltaTime * Random.Range(0,10);
//
//			if(testEmissions[i] >= 50)
//			{
//				ctrl.SetActiveQuest(i);
//			}
//		}
//	}
}
