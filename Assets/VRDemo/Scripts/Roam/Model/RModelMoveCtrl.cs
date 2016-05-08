using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace VRDemo.Game.Roam.Ctrls
{
	public enum Direction{
		Forward,
		Back,
		Left,
		Right,
		Idle
	}
	public class RModelMoveCtrl : MonoBehaviour {
		[SerializeField]private RoamInputCtrl _inputCtrl;
		[SerializeField]private float _speed = 5.0f;

		private Direction _curDir = Direction.Idle;
		private Dictionary<Direction,Vector3> _speedMaps = new Dictionary<Direction, Vector3> ();
		void Awake(){
			this.initSpeedMaps ();
		}
		// Use this for initialization
		void OnEnable(){
			this._inputCtrl.onForwardStart += handleForwardStart;
			this._inputCtrl.onForwardEnd += handleForwardEnd;
			this._inputCtrl.onBackStart += handleBackStart;
			this._inputCtrl.onBackEnd += handleBackEnd;
			this._inputCtrl.onLeftStart += handleLeftStart;
			this._inputCtrl.onLeftEnd += handleLeftEnd;
			this._inputCtrl.onRightStart += handleRightStart;
			this._inputCtrl.onRightend += handleRightEnd;
		}
		void OnDisable(){
			this._inputCtrl.onForwardStart -= handleForwardStart;
			this._inputCtrl.onForwardEnd -= handleForwardEnd;
			this._inputCtrl.onBackStart -= handleBackStart;
			this._inputCtrl.onBackEnd -= handleBackEnd;
			this._inputCtrl.onLeftStart -= handleLeftStart;
			this._inputCtrl.onLeftEnd -= handleLeftEnd;
			this._inputCtrl.onRightStart -= handleRightStart;
			this._inputCtrl.onRightend -= handleRightEnd;
		}
		//forward
		void handleForwardStart(){
			this._curDir = Direction.Forward;
//			Debug.Log ("foward start!");
		}
		void handleForwardEnd(){
			this._curDir = Direction.Idle;
//			Debug.Log ("forward end!");
		}
		//back
		void handleBackStart(){
			this._curDir = Direction.Back;
//			Debug.Log ("foward start!");
		}
		void handleBackEnd(){
			this._curDir = Direction.Idle;
//			Debug.Log ("forward end!");
		}
		//left
		void handleLeftStart(){
			this._curDir = Direction.Left;
//			Debug.Log ("foward start!");
		}
		void handleLeftEnd(){
			this._curDir = Direction.Idle;
//			Debug.Log ("forward end!");
		}
		//right
		void handleRightStart(){
			this._curDir = Direction.Right;
//			Debug.Log ("foward start!");
		}
		void handleRightEnd(){
			this._curDir = Direction.Idle;
//			Debug.Log ("forward end!");
		}
		void Update(){
			Debug.Log (this._speedMaps [this._curDir]);
			this.transform.Translate (this._speedMaps [this._curDir] * Time.deltaTime);
		}
		void initSpeedMaps(){
			this._speedMaps.Add (Direction.Forward, Vector3.forward * this._speed);
			this._speedMaps.Add (Direction.Back, -Vector3.forward * this._speed);
			this._speedMaps.Add (Direction.Left, -Vector3.right * this._speed);
			this._speedMaps.Add (Direction.Right, Vector3.right * this._speed);
			this._speedMaps.Add (Direction.Idle, Vector3.zero);
		}
	}

}

