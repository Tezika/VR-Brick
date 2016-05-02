using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VRDemo.Game.Brick.Hand
{
	public enum GestureType
	{
		//抓取
		Catch,
		//打开
		Open,
		//正常手势
		None
	}
	public class GestureJudge {
		public List<BaseGesture> _gestureList = new List<BaseGesture>();
		//singlon
		private GestureJudge(){}
		private static GestureJudge s_instance;
		public static GestureJudge Instance{
			get{ 
				if (s_instance == null) {
					s_instance = new GestureJudge ();
					s_instance.init ();
				} 
				return s_instance;
			}
		}
		void init(){
			this._gestureList.Add (new OpenGesture ());
			this._gestureList.Add (new CatchGesture ());
		}
		//get a gesture type
		public GestureType checkAGesture(Transform[] fingerJoints,Transform palm){
			if (fingerJoints == null || palm == null)
				return GestureType.None;
			if(fingerJoints.Length == 20 && fingerJoints[0]!= null )
			{
				for (int i = 0; i < this._gestureList.Count; i++)
				{
					if (this._gestureList[i].checkTheGesture(fingerJoints,palm))
					{
						return this._gestureList[i].getType();
					}
				}
			}
			return GestureType.None;
		}
	}

}
