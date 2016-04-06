using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NotificationView))]
[RequireComponent(typeof(NotificationModel))]
public class NotificationController : MonoBehaviour
{
	public static NotificationController reference;
	[SerializeField]NotificationView view;
	[SerializeField]NotificationModel model;
	bool[] activeQuest;
	Task[] tasks;

	void Start()
	{
		reference = this;
		view = GetComponent<NotificationView>();
		model = GetComponent<NotificationModel>();
		activeQuest = new bool[model.Size];
		tasks = new Task[model.Size];
	}

	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.X))
		{
			view.ToggleQuestScreen();
		}

		if(view.WindowState && Input.GetKeyDown(KeyCode.Space))
		{
			view.DisableNotificationPanel();
		}	
	}

	public void SetActiveQuest(int i, Task t)
	{
		if(!activeQuest[i] && !view.WindowState)
		{
			activeQuest[i] = true;
			tasks[i] = t;
			view.QuestDetails = "The Emission Level in " + model.GetRoomName(i) + " is getting High: " + model.GetEmission(i);
			view.EnableNotificationPanel();
			view.UpdateButton(i);
		}
	}

	public void UpdateQuestInfo(int index)
	{
		view.QuestDetails = "The Emission Level in " + model.GetRoomName(index) + " is getting High: " + model.GetEmission(index);
		view.EnableNotificationPanel();
	}
}
