using System;
using UnityEngine;
namespace VRDemo.Game.Brick.Hand
{
	public class ThumbGesture:BaseGesture
	{
		public override bool checkTheGesture (Transform[] fingerJoints, UnityEngine.Transform palm){
//			throw new NotImplementedException ();
			uint count = 0;
			for (uint i = 1; i < 5; ++i) {
				Vector3 v = fingerJoints [4 * i].position;
				Vector3 u = fingerJoints [4 * i + 1].position;
				Vector3 w = fingerJoints [4 * i + 3].position;
				if (getDotFrommThreeVec (v, u, w) > -0.5f)
					count++;
			}
			if (count >= 3) {
				//thumb is vertical ?
				if(getDotFrommThreeVec(fingerJoints[0].position,fingerJoints[1].position,fingerJoints[3].position) < 0.85f){
					float cos = Vector3.Dot((fingerJoints[3].position - fingerJoints[0].position).normalized, (Vector3.Cross(fingerJoints[5].position - fingerJoints[4].position, fingerJoints[7].position - fingerJoints[5].position)).normalized);
					if (Mathf.Abs(cos) > 0.5f) return true;
				}
			}
			return false;	
		}
		public override GestureType getType ()
		{
			return GestureType.Thumb;
		}
	}
}

