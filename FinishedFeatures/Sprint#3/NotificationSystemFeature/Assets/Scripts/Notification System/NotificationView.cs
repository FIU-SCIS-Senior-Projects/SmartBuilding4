using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NotificationView : MonoBehaviour 
{

	[SerializeField]CanvasGroup notificationPanel;
	[SerializeField]Text questDetails;
	[SerializeField]Button[] questInfo;
	bool enabledWindow;

	#region Unity 
	// Use this for initialization
	void Start () {
	
		enabledWindow = false;
		notificationPanel.alpha = 0;
	}
	#endregion

	#region Custom Methods
	public void ViewQuestInfo(int i )
	{
		//questInfo[i]
	}

	public void EnableNotificationPanel()
	{
		enabledWindow = true;
		StartCoroutine(PanelFade());
	}

	public void DisableNotificationPanel()
	{
		enabledWindow = false;
		StartCoroutine(PanelFade());
	}

	IEnumerator PanelFade()
	{
		float targetAlpha = enabledWindow ? 1 : 0;
		int modifier = enabledWindow ? 1: -1;

		while((notificationPanel.alpha < targetAlpha && enabledWindow)
			|| (notificationPanel.alpha > targetAlpha && !enabledWindow))
		{
			notificationPanel.alpha += Time.deltaTime * modifier;
			yield return null;
		}

		yield return null;
	}
	#endregion

	#region Getters/Setters
	public bool WindowState
	{
		get{return enabledWindow;}
		set{enabledWindow = value;}
	}

	public string QuestDetails
	{
		get{return questDetails.text;}
		set{questDetails.text = value;}
	}
	#endregion
}
