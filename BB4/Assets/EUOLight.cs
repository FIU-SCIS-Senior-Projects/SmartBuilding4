using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnergyUsingObject))]
public class EUOLight : MonoBehaviour {

	[SerializeField] public Light light;
	EnergyUsingObject euo;

	void Awake() {
		euo = GetComponent<EnergyUsingObject>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (light != null) {

			if (euo.getIsPoweredOn()) {
				light.enabled = true;
			}
			else light.enabled = false;

		}

	}
}
