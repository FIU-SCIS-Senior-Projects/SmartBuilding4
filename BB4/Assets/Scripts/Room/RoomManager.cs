using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour 
{

	RoomModal modal;
	RoomView view;

	[Range(100,5000)][SerializeField]float threshHold;
	// Use this for initialization
	void Start () 
	{
		view = GetComponent<RoomView>();
		modal = GetComponent<RoomModal>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//notification system update.
		if(modal.TotalEnergyUsuage > threshHold)
		{
			Task t = new Task();
			t.Type = Task.TaskType.TurnOff;
			t.State = Task.CompleteState.inProgress;
			NotificationController.reference.SetActiveQuest(modal.ID, t);
		}
	}

	void OnTriggerEnter(Collider player)
	{
		if(player.tag == "Player")
		{
			view.EnterRoom();
			view.ChangeText(modal.RoomName);
		}
	}
}
