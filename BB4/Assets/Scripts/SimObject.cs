using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Linq;


[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[System.Serializable]
public class SimObject : MonoBehaviour {




	#region
	[Header("SIM OBJECT INFO")]
	[SerializeField]
	string name;
	[SerializeField]
	string description;
	#endregion


	[SerializeField] public SimulationManager.TaskObjectMove taskObjectMove = SimulationManager.TaskObjectMove.None;
	[SerializeField] public SimulationManager.TaskObjectTurnOnOff taskObjectTurnOnOff = SimulationManager.TaskObjectTurnOnOff.None;
	[SerializeField] public SimulationManager.DropZone drop = SimulationManager.DropZone.None;


	void Awake() {
		//check the current task.

	}

	void Start() {
	}

	public string getName() {
		return name;
	}
	public string getDesc() {
		return description;
	}

	public void setName(string n) {
		name = n;
	}
	public void setDescription(string d) {
		description = d;
	}


	/// <summary>
	/// Checks the task completion.
	/// Should be called whenever an object is interacted
	/// in a way that would complete a task.
	/// Uses simulation manager to get the current task
	/// </summary>
	public virtual void checkTaskCompletion(DropZone dz) {



		if (dz != null) {

			//check if I'm a task object.
			foreach (Task t in SimulationManager.sharedSimManager.getListOfTasks(Task.CompleteState.inProgress)) {

				//if the task types match... then check task completion.
				if (taskObjectMove == t.TaskObjectMove && dz.drop == t.Drop) {
					Debug.Log("Landed On Drop Zone");
					//you've just completed the task.
					Debug.Log("Completed Task");

					t.State = Task.CompleteState.completed;
				}
			}

		}



	}

	public void checkTaskTurnOn() {
		foreach(Task t in SimulationManager.sharedSimManager.getListOfTasks(Task.CompleteState.inProgress)) {

			//make sure a task exists.
			if (t != null) {

				//if the tasks interaction object is this object.
				if (t.TaskObjectTurnOnOff == taskObjectTurnOnOff) { //you've completed this task.

					if (t.Type == Task.TaskType.TurnOn) {

						//you've just completed the task.
						Debug.Log("Completed Task");

						t.State = Task.CompleteState.completed;

						break;
					}
				}
			}
		}
	}

	public void checkTaskTurnOff() {

		foreach(Task t in SimulationManager.sharedSimManager.getListOfTasks(Task.CompleteState.inProgress)) {

			//make sure a task exists.
			if (t != null) {

				//if the tasks interaction object is this object.
				if (t.TaskObjectTurnOnOff == taskObjectTurnOnOff) { //you've completed this task.

					if (t.Type == Task.TaskType.TurnOff) {

						//you've just completed the task.
						Debug.Log("Completed Task");

						t.State = Task.CompleteState.completed;
					}
				}
			}
		}
	}
}

 
