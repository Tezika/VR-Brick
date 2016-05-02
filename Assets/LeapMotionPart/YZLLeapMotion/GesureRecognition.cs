using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace YZL.LeapMotion.Algorithm
{
     public enum HandType
    {
         Normal,
         Catch,
         Good,
         Splint,
         Open,
    }
     public class GesureRecognition
     {

         private List<BaseGesure> gesure;

         private static GesureRecognition _instance = null;
         public static GesureRecognition Instance
         {
             get
             {
                 if (_instance == null)
                 {
                     _instance = new GesureRecognition();
                     _instance.Init();
                 }
                 return _instance;
             }
         }

         public void Init()
         {
             gesure = new List<BaseGesure>();
             gesure.Add(new CatchGesure());
             gesure.Add(new GoodGesure());
             gesure.Add(new SplintGesure());
             gesure.Add(new OpenGesure());
         }

         public HandType CheckGesure(Transform[] finger, Transform plam)
         {
             if (finger == null) return HandType.Normal;
             if(finger.Length == 20 && finger[0]!= null )
             {
                 for (int i = 0; i < gesure.Count; i++)
                 {
                     if (gesure[i].Check(finger,plam))
                     {
                         return gesure[i].GetType();
                     }
                 }
             }

             return HandType.Normal;
         }
     }
	
}

