using UnityEngine;
using System.Collections;
using VRDemo.Common;
namespace VRDemo.Game.Brick.Hand
{
	public class ReceiverCtrl : MonoBehaviour {

		[SerializeField]private BrickCtrl _bCtrl;
		private HandCtrl _hCtrl;

		private Rigidbody _rig = null;
		private CapsuleHand _funcHand = null;
		private Transform _parentTrans = null;
		private bool _isInCatch = false;
		void Awake(){
			this._hCtrl = GameObject.FindGameObjectWithTag ("HandController").gameObject.GetComponent<HandCtrl> ();
			this._parentTrans = this.transform.parent;
			this._rig = this.GetComponent<Rigidbody> ();
		}
		void OnEnable(){
			this._hCtrl.onHandInRange += handleOnHandIndetection;
		}
		void handleOnHandIndetection(){
			if (this._isInCatch) {
				this._bCtrl.checkBrickRightOrFalse ();
			}
		}
		void OnDisable(){
			this._hCtrl.onHandInRange -= handleOnHandIndetection;
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
//				Debug.Log ("hand catch : " + other.tag);
				this._funcHand = this._hCtrl.getHandByName (other.tag);
				if (this._funcHand != null) {
//					Debug.Log("hand is get");
					//if player prepare to catch it
					if (this._hCtrl.getGestureType (this._funcHand) == GestureType.Catch) {
//						Debug.Log (this._hCtrl.getGestureType (this._funcHand));
						//if player didnt catch anything
						if (!this._hCtrl.isHandCatch (this._funcHand)) {
							this._isInCatch = true;
							//set  hand was catching something
							this._hCtrl.toggleHandIsCatch (this._funcHand);
							this._funcHand.setHandReceiver (this.transform);
							//why??
							this.transform.localPosition = new Vector3(-1.16f, 0, -0.57f);

							this._rig.velocity = Vector3.zero;
							this._rig.angularVelocity = Vector3.zero;
							this._rig.isKinematic = true;
							this._rig.useGravity = false;
						}
					} else  if(this._hCtrl.getGestureType(this._funcHand)  == GestureType.Open){
						//open gesture
						this._isInCatch = false;
						this._bCtrl.restoreBrickItem ();
						this._hCtrl.toggleHandIsCatch (this._funcHand);
						this._funcHand.target = null;
						this._funcHand = null;
						transform.parent = this._parentTrans;
//						HandManager._instance.right = false;
						this._rig.isKinematic = false;
//						this._rig.useGravity = true;

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
