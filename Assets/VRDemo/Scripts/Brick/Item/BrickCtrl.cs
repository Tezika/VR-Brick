using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VRStandardAssets.Utils;
using VRDemo.Game.Brick.Manager;
using VRDemo.Game.Brick.Delegate;

namespace VRDemo.Game.Brick.Delegate
{


}

namespace VRDemo.Game.Brick
{
	public class BrickCtrl : MonoBehaviour {
		[SerializeField]private uint _flag = 1;
		[SerializeField]private VRInteractiveItem _interactive = null;
		[SerializeField]private Color _rightColor;
		[SerializeField]private Color _falseColor;
		[SerializeField]private GameObject _rightObj;
		[SerializeField]private GameObject _falseObj;
		[SerializeField]private GameObject _normalObj;



		private BrickGameManager _gManager;
		private BricksManager _bricksManager;
		private bool _isChooseRight = false;
		private bool _isOver = false;



		// Use this for initialization
		void Awake(){
			//get bricksManager for tag;
			this._bricksManager = GameObject.FindGameObjectWithTag("Building").gameObject.GetComponent<BricksManager>();
			this._gManager = GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<BrickGameManager> ();
			this.changeObjMaterialColor (this._rightObj,this._rightColor);
			this.changeObjMaterialColor (this._falseObj, this._falseColor);
		}
		void Start () {
			
		}
		void OnEnable(){
			this._interactive.OnOver += handleOver;
			this._interactive.OnOut += handleOut;
			this._interactive.OnClick += handleClick;

			this._gManager.onGameOver += handleGameOver;
		}
		void OnDisable(){
			this._interactive.OnOver -= handleOver;
			this._interactive.OnOut -= handleOut;
			this._interactive.OnClick -= handleClick;

			this._gManager.onGameOver -= handleGameOver;

		}
		void handleOver(){
//			this.changeChildrenMaterialColor (this._falseColor);
			this._isOver = true;
			bool res = this._bricksManager.judgeBrickIsRight (this._flag);
			if (res) {
				this._isChooseRight = true;
				this._normalObj.SetActive (false);
				this._rightObj.SetActive (true);
			}else {
				this._isChooseRight = false;
				this._normalObj.SetActive (false);
				this._falseObj.SetActive (true);
			}

		}
		void handleOut(){
			this._isOver = false;
			this._isChooseRight = false;
			this.restoreBrickItem ();
			
		}
		void handleClick(){
			if (this._isOver && this._isChooseRight) {
				Debug.Log ("yes can change");
				this._bricksManager.changeBuildingPart (this._flag);
				Destroy (this.gameObject);
			}
		}
		void handleGameOver(){
			this.restoreBrickItem ();
			this.enabled = false;
		}
		void restoreBrickItem(){
			this._normalObj.SetActive (true);
			this._rightObj.SetActive (false);
			this._falseObj.SetActive (false);
		}
		void changeObjMaterialColor(GameObject obj,Color c){
			Renderer[] rens = obj.GetComponentsInChildren<Renderer> ();
			for(int i = 0; i < rens.Length; ++i){
				Material[] materials = rens[i].materials;
				for (int j = 0; j < materials.Length; ++j) {
					materials[j].color = c;
				}
			}

	   }

	}
}

