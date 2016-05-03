using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using VRDemo.Common;
namespace VRDemo.Game.Brick.Hand
{
	public class HandCtrl : MonoBehaviour {
		public event Action onHandInRange;
		[SerializeField]private CapsuleHand _leftHand;
		[SerializeField]private CapsuleHand _rightHand;
		[SerializeField]private bool _isLeftCatch = false;
		[SerializeField]private bool _isRightCatch = false;
		[SerializeField]private DetectionCtrl _dectCtrl;


		[SerializeField]private GestureType _leftHandGes;
		[SerializeField]private GestureType _rightHandGes;


		private Dictionary<CapsuleHand,GestureType> _hand2GestureMap = new Dictionary<CapsuleHand, GestureType>();
		private Dictionary<string,CapsuleHand> _tag2HandMap =new Dictionary<string, CapsuleHand>();
		private Dictionary<CapsuleHand,bool> _hand2isCatchMap =new Dictionary<CapsuleHand, bool>();


		void Awake(){
			this._hand2GestureMap[this._leftHand] = this._leftHandGes; //ENUM： xxx
			this._hand2GestureMap [this._rightHand] = this._rightHandGes;
			this._tag2HandMap [SeeionDataCtrl.LeftHand] = this._leftHand;
			this._tag2HandMap [SeeionDataCtrl.RightHand] = this._rightHand;
			this._hand2isCatchMap.Add (this._leftHand, this._isLeftCatch);
			this._hand2isCatchMap.Add (this._rightHand, this._isRightCatch);

		}
		void OnEnable(){
			this._dectCtrl.onHandInDetection += handleOnHandIndetection;
		}
		void handleOnHandIndetection(){
			Debug.Log("on hand in detection range");
			if (this.onHandInRange != null) {
				this.onHandInRange ();
			}
		}
		void OnDisable(){
			this._dectCtrl.onHandInDetection -= handleOnHandIndetection;
			this._leftHand.enabled = false;
			this._rightHand.enabled = false;
		}
		// Use this for initialization
		void Start () {
			
		}
		// Update is called once per frame
		void Update () {
			//update the hand mode
			this._leftHandGes = this._leftHand.getGesture ();
			this._hand2GestureMap [this._leftHand] = this._leftHandGes;
			this._rightHandGes = this._rightHand.getGesture ();
			this._hand2GestureMap [this._rightHand] = this._rightHandGes;
			this._leftHand.updateTarget ();
			this._rightHand.updateTarget ();
		}
		public bool isHandCatch(string tag){
			return isHandCatch (getHandByName (tag));
		}
		public bool isHandCatch(CapsuleHand hand){
			return this._hand2isCatchMap [hand];
		}
		public GestureType getGestureType(CapsuleHand hand){
			return this._hand2GestureMap [hand];
		}
		public GestureType getGestureType(string tag){
			return getGestureType (getHandByName (tag));
		}
	    public CapsuleHand getHandByName(string tag){
//			Debug.Log (this._tag2HandMap [tag].ToString ());
			return this._tag2HandMap [tag];
		}
		public void toggleHandIsCatch(CapsuleHand hand){
			this._hand2isCatchMap [hand] = !this._hand2isCatchMap [hand];
		}
		public void toggleHandIsCatch(string tag){
			toggleHandIsCatch (getHandByName (tag));
		}
	}


}
