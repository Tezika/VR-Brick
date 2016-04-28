using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class ShooterTurningCtrl : MonoBehaviour
{
	
	[SerializeField] private float m_Damping = 0.2f;
	// Used to smooth the rotation of the transform.
	[SerializeField] private float m_MaxYRotation = 360f;
	// The maximum amount the transform can rotate around the y axis.
	[SerializeField] private float m_MinYRotation = -360f;
	// The maximum amount the transform can rotate around the y axis in the opposite direction.


	private const float k_ExpDampCoef = -20f;
	void FixedUpdate(){
		// Store the Euler rotation of the gameobject.
		Vector3 eulerRotation;

		// Set the rotation to be the same as the user's in the y axis.
		eulerRotation.x = 0;
		eulerRotation.z = 0;
		eulerRotation.y = InputTracking.GetLocalRotation (VRNode.Head).eulerAngles.y;

		// Add 360 to the rotation so that it can effectively be clamped.
		if (eulerRotation.y < 270)
			eulerRotation.y += 360;

		// Clamp the rotation between the minimum and maximum.
		eulerRotation.y = Mathf.Clamp (eulerRotation.y, 360 + m_MinYRotation, 360 + m_MaxYRotation);

		// Smoothly damp the rotation towards the newly calculated rotation.
		this.transform.rotation = Quaternion.Lerp (this.transform.rotation, Quaternion.Euler (eulerRotation),
			m_Damping * (1 - Mathf.Exp (k_ExpDampCoef * Time.deltaTime)));
	}
}
