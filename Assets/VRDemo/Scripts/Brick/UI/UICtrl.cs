using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
namespace VRDemo.Game.Brick.UI
{
	public class UICtrl : MonoBehaviour {
		[SerializeField]private UIFader _introUI;
		[SerializeField]private UIFader _playUI;
		[SerializeField]private UIFader _outroUI;

		public IEnumerator showIntroUI(){
			yield return StartCoroutine (this._introUI.InteruptAndFadeIn ());
		}
		public IEnumerator hideIntroUI(){
			yield return StartCoroutine (this._introUI.InteruptAndFadeOut());
		}
		public IEnumerator showOutroUI()
		{
//			m_TotalScore.text = SessionData.Score.ToString();
//			m_HighScore.text = SessionData.HighScore.ToString();

			yield return StartCoroutine(this._outroUI.InteruptAndFadeIn());
		}
			
		public IEnumerator hideOutroUI()
		{
			yield return StartCoroutine(this._outroUI.InteruptAndFadeOut());
		}


		public IEnumerator showPlayUI ()
		{
			yield return StartCoroutine (this._playUI.InteruptAndFadeIn ());
		}


		public IEnumerator hidePlayUI ()
		{
			yield return StartCoroutine (this._playUI.InteruptAndFadeOut ());
		}

	}

}
