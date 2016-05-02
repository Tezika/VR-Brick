using UnityEngine;
using System.Collections;
using YZL.LeapMotion.Algorithm;
public static class Expand  {
    public static HandType GetGesure(this CapsuleHand hand)
    {
        if(hand != null)
            return GesureRecognition.Instance.CheckGesure(hand._jointSpheres,hand.palm);
        else
            return GesureRecognition.Instance.CheckGesure(null,null);
    }

    public static void SetReceptor(this CapsuleHand hand, Transform target,int type)
    {
        if(type == 1)
        {
            target.parent = hand._jointSpheres[11];
        }
        else if(type == 2)
        {
            target.parent = hand.palmPositionSphere;
            hand.target = target;
        }

    }

    public static void UpdateTarget(this CapsuleHand hand)
    {
        if(hand.target != null)
        {
            hand.target.rotation = hand.palm.rotation;
          hand.target.Rotate(new Vector3(0, 1, 0), -60);
        }
           
        
    }


} 
