using UnityEngine;
using System;
using System.Collections;
using VRDemo.Common;
namespace VRDemo.Game.Brick.Hand
{
	public class DetectionCtrl : MonoBehaviour {
		public event Action onHandInDetection;

		void OnTriggerEnter(Collider other){
			
			if (other.gameObject.tag == SeeionDataCtrl.LeftHand || other.gameObject.tag == SeeionDataCtrl.RightHand) {
//				Debug.Log ("on hand enter the detection");
				if (this.onHandInDetection != null) {
					this.onHandInDetection ();
				}
			}
		}
	}

}
