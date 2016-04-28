using UnityEngine;
using System.Collections;
using System;
namespace VRStandardAssets.Utils{
	public class VRInputForKeyBoard : MonoBehaviour {
		public event Action onKeyWDown;
		public event Action onKeyWUp;
		public event Action onKeySDown;
		public event Action onKeySUp;
		public event Action onKeyADown;
		public event Action onKeyAUp;
		public event Action onKeyDDown;
		public event Action onKeyDUp;

//		// Use this for initialization
//		void Start () {
//
//		}

		// Update is called once per frame
		void Update () {
			this.checkKeyBoardInput ();
		}
		//check the input for keyboard
		void checkKeyBoardInput(){
//			Debug.Log ("check the input");
			//W
			if (Input.GetKeyDown ("w")) {
				if (onKeyWDown != null) {
					onKeyWDown ();
				}
			}
			if (Input.GetKeyUp ("w")) {
				if (onKeyWUp != null) {
					onKeyWUp ();
				}
			}
			//S
			if (Input.GetKeyDown ("s")) {
				if (onKeySDown != null) {
					onKeySDown ();
				}
			}
			if (Input.GetKeyUp ("s")) {
				if (onKeySUp != null) {
					onKeySUp ();
				}
			}
			//A
			if (Input.GetKeyDown ("a")) {
				if (onKeyADown != null) {
					onKeyADown ();
				}
			}
			if (Input.GetKeyUp ("a")) {
				if (onKeyAUp != null) {
					onKeyAUp ();
				}
			}
			//D
			if (Input.GetKeyDown ("d")) {
				if (onKeyDDown != null) {
					onKeyDDown ();
				}
			}
			if (Input.GetKeyUp ("d")) {
				if (onKeyDUp != null) {
					onKeyDUp ();
				}
			}
			
		}
		void OnDestory(){
			onKeyWDown = null;
			onKeyWUp = null;
			onKeySDown = null;
			onKeySUp = null;
			onKeyADown =  null;
			onKeyAUp = null;
			onKeyDDown = null;
			onKeyDUp = null;
		}
	}

}

