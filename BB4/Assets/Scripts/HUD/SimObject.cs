using UnityEngine;
using System.Collections;


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

}

 
