using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Linq;

public class SimulationManager {

	//the private instance.
	private static SimulationManager sm;

	//important objects in any scene.
	public HUDController hud;
	public TimeTrackerController timeTracker;
	public TimeScaleController timeScale;


	//simulation starting settings.
	public string startTimeOfDay;
	public int startRunTimeInsSeconds;


	//important info gathered during simulation.
	int lastSavedSimTime;
	float lastSavedTotalEnergyUsage;

	List<Task> taskList = new List<Task>();



	/// <summary>
	/// Gets the shared sim manager.
	/// Returns a singleton instance.
	/// </summary>
	/// <value>The shared sim manager.</value>
	public static SimulationManager sharedSimManager {
		get {
			if (sm == null) {
				sm = new SimulationManager();
			}
			return sm;
		}
	}
	private SimulationManager() {

	}


	/// <summary>
	/// Gets the simulation run time.
	/// </summary>
	/// <returns>The simulation run time.</returns>
	public int getSimulationRunTime() {
		if (timeTracker != null) {
			string timeString = timeTracker.getSimTime(TimeTrackerController.TimeFormat.sec);
			int time = int.Parse( timeString );
			lastSavedSimTime = time;
			return time;
		}
		else {
			return lastSavedSimTime;
		}
	}

	/// <summary>
	/// Gets the simulation total energy usage.
	/// </summary>
	/// <returns>The simulation total energy usage.</returns>
	public float getSimulationTotalEnergyUsage() {
		//get all objects with plugload controller attached.
		PlugLoadController[] plugLoads = PlugLoadController.getAllPlugLoads();
		if (plugLoads.Length > 0) {
			//loop and store aggregate into one number.
			float total = 0;
			foreach (PlugLoadController plc in plugLoads) {
				total += plc.getAggregateUsage();
			}
			lastSavedTotalEnergyUsage = total;
			return total;
		}
		else {
			return lastSavedTotalEnergyUsage;
		}

	}

	/// <summary>
	/// Gets the list of tasks.
	/// given specific task completion state.
	/// </summary>
	/// <returns>The list of tasks.</returns>
	/// <param name="state">State.</param>
	public List<Task> getListOfTasks(Task.CompleteState state) {
		List<Task> tasks = new List<Task>();

		foreach(Task t in taskList) {
			if (t.State == state) {
				tasks.Add(t);
			}
		}

		return tasks;
	}
	/// <summary>
	/// Gets the list of tasks.
	/// no matter the completeion state.
	/// </summary>
	/// <returns>The list of tasks.</returns>
	public List<Task> getListOfTasks() {
		return taskList;
	}




}
