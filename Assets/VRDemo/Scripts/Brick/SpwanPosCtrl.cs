using UnityEngine;
using System.Collections;
using VRDemo.Game.Brick.Manager;

namespace VRDemo.Game.Brick
{
	public class SpwanPosCtrl : MonoBehaviour {
		[SerializeField]private float _upSpeed = 5.0f;
		[SerializeField]private float _upHigh = 0.2f;
		[SerializeField]private SpwanObjsManager _sManager;
        
		private bool _isCreated = false;
		private GameObject _initObj;

		public void spwanObj(GameObject obj){
			this._initObj = Instantiate (obj, this.transform.position, Quaternion.identity) as GameObject;
			this._initObj.transform.rotation = this.transform.rotation;
			this._isCreated = true;

		}
		void Update(){
			//dont create the obj so return
			if (!this._isCreated) {
				 return;
			}
			if (this._isCreated && this._initObj.transform.position.y <= this._upHigh) {
				this._initObj.transform.Translate (Vector3.up* Time.deltaTime * _upSpeed,Space.World);
			} else {
//				Debug.Log ("obj is in purpose pos");
				this._isCreated = false;
				this._initObj.GetComponent<Rigidbody> ().useGravity = true;
				this._sManager.spwanObjReady ();
				this.enabled = false;
//				this._initObj.GetComponent<BoxCollider> ().isTrigger = false;
			}
	    }
   }
}
