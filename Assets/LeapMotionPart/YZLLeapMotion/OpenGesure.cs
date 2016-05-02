using UnityEngine;
using System.Collections;
using YZL.LeapMotion.Algorithm;

public class OpenGesure : BaseGesure
{

    public override bool Check(Transform[] finger, Transform plam = null)
    {
        int count = 0;
        for(int i = 0 ; i < 4 ; i ++)
        {
            float cos = Vector3.Dot((finger[i * 4 + 3].position - finger[i * 4].position).normalized, (Vector3.Cross(finger[i * 4 + 5].position - finger[i * 4 + 4].position, finger[i * 4 + 7].position - finger[i * 4 + 5].position)).normalized);
            if (Mathf.Abs(cos) <  0.2f) count++;
        }
        float cos1 = Vector3.Dot((finger[0].position - finger[4].position).normalized, (finger[7].position - finger[5].position).normalized);
        if (cos1 < -0.8f)
        {
            if (count >= 3) return true; 
        }
        
        return false;
    }

    public override HandType GetType()
    {
        return HandType.Open;
    }
}
