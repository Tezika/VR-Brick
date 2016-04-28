using UnityEngine;
using UnityEngine.VR;
using System.Collections;

namespace VRStandardAssets.Utils
{
	public class VRRotationCtrl : MonoBehaviour{
		[SerializeField] private float m_Damping = 0.2f;
		// Used to smooth the rotation of the transform.
		[SerializeField] private float m_MaxYRotation = 20f;
		// The maximum amount the transform can rotate around the y axis.
		[SerializeField] private float m_MinYRotation = -20f;
		// The maximum amount the transform can rotate around the y axis in the opposite direction.

		private const float k_ExpDampCoef = -20f;
		// Update is called once per frame
		void Update (){
			//get purpose rotation for parent;
			Vector3 pEurRotation;
			//only rotate by y axis;
			pEurRotation.x = 0;
			pEurRotation.z = 0;
			pEurRotation.y = InputTracking.GetLocalRotation (VRNode.Head).eulerAngles.y;
			if (pEurRotation.y < 270)
				pEurRotation.y += 360;

			pEurRotation.y = Mathf.Clamp (pEurRotation.y, m_MinYRotation + 360, m_MaxYRotation + 360);
			// Smoothly damp the rotation towards the newly calculated rotation.
			transform.parent.rotation =  Quaternion.Lerp (transform.parent.rotation, Quaternion.Euler (pEurRotation),
				m_Damping * (1 - Mathf.Exp (k_ExpDampCoef * Time.deltaTime)));
			Debug.Log (transform.parent.rotation.eulerAngles.y + "......" + pEurRotation.y);
		}
	}
}