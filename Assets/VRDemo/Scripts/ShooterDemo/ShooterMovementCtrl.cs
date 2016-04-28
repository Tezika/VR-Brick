using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.VR;

namespace VRDemo.Shooter{
	public class ShooterMovementCtrl : MonoBehaviour {
		//shooter move speed miter/per;
		[SerializeField]private float _moveSpeed = 5f;
		//shooter body transform
		[SerializeField]private Transform _bodyTransform;

		private Rigidbody _rig;
		void Awake(){
			_rig = this.GetComponent<Rigidbody> ();
		}
		void Start(){

		}
		void FixedUpdate(){
			float h = Input.GetAxisRaw("Horizontal");
			float v = Input.GetAxisRaw("Vertical");
			Vector3 moveDirection = Vector3.zero;
			if (h > 0) {
				moveDirection = _bodyTransform.right;
			} 
			if (h < 0) {
				moveDirection = -_bodyTransform.right;
			}
			if (v > 0) {
				moveDirection = _bodyTransform.forward;
			}
			if (v < 0) {
				moveDirection = -_bodyTransform.forward;
			}
			_rig.MovePosition (_rig.position + _moveSpeed * moveDirection * Time.fixedDeltaTime);

		}
	}



}
