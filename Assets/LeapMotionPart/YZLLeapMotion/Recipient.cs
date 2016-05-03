using UnityEngine;
using System.Collections;
using YZL.LeapMotion.Algorithm;
public class Recipient : MonoBehaviour {

    private CapsuleHand hand;
    private Rigidbody rigid;
    private Vector3 offset;

    private Transform parent;

    public bool IsCatched()
    {
        return hand != null;
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        parent = transform.parent;
    }


    public virtual void OnTriggerStay(Collider other)
    {
		//modify by tezika
		if(other.tag == "RightHand")
        {
            if(HandManager._instance.GetHandType(other.tag) == HandType.Catch)
            {
                if (!HandManager._instance.HaveCath(other.tag))
                {
                    hand = HandManager._instance.GetHand(other.tag);

                    HandManager._instance.right = true;
                    if (tag == "Test tube rack")
                    {
                        hand.SetReceptor(transform, 1);
                    }
                    else
                    {
                        hand.SetReceptor(transform, 2);
                        transform.localPosition = new Vector3(-1.16f, 0, -0.57f);
                    }
                        
                    rigid.velocity = Vector3.zero;
                    rigid.angularVelocity = Vector3.zero;
                    rigid.isKinematic = true;
                    rigid.useGravity = false;
                    //offset = transform.localPosition;
                }

            }
            else
            {
                if(hand == HandManager._instance.GetHand(other.tag))
                {
                    hand.target = null;
                    hand = null;
                    transform.parent = parent;
                    HandManager._instance.right = false;
                    rigid.isKinematic = false;
//                    rigid.useGravity = true;

                }
            }
        }
    
    }


    public void OnTriggerExit(Collider other)
    {
        //if (hand == HandManager._instance.GetHand(other.tag))
        //{
        //    if (hand != null)
        //        hand.target = null;
        //    hand = null;
        //    transform.parent = parent;
        //    HandManager._instance.right = false;
        //    rigid.useGravity = true;
        //}
    }

}
