using UnityEngine;
using System.Collections;

namespace YZL.LeapMotion.Algorithm
{

    public class SplintGesure : BaseGesure
    {
        public override bool Check(Transform[] finger,Transform plam = null)
        {
            int count = 0;

            for (int i = 1; i < 5; i ++ )
            {
                float dis = Vector3.Distance(finger[3].position, finger[i * 4 + 3].position);
                if (dis <= 0.023f) count++;
            }
            if(count >= 3)
            {
                if(plam.up.y >= 0.8f)
                {
                    return true;
                }
            }
            return false;
        }

        public override HandType GetType()
        {
            return HandType.Splint;
        }

    }

}
