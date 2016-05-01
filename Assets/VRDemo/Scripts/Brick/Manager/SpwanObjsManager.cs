using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace VRDemo.Game.Brick.Manager
{
	public class SpwanObjsManager : MonoBehaviour {
		[SerializeField]private GameObject[] _objs;
		[SerializeField]private SpwanPosCtrl[] _spwanPos;

		private List<GameObject> _objsList = new List<GameObject>();
		// Use this for initialization
		void Start(){
			this.addObjsToList ();
		}
		void addObjsToList(){
			foreach (GameObject obj in this._objs) {
				this._objsList.Add (obj);
			}
		}
		public void spwanObjs(){
			Random.seed = (int)Time.time;
			foreach (SpwanPosCtrl sctrl in _spwanPos) {
				GameObject obj = this._objsList [Random.Range (0, this._objsList.Count)];
				sctrl.spwanObj (obj);
				this._objsList.Remove (obj);
			}
		}
			
	}

}
