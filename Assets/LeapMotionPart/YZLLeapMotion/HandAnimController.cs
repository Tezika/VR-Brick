using UnityEngine;
using System.Collections;
using YZL.LeapMotion.Algorithm;


public enum AnimaState
{
    Play,
    Pause,
}

public class HandAnimController : MonoBehaviour {


    public static HandAnimController _instance = null;

    public CapsuleHand leftHand;
    public CapsuleHand rightHand;

    public GameObject[] targetArray;
    
    private int index = -1;
    private CapsuleHand nowHand;

    public AnimaState state;
    public Animator anim;

    public float pauseTime = 0;
    public float animaspeed = 0.2f;
    private bool playanimas = false;//应该播放动画的标志
    private bool animaend = false;//动画end
    void Awake()
    {
        _instance = this;
       // StartCoroutine(Pause());
        anim = GetComponent<Animator>();

        GoToNext();
    }

    void Update()
    {
        if (Time.time >= pauseTime)
        {
            state = AnimaState.Pause;
            anim.speed = 0;           
        }
    }
    public void GoToNext()
    {
        index++;
    }

    public void GoOn()
    {
        pauseTime = Time.time + 0.5f;
        state = AnimaState.Play;
        anim.speed = animaspeed;
    }


    //public IEnumerator Pause()
    //{
    //    print(Time.time);
    //    if (Time.time >= pauseTime)
    //    {
    //        state = AnimaState.Pause;
    //        anim.speed = 0;
    //        yield break;
    //    }
    //    else
    //    {
    //        yield return new WaitForSeconds(3f);
    //        if (Time.time >= pauseTime)
    //        {
    //            state = AnimaState.Pause;
    //            anim.speed = 0;
    //            yield break;
    //        }
    //    }
    //}

    public void CheckState(GameObject go,string handName)
    {
        if(handName == "LeftHand")
        {
            nowHand = leftHand;
        }
        else if( handName == "RightHand")
        {
            nowHand = rightHand;
        }
        if(nowHand.GetGesure() == HandType.Catch)
        {
            if(go == targetArray[index])
            {
                GoOn();
                print("Go on 0.3s");
            }
            //else
            //{
            //    StartCoroutine(Pause());
            //}
        }
        //else
        //{
        //    StartCoroutine(Pause());
        //}
    }

}
