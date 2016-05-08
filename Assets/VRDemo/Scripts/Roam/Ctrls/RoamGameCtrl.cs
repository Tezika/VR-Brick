using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using VRDemo.Common;
using VRDemo.Game.Roam.UI;
using VRStandardAssets.Utils;
namespace VRDemo.Game.Roam.Ctrls
{
	public class RoamGameCtrl : MonoBehaviour {
		[SerializeField]private SeeionDataCtrl.GameType _gameType;
		[SerializeField]private SelectionSliderCtrl _slider;
		[SerializeField]private SelectionSliderCtrl _quitSlider;
		[SerializeField]private Reticle _reticle;
		[SerializeField]private SelectionRadial _radial;
		[SerializeField]private InputWarnings _inputWarnings;
		[SerializeField]private UICtrl _uiCtrl;

		private bool _isPlayed = false;
		void OnEnable(){
			this._slider.onBarFilledIenumerator += handlePlaySliderFilled;
			this._quitSlider.onBarFilledIenumerator += handleQuitSliderFilled;
		}
		void OnDisable(){
			this._slider.onBarFilledIenumerator -= handlePlaySliderFilled;
			this._quitSlider.onBarFilledIenumerator -= handleQuitSliderFilled;
		}
		IEnumerator Start(){
			SeeionDataCtrl.SetGameType (this._gameType);
			yield return StartCoroutine (startPhase ());
		}
		IEnumerator startPhase(){
			this._radial.Hide ();
			this._reticle.Show ();
			yield return StartCoroutine (this._uiCtrl.showIntroUI ());

		}
		IEnumerator playPhase(){
			this._reticle.Hide ();
			this._radial.Show ();
			yield return null;
		}
		IEnumerator endPhase(){
			yield return null;
		}

		IEnumerator handlePlaySliderFilled(){
			if (!this._isPlayed) {
				this._isPlayed = true;
				yield return StartCoroutine (this._uiCtrl.hideIntroUI ());
				yield return StartCoroutine (this._uiCtrl.showPlayUI ());
				yield return StartCoroutine (this.playPhase ());
			}
		}
		IEnumerator handleQuitSliderFilled(){
			yield return StartCoroutine (this._uiCtrl.hideIntroUI ());
			SceneManager.LoadScene (SeeionDataCtrl.BrickSceneIdx);
			yield return null;
		}

	}

}
