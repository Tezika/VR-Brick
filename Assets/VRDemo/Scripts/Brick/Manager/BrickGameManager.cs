using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using VRDemo.Common;
using VRDemo.Game.Brick.UI;
using VRStandardAssets.Utils;

namespace VRDemo.Game.Brick.Manager
{
	public class BrickGameManager : MonoBehaviour {
		[SerializeField]private SeeionDataCtrl.GameType _gameType;
		[SerializeField]private uint  _gameItemNum = 5;  //record the gameObj num
		[SerializeField]private float _gameTime = 30.0f; //the time for finish game
		[SerializeField]private float _endDelayTime = 1.5f; //the time for outro ui
		[SerializeField] private SelectionSlider _selectionSlider;     // Used to confirm the user has understood the intro UI.
		[SerializeField] private Transform _camera;                    
		[SerializeField] private SelectionSlider _quitSelectionSlider;
		[SerializeField] private SelectionRadial _selectionRadial;     // Used to continue past the outro.
		[SerializeField] private Reticle _reticle;  // This is turned on and off when it is required and not. 
		[SerializeField] private Image _timerBar;                      // The time remaining is shown on the UI for the hand, this is a reference to the image showing the time remaining.
		[SerializeField] private Image _progressBar;                      // The time remaining is shown on the UI for the hand, this is a reference to the image showing the time remaining.
		[SerializeField] private UICtrl _uiCtrl;           // Used to encapsulate the UI.
		[SerializeField] private InputWarnings _inputWarnings;         // Tap warnings need to be on for the intro and outro but off for the game itself.
		[SerializeField]private SpwanObjsManager _sManager;
		[SerializeField]private BricksManager _bManager;

		private bool _isPlaying = false;
		private bool _isFinish = false;
		void OnEnable(){
			this._selectionSlider.onBarFilledIEnumerator += handlePlayBarFilled;
			this._quitSelectionSlider.onBarFilledIEnumerator += handleQuitBarFilled;
			this._bManager.onAPartFinish += handleAPartFinish;
			this._bManager.onBuildingFinish += handleBuildingFinish;
		}
		void OnDisable(){
			this._selectionSlider.onBarFilledIEnumerator -= handlePlayBarFilled;
			this._quitSelectionSlider.onBarFilledIEnumerator -= handleQuitBarFilled;
			this._bManager.onAPartFinish -= handleAPartFinish;
			this._bManager.onBuildingFinish -= handleBuildingFinish;
		}
		IEnumerator handlePlayBarFilled(){
			Debug.Log ("receive the event for filled bar");
			//turn off waring;
			this._inputWarnings.TurnOffSingleTapWarnings();
			this._inputWarnings.TurnOffDoubleTapWarnings ();
			yield return StartCoroutine (this._uiCtrl.hideIntroUI ());
			yield return StartCoroutine (this.playPhase ());
			yield return StartCoroutine (this.endPhase ());
		}
		IEnumerator handleQuitBarFilled(){
			Debug.Log ("Quit Game");
			yield return null;
		}

		IEnumerator Start(){
			SeeionDataCtrl.SetGameType (_gameType);
			yield return StartCoroutine (startPhase ());
//			yield return StartCoroutine (playPhase ());
//			yield return StartCoroutine (endPhase ());
		}
		IEnumerator startPhase(){
			yield return StartCoroutine (this._uiCtrl.showIntroUI());
			this._reticle.Show();
			this._selectionRadial.Hide ();
			//turn on input warning;
			this._inputWarnings.TurnOnDoubleTapWarnings ();
			this._inputWarnings.TurnOnSingleTapWarnings ();

		}
		IEnumerator playPhase(){
//			this._reticle.Hide ();
			this._sManager.spwanObjs();
			this._isPlaying = true;
			yield return StartCoroutine (this._uiCtrl.showPlayUI ());
			yield return StartCoroutine (this.playUpdate ());
			yield return StartCoroutine (this._uiCtrl.hidePlayUI ());
		}
		IEnumerator endPhase(){
			this._selectionRadial.Show ();
			this._isPlaying = false;
			yield return StartCoroutine (this._uiCtrl.showOutroUI ());
		}
		IEnumerator playUpdate(){
			//set the timer;
			float gameTimer = this._gameTime;
			while (gameTimer > 0 && ! this._isFinish) {
				gameTimer -= Time.deltaTime;
				this._timerBar.fillAmount = gameTimer / this._gameTime;
				yield return null;
			}

		}
		IEnumerator handleAPartFinish(){
			this._progressBar.fillAmount += 1.0f / (this._bManager.NumOfParts - 1);
			yield return null;
		}
		IEnumerator handleBuildingFinish(){
			this._progressBar.fillAmount = 1;
			this._isFinish = true;
			yield return null;
		}
	}
}
