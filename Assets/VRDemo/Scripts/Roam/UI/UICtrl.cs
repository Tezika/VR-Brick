using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using VRStandardAssets.Utils;
using VRDemo.Common;

namespace VRDemo.Game.Roam.UI
{
	public class UICtrl : MonoBehaviour {


		[SerializeField]private UIFader _introUI;
		[SerializeField]private UIFader _playUI;
		[SerializeField]private UIFader _playUI_tip;
		[SerializeField]private UIFader _outroUI;
		[SerializeField]private GameObject _operationCanvas;

		public IEnumerator showIntroUI(){
			yield return StartCoroutine (this._introUI.InteruptAndFadeIn ());
		}
		public IEnumerator hideIntroUI(){
			yield return StartCoroutine (this._introUI.InteruptAndFadeOut());
		}
		public IEnumerator showPlayUI ()
		{
			//prevent the before play to move;
			this._operationCanvas.SetActive (true);
			yield return StartCoroutine (this._playUI.InteruptAndFadeIn ());
		  
		}
			
		public IEnumerator hidePlayUI ()
		{
			yield return StartCoroutine (this._playUI.InteruptAndFadeOut ());
		}
		public IEnumerator showEndUI(){
			yield return StartCoroutine (this._outroUI.InteruptAndFadeIn ());
		}
		public IEnumerator hideEndUI(){
			yield return StartCoroutine (this._outroUI.InteruptAndFadeOut ());
			
		}
	    
	}

}
