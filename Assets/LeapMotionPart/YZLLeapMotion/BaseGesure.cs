using UnityEngine;
using System.Collections;
using VRDemo.Game.Brick.Hand;
namespace YZL.LeapMotion.Algorithm
{

    public abstract class BaseGesure
    {

        public abstract bool Check(Transform[] finger,Transform plam = null);
		public abstract HandType GetType();


        public float GetAugular(Vector3 one,Vector3 two,Vector3 three)
        {
            Vector3 vec_1 = one - two;
            Vector3 vec_2 = three - two;

            return Vector3.Dot(vec_1.normalized, vec_2.normalized);
        }
    }

}

