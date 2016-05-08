using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using VRDemo.Common;
namespace VRDemo.Game.Roam.Ctrls{
	public class RoamInputCtrl : MonoBehaviour {
		public event Action onForwardStart;
		public event Action onForwardEnd;
		public event Action onBackStart;
		public event Action onBackEnd;
		public event Action onLeftStart;
		public event Action onLeftEnd;
		public event Action onRightStart;
		public event Action onRightend;

		private Dictionary<string,Action> _startInputMaps = new Dictionary<string, Action> ();
		private Dictionary<string,Action> _endInputMaps = new Dictionary<string, Action> ();

		void Awake(){
			
		}
		// Use this for initialization
		void Start () {
			//这里可能有坑,需要在onEnable之后再讲Action加入map;
			this.initStartMap ();
			this.initEndMap ();
		}

		// Update is called once per frame
		void Update () {

		}
		public void sendTheInputStartEvent(string name){
			if (this._startInputMaps [name] != null) {
				this._startInputMaps [name] ();
			} else {
				Debug.LogError ("ui obj's name is error");
			}
	 }
		public void sendTheInputEndEvent(string name){
			if (this._endInputMaps [name] != null) {
				this._endInputMaps [name] ();
			} else {
				Debug.LogError ("ui obj's name is error");
			}
		}
		void initStartMap(){
			this._startInputMaps.Add (SeeionDataCtrl.UIForward, onForwardStart);
			this._startInputMaps.Add (SeeionDataCtrl.UIBack, onBackStart);
			this._startInputMaps.Add (SeeionDataCtrl.UILeft, onLeftStart);
			this._startInputMaps.Add (SeeionDataCtrl.UIRight, onRightStart);

		}
		void initEndMap(){
			this._endInputMaps.Add (SeeionDataCtrl.UIForward, onForwardEnd);
			this._endInputMaps.Add (SeeionDataCtrl.UIBack, onBackEnd);
			this._endInputMaps.Add (SeeionDataCtrl.UILeft, onLeftEnd);
			this._endInputMaps.Add (SeeionDataCtrl.UIRight, onRightend);
		}
	}
}

