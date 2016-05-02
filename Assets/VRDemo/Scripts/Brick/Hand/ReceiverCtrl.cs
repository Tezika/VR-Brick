using UnityEngine;
using System.Collections;
using VRDemo.Common;
namespace VRDemo.Game.Brick.Hand
{
	public class ReceiverCtrl : MonoBehaviour {
		[SerializeField]private HandCtrl _hCtrl;
		private Rigidbody _rig = null;
		private CapsuleHand _funcHand = null;
		private Transform _parentTrans = null;
		void Awake(){
			this._parentTrans = this.transform.parent;
			this._rig = this.GetComponent<Rigidbody> ();
		}
		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}
		void OnTriggerStay(Collider other){
//			Debug.Log ("collison enter");
			if (other.gameObject.tag == SeeionDataCtrl.LeftHand || other.gameObject.tag == SeeionDataCtrl.RightHand) {
				Debug.Log ("hand catch : " + other.tag);
				this._funcHand = this._hCtrl.getHandByName (other.tag);
				if (this._funcHand != null) {
					//if player prepare to catch it
					if (this._hCtrl.getGestureType (this._funcHand) == GestureType.Catch) {
//						Debug.Log (this._hCtrl.getGestureType (this._funcHand));
						//if player didnt catch anything
						if (!this._hCtrl.isHandCatch (this._funcHand)) {
							//set was catch
							this._hCtrl.toggleHandIsCatch (this._funcHand);
							this._funcHand.setHandReceiver (this.transform);
							//why??
							this.transform.localPosition = new Vector3(-1.16f, 0, -0.57f);

							this._rig.velocity = Vector3.zero;
							this._rig.angularVelocity = Vector3.zero;
							this._rig.isKinematic = true;
							this._rig.useGravity = false;
						}
					} else {
						//open gesture
						Debug.Log(this._hCtrl.getGestureType(this._funcHand));
						this._hCtrl.toggleHandIsCatch (this._funcHand);
						this._funcHand.target = null;
						this._funcHand = null;
						transform.parent = this._parentTrans;
						HandManager._instance.right = false;
						this._rig.isKinematic = false;
						this._rig.useGravity = true;

					}

				}
			}
		}
		void OnTriggerExit(Collider other){
			if (other.tag == "RightHand" || other.tag == "LeftHand") {
//				Debug.Log ("hand leave");
			}
		}
	}

}
