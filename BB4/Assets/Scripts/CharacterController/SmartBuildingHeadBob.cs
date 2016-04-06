using System;
using UnityEngine;
using UnityStandardAssets.Utility;

public class SmartBuildingHeadBob : MonoBehaviour
{
    public Camera Camera;
    public CurveControlledBob motionBob = new CurveControlledBob();
    public LerpControlledBob jumpAndLandingBob = new LerpControlledBob();
	public SmartBuildingCharacterController ctrller;
    public float StrideInterval;

    [Range(0f, 1f)] public float RunningStrideLengthen;

   // private CameraRefocus m_CameraRefocus;
    private bool m_PreviouslyGrounded;
    private Vector3 m_OriginalCameraPosition;


    private void Start()
    {
        motionBob.Setup(Camera, StrideInterval);
        m_OriginalCameraPosition = Camera.transform.localPosition;
   //     m_CameraRefocus = new CameraRefocus(Camera, transform.root.transform, Camera.transform.localPosition);
    }


    private void Update()
    {
      //  m_CameraRefocus.GetFocusPoint();
        Vector3 newCameraPosition;
		if (ctrller.rigidBody.velocity.magnitude > 0)
        {
			Camera.transform.localPosition = motionBob.DoHeadBob(ctrller.rigidBody.velocity.magnitude);
            newCameraPosition = Camera.transform.localPosition;
            newCameraPosition.y = Camera.transform.localPosition.y - jumpAndLandingBob.Offset();
        }
        else
        {
            newCameraPosition = Camera.transform.localPosition;
            newCameraPosition.y = m_OriginalCameraPosition.y - jumpAndLandingBob.Offset();
        }
        Camera.transform.localPosition = newCameraPosition;

        if (!m_PreviouslyGrounded)
        {
            StartCoroutine(jumpAndLandingBob.DoBobCycle());
        }

		m_PreviouslyGrounded = ctrller.grounded;
      //  m_CameraRefocus.SetFocusPoint();
    }
}

