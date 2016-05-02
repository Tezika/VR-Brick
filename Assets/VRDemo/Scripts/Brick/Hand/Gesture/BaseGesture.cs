using UnityEngine;
using System.Collections;
namespace VRDemo.Game.Brick.Hand
{
	public abstract class BaseGesture {
		public abstract bool checkTheGesture (Transform[] fingerJoints, Transform palm = null);
		public abstract GestureType getType ();
		//util func
		public static  float getDotFrommThreeVec(Vector3 first,Vector3 middle,Vector3 end){
			return Vector3.Dot((first - middle).normalized,(end - middle).normalized);
		}
	}
}
