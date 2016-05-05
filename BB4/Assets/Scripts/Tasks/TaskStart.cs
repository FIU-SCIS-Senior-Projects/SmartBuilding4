using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class TaskStart : MonoBehaviour {

	SimulationManager sm;

	Text messageBox;
	Text taskList;


	void Awake() {
		sm = SimulationManager.sharedSimManager;

	}

	// Use this for initialization
	void Start () {

		SimulationManager.sharedSimManager.TimeTracker.onOneSecondPassed += OneSecond;

		messageBox = GameObject.Find("TaskMessage").GetComponent<Text>();
		taskList = GameObject.Find("TaskList").GetComponent<Text>();


	}


	void OneSecond(float time) {


		float realTime = time - SimulationManager.sharedSimManager.TimeTracker.getSimStartTime();




		foreach(Task t in SimulationManager.sharedSimManager.getListOfTasks()) {

			if (t.State == Task.CompleteState.neverStarted) {

				if (t.StartTime == realTime) {
					t.State = Task.CompleteState.inProgress;
					//Debug.Log("Task Has Started");
					ChangeText("Task: "+t.TaskName+"\n"+"<size='18'>"+t.Description+"</size>");


				}

			}

			else if (t.State == Task.CompleteState.inProgress) {

				//calculate end time.
				int totalLength = (t.StartTime + t.TimeLimit + t.TimeLength);
				if (realTime == totalLength) { //this is the absolute latest the task can be completed by.

					//fail
					t.State = Task.CompleteState.failed;

					ChangeText("Task Failed"+t.TaskName);
					//Debug.Log("TASK FAILED!!!");
				}

			}


			else if (t.State == Task.CompleteState.completed) {

				ChangeText("Task Completed"+t.TaskName);

				t.State = Task.CompleteState.completedCompleted;
			}

		}

	}






	IEnumerator FadeInOut()
	{
		Color c = messageBox.color;
		float displayTime = 2f;

		while(c.a < 1)
		{
			c.a += Time.deltaTime;
			messageBox.color = c;
			yield return null;
		}

		yield return new WaitForSeconds(displayTime);

		while(c.a > 0 )
		{
			c.a -= Time.deltaTime;
			messageBox.color = c;
			yield return null;
		}
	}

	public void ChangeText(string name)
	{
		messageBox.supportRichText = true;
		messageBox.text = name;
		StopCoroutine("FadeInOut");
		StartCoroutine(FadeInOut());

		taskList.text = "";
		List<Task> tl = sm.getListOfTasks(Task.CompleteState.inProgress);
		Debug.Log("TASK LIST IS " + tl.Count);
		foreach(Task t in tl) {
			taskList.text += "<b>"+t.TaskName + "</b>\n";
			taskList.text += t.Description + "\n\n";

		}

	}






}