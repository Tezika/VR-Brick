using UnityEngine;
using System.Collections;
using YZL.LeapMotion.Algorithm;
public class HandManager : MonoBehaviour {

    public CapsuleHand leftHand;
    public CapsuleHand rightHand;

    public HandType leftHandType;
    public HandType rightHandType;

    public bool left = false;
    public bool right = false;

    public static HandManager _instance;

    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        leftHandType = leftHand.GetGesure();
        rightHandType = rightHand.GetGesure();
        leftHand.UpdateTarget();
        rightHand.UpdateTarget();
    }

    public bool HaveCath(CapsuleHand hand)
    {
        if (hand == leftHand) return left;
        else return right;
    }
    public bool HaveCath(string name)
    {
        if (GetHand(name) == leftHand) return left;
        else return right;
    }

    public HandType GetHandType(string name)
    {
        if (name == "LeftHand")
        {
            return leftHandType;
        }
        else
        {
            return rightHandType;
        }
    }
    public CapsuleHand GetHand(string name)
    {
        if(name == "LeftHand")
        {
            return leftHand;
        }
        else if(name == "RightHand")
        {
            return rightHand;
        }
        return null;
    }

}
