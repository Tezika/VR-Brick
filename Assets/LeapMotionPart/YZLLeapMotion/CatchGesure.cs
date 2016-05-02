using UnityEngine;
using System.Collections;

namespace YZL.LeapMotion.Algorithm
{

    public class CatchGesure : BaseGesure
    {

        public override bool Check(Transform[] finger, Transform plam = null)
        {
            int count = 0;

            for (int i = 0; i < 5; i ++ )
            {
                Vector3 v = finger[i * 4].position;
                Vector3 u = finger[i * 4 + 1].position;
                Vector3 w = finger[i * 4 + 3].position;
                if (GetAugular(v, u, w) > -0.5f) count++;
            }
            if (count >= 2)
            {
                float cos = Vector3.Dot((finger[3].position - finger[0].position).normalized, (Vector3.Cross(finger[5].position - finger[4].position, finger[7].position - finger[5].position)).normalized);
                if ( Mathf.Abs(cos) < 0.5f) return true;
            }
            return false;
        }

        public override HandType GetType()
        {
            return HandType.Catch;
        }

    }

}

