using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class LaptopScreen : MonoBehaviour {

	EnergyUsingObject tv;
	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		tv = transform.parent.parent.parent.GetComponent<EnergyUsingObject>();
		if (tv == null) {

			Debug.LogError("Laptop SCREEN IS NOT A CHILD OF THE of the laptop screen....idk!!!!!");
		}
		sprite = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		if (tv.getIsPoweredOn()) {
			sprite.enabled = true;
		}

		else {

			sprite.enabled = false;
		}
	}
}