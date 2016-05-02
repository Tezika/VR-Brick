using UnityEngine;
using System.Collections;
namespace VRDemo.Game.Brick.Hand
{
	public static class Extension{
		public static GestureType getGesture(this CapsuleHand hand){
			if (hand != null) {
				return GestureJudge.Instance.checkAGesture (hand._jointSpheres, hand.palm);
			} else {
				return GestureType.None;
			}
		}
		public static void setHandReceiver(this CapsuleHand hand,Transform target){
		     target.parent = hand.palmPositionSphere;
		     hand.target = target;
		}
		public static void updateTarget(this CapsuleHand hand){
			if(hand.target != null){
				hand.target.rotation = hand.palm.rotation; 
				//why?
				hand.target.Rotate(new Vector3(0, 1, 0), -60);
			}
		}
		
	}
}
