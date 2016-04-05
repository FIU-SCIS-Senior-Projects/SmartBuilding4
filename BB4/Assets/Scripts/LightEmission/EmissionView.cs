using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EmissionView : MonoBehaviour
{
	[SerializeField]Light[] spotLight;
	[SerializeField]Text button;

	bool _isOn = true;
	Text _buttonText;

	void Start ()
	{
		_buttonText = button;
	}
		// Update is called once per frame
	void Update () 
	{
		if (_isOn) {
			_buttonText.text = "TURN OFF";
		}
		else {
			_buttonText.text = "TURN ON";
			_buttonText.gameObject.SetActive (true);
		}
	}

	public void TextState(bool state){
		_buttonText.gameObject.SetActive (state);
	}

	public void ToggleLight()
	{
		_isOn = !_isOn;
		foreach(Light l in spotLight)
			l.enabled = _isOn;
	}
		
	public bool LightIsOn
	{
		get{return _isOn;}
	}
}
