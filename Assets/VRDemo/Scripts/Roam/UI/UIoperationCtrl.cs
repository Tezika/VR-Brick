using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using VRStandardAssets.Utils;
using VRDemo.Common;
using VRDemo.Game.Roam.Ctrls;
namespace VRDemo.Game.Roam.UI
{
	public class UIoperationCtrl : MonoBehaviour {
		[SerializeField]private VRInteractiveItem _interactiveItem;
		[SerializeField]private RoamInputCtrl _inputCtrl;
	
		void OnEnable(){
			this._interactiveItem.OnOver += handleOver;
			this._interactiveItem.OnOut += handleOut;
		}
		void OnDisable(){
			this._interactiveItem.OnOver -= handleOver;
			this._interactiveItem.OnOut -= handleOut;
		}
		void handleOver(){
//			Debug.Log ("UI operation over");
			this._inputCtrl.sendTheInputStartEvent (this.gameObject.name);
		}
		void handleOut(){
//			Debug.Log ("UI operation out");
			this._inputCtrl.sendTheInputEndEvent (this.gameObject.name);
		}
	 
	}

}
