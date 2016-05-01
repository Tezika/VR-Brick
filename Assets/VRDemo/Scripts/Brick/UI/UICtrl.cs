using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;
using VRDemo.Common;

namespace VRDemo.Game.Brick.UI
{
	public class UICtrl : MonoBehaviour {
		[SerializeField]private UIFader _introUI;
		[SerializeField]private UIFader _playUI;
		[SerializeField]private UIFader _outroUI_finish;
		[SerializeField]private UIFader _outroUI_didntFinish;
		[SerializeField]private Text _timeText;
		[SerializeField]private Text _bestTimeText;
		[SerializeField]private Text _selectionPlayBarText;
		[SerializeField]private Text _selectionQuitBarText;

		public IEnumerator showIntroUI(){
			yield return StartCoroutine (this._introUI.InteruptAndFadeIn ());
		}
		public IEnumerator hideIntroUI(){
			yield return StartCoroutine (this._introUI.InteruptAndFadeOut());
		}
		public IEnumerator showFinishUI()
		{
			this._timeText.text= ((int)SeeionDataCtrl.Time).ToString();
			this._bestTimeText.text= ((int)SeeionDataCtrl.BestTime).ToString();
			this._selectionPlayBarText.text = "Lets go to roam:)";
			this._selectionQuitBarText.text = "I wanna back";	
			yield return StartCoroutine(this._outroUI_finish.InteruptAndFadeIn());
		}
			
		public IEnumerator hideFinishUI()
		{
			yield return StartCoroutine(this._outroUI_finish.InteruptAndFadeOut());
		}



		public IEnumerator showPlayUI ()
		{
			yield return StartCoroutine (this._playUI.InteruptAndFadeIn ());
		}


		public IEnumerator hidePlayUI ()
		{
			yield return StartCoroutine (this._playUI.InteruptAndFadeOut ());
		}

		//add by tezika
		public IEnumerator showDidntFinishUI(){
	       this._selectionPlayBarText.text = "Lets hava a retry :)";
		   this._selectionQuitBarText.text = "I wanna back";	
		   yield return StartCoroutine(this._outroUI_didntFinish.InteruptAndFadeIn());
		}

		public IEnumerator hideDidntFinishUI(){
			yield return StartCoroutine(this._outroUI_didntFinish.InteruptAndFadeOut());
		}

	}

}
