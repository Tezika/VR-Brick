using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VRDemo.Common;
namespace VRDemo.Game.Brick.Hand
{
	public class HandCtrl : MonoBehaviour {
		[SerializeField]private CapsuleHand _leftHand;
		[SerializeField]private CapsuleHand _rightHand;
		[SerializeField]private bool _isLeftCatch = false;
		[SerializeField]private bool _isRightCatch = false;


		private GestureType _leftHandGes;
		private GestureType _rightHandGes;


		private Dictionary<CapsuleHand,GestureType> _hand2GestureMap = new Dictionary<CapsuleHand, GestureType>();
		private Dictionary<string,CapsuleHand> _tag2HandMap =new Dictionary<string, CapsuleHand>();
		private Dictionary<CapsuleHand,bool> _hand2isCatchMap =new Dictionary<CapsuleHand, bool>();


		void Awake(){
			this._hand2GestureMap[this._leftHand] = this._leftHandGes;
			this._hand2GestureMap [this._rightHand] = this._rightHandGes;
			this._tag2HandMap [SeeionDataCtrl.LeftHand] = this._leftHand;
			this._tag2HandMap [SeeionDataCtrl.RightHand] = this._rightHand;
			this._hand2isCatchMap.Add (this._leftHand, this._isLeftCatch);
			this._hand2isCatchMap.Add (this._rightHand, this._isRightCatch);

		}
		// Use this for initialization
		void Start () {
			
		}
		// Update is called once per frame
		void Update () {
			this._leftHandGes = this._leftHand.getGesture ();
			this._rightHandGes = this._rightHand.getGesture ();
//			Debug.Log ("right hand gesture is :" + _rightHandGes);
			if (this._isLeftCatch)
				this._leftHand.updateTarget ();
			if (this._isRightCatch)
				this._rightHand.updateTarget ();
		}
		public bool isHandCatch(string tag){
			return isHandCatch (getHandByName (tag));
		}
		public bool isHandCatch(CapsuleHand hand){
			return this._hand2isCatchMap [hand];
		}
		public GestureType getGestureType(CapsuleHand hand){
			Debug.Log (this._hand2GestureMap [hand]);
			return this._hand2GestureMap [hand];
		}
		public GestureType getGestureType(string tag){
			return getGestureType (getHandByName (tag));
		}
	    public CapsuleHand getHandByName(string tag){
			Debug.Log (this._tag2HandMap [tag].ToString ());
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
