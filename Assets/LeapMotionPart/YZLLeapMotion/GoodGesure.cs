using UnityEngine;
using System.Collections;
using YZL.LeapMotion.Algorithm;

public class GoodGesure : BaseGesure
{

    public override bool Check(Transform[] finger, Transform plam = null)
    {
        int count = 0;
        for (int i = 1; i < 5; i++)
        {
            Vector3 v = finger[i * 4].position;
            Vector3 u = finger[i * 4 + 1].position;
            Vector3 w = finger[i * 4 + 3].position;
            if (GetAugular(v, u, w) > -0.5f) count++;
        }
        if (count >= 3)
        {
            Vector3 v = finger[0].position;
            Vector3 u = finger[1].position;
            Vector3 w = finger[3].position;
            if (GetAugular(v, u, w) < -0.85f)
            {
                float cos = Vector3.Dot((finger[3].position - finger[0].position).normalized, (Vector3.Cross(finger[5].position - finger[4].position, finger[7].position - finger[5].position)).normalized);
                if (Mathf.Abs(cos) > 0.5f) return true;
            }
        }
        return false;
    }

    public override HandType GetType()
    {
        return HandType.Good;
    }

}
