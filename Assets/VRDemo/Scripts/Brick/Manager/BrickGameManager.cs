﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UnityEngine.UI;
using VRDemo.Common;
using VRStandardAssets.Utils;
using VRDemo.Game.Brick.Hand;
using VRDemo.Game.Brick.UI;
namespace VRDemo.Game.Brick.Manager
{
	public class BrickGameManager : MonoBehaviour {
		public event Action onGameOver;
		public event Action onGameFinish;

		[SerializeField]private  HandCtrl _hctrl;
		[SerializeField]private SeeionDataCtrl.GameType _gameType;
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
		[SerializeField]private Animator _bricksAnimator;
		[SerializeField]private float _aniDelayTime = 2.0f;
		[SerializeField]private float _aniUIAppearTime = 3.0f;

		//already played the  game?
		private bool _isPlayed = false;
		//finish the game?
		private bool _isFinish = false;
		void OnEnable(){
			this._selectionSlider.onBarFilledIEnumerator += handlePlayBarFilled;
			this._quitSelectionSlider.onBarFilledIEnumerator += handleQuitBarFilled;
			this._bManager.onAPartFinish += handleAPartFinish;
			this._bManager.onBuildingFinish += handleBuildingFinish;
			this._sManager.onSpwanObjReady += handleSpwanObjsReady;
			this._bManager.onBrickAniFinish += handleBrickStratAniFinish;
		}
		void OnDisable(){
			this._selectionSlider.onBarFilledIEnumerator -= handlePlayBarFilled;
			this._quitSelectionSlider.onBarFilledIEnumerator -= handleQuitBarFilled;
			this._bManager.onAPartFinish -= handleAPartFinish;
			this._bManager.onBuildingFinish -= handleBuildingFinish;
			this._sManager.onSpwanObjReady -= handleSpwanObjsReady;
			this._bManager.onBrickAniFinish -= handleBrickStratAniFinish;
		}
		IEnumerator handleBrickStratAniFinish(){
			yield return StartCoroutine (this._uiCtrl.hideAniStartUI ());
			yield return StartCoroutine (this._uiCtrl.showAniEndUI ());
			yield return new WaitForSeconds (this._aniUIAppearTime);
			yield return StartCoroutine (this._uiCtrl.hideAniEndUI ());
			//create bricks for game
			this._sManager.spwanObjs ();
		}
		IEnumerator handlePlayBarFilled(){
			//turn off waring;
			this._inputWarnings.TurnOffSingleTapWarnings ();
			this._inputWarnings.TurnOffDoubleTapWarnings ();
			if (!this._isPlayed) {
				yield return StartCoroutine (this._uiCtrl.hideIntroUI ());
				yield return StartCoroutine (this._uiCtrl.showAniStartUI ());
				//wait for seconds 
				yield return new WaitForSeconds(this._aniDelayTime);
				this._bricksAnimator.SetTrigger("AniStart");
			} else {
				if (this._isFinish) {
					yield return StartCoroutine (this._uiCtrl.hideFinishUI());
					//do somthing for roam;
					SceneManager.LoadScene(SeeionDataCtrl.RoamSceneIdx);
				} else {
					yield return StartCoroutine (this._uiCtrl.hideDidntFinishUI ());
					SceneManager.LoadScene (SeeionDataCtrl.BrickSceneIdx);
				}
			}

		}
		IEnumerator handleQuitBarFilled(){
			if (!this._isPlayed) {
				yield return StartCoroutine (this._uiCtrl.hideIntroUI ());
				Application.Quit ();
			} else {
				if (this._isFinish) {
					yield return StartCoroutine (this._uiCtrl.hideFinishUI ());
				} else {
					yield return StartCoroutine (this._uiCtrl.hideDidntFinishUI ());
				}
				Application.LoadLevel (Application.loadedLevel);
			}
			yield return null;
		}

		IEnumerator Start(){
			SeeionDataCtrl.SetGameType (_gameType);
			yield return StartCoroutine (startPhase ());

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
			//reset Game Data
			SeeionDataCtrl.restart ();
			this._reticle.Hide ();
//			this._hctrl.enabled = true;
			yield return StartCoroutine (this._uiCtrl.showPlayUI ());
			yield return StartCoroutine (this._uiCtrl.showPlayTipUI ());
			yield return StartCoroutine (this.playUpdate ());
		}
		//finish the game in time;
		IEnumerator endPhase(){
			this._isPlayed = true;
			this._reticle.Show ();
//			this._hctrl.enabled = false;
			yield return StartCoroutine (this._uiCtrl.showFinishUI ());
		}
		//cant finish the game in time;
		IEnumerator overPhase(){
			this._isPlayed = true;
			this._reticle.Show ();
			this._hctrl.enabled = false;
			yield return StartCoroutine (this._uiCtrl.showDidntFinishUI ());
		}
		IEnumerator playUpdate(){
			//set the timer;
			float gameTimer = this._gameTime;
			while (gameTimer > 0 && ! this._isFinish) {
				gameTimer -= Time.deltaTime;
				this._timerBar.fillAmount = gameTimer / this._gameTime;
				yield return null;
			}
			yield return StartCoroutine (this._uiCtrl.hidePlayUI ());
			yield return StartCoroutine (this._uiCtrl.hidePlayTipUI ());
			//gane over
			if(this.onGameOver != null){
				this.onGameOver ();
			}
			//finish or not?
			if (this._isFinish) {
				SeeionDataCtrl.setGamTime (this._gameTime - gameTimer);
				yield return StartCoroutine (endPhase ());
			} else {
				yield return StartCoroutine (overPhase ());
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

		IEnumerator handleSpwanObjsReady(){
			yield return StartCoroutine (this.playPhase ());
		}
	}
}
