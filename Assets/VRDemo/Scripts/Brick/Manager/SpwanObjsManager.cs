using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using VRDemo.Game.Brick.Delegate;

namespace VRDemo.Game.Brick.Delegate
{
	public delegate IEnumerator SpwanObjsReady();
}

namespace VRDemo.Game.Brick.Manager
{
	public class SpwanObjsManager : MonoBehaviour {

		public event SpwanObjsReady onSpwanObjReady;

		[SerializeField]private GameObject[] _objs;
		[SerializeField]private SpwanPosCtrl[] _spwanPos;
		[SerializeField]private uint _numOfSpwanObj = 6;
		private uint _readyObj = 0;
		private List<GameObject> _objsList = new List<GameObject>();

	
		void Start(){
			this.addObjsToList ();
		}
		void addObjsToList(){
			foreach (GameObject obj in this._objs) {
				this._objsList.Add (obj);
			}
		}
		public void spwanObjs(){
			UnityEngine.Random.seed = (int)Time.time;
			foreach (SpwanPosCtrl sctrl in _spwanPos) {
				GameObject obj = this._objsList [UnityEngine.Random.Range (0, this._objsList.Count)];
				sctrl.spwanObj (obj);
				this._objsList.Remove (obj);
			}
		}
		public void spwanObjReady(){
			if (++this._readyObj == this._numOfSpwanObj) {
				if (this.onSpwanObjReady != null) {
					StartCoroutine (this.onSpwanObjReady ());

				}
			}
		}	
	}

}
