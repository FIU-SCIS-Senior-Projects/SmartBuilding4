using UnityEngine;
using System.Collections;

public class TaskStart : MonoBehaviour {

	void Awake() {



	}

	// Use this for initialization
	void Start () {
	
		SimulationManager.sharedSimManager.TimeTracker.onOneSecondPassed += OneSecond;

	}


	void OneSecond(float time) {


		float realTime = time - SimulationManager.sharedSimManager.TimeTracker.getSimStartTime();




		foreach(Task t in SimulationManager.sharedSimManager.getListOfTasks()) {
			if (t.State == Task.CompleteState.completed)
				break;
			
			if (t.StartTime == realTime) {
				if (t.State == Task.CompleteState.neverStarted) {
					t.State = Task.CompleteState.inProgress;
					Debug.Log("Task Has Started");
				
				}
				
			}



		}

	}

}
