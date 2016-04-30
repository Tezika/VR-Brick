using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VRStandardAssets.Utils;
namespace VRDemo.Game.Brick
{
	public class BrickCtrl : MonoBehaviour {
		[SerializeField]private uint _flag = 1;
		[SerializeField]private VRInteractiveItem _interactive;
		[SerializeField]private Color _rightColor;
		[SerializeField]private Color _falseColor;
		[SerializeField]private GameObject _rightObj;
		[SerializeField]private GameObject _falseObj;
		[SerializeField]private GameObject _normalObj;

		private bool _isChoose = false;
		private bool _isOver = false;

		//all the child
		// Use this for initialization
		void Awake(){
			this.changeObjMaterialColor (this._rightObj,this._rightColor);
			this.changeObjMaterialColor (this._falseObj, this._falseColor);
		}
		void Start () {
			
		}
		void OnEnable(){
			this._interactive.OnOver += handleOver;
			this._interactive.OnOut += handleOut;
			this._interactive.OnClick += handleClick;
		}
		void OnDisable(){
			this._interactive.OnOver -= handleOver;
			this._interactive.OnOut -= handleOut;
			this._interactive.OnClick -= handleClick;
		}
		void handleOver(){
//			this.changeChildrenMaterialColor (this._falseColor);
			this._normalObj.SetActive(false);
			this._rightObj.SetActive (true);
		}
		void handleOut(){
			this._falseObj.SetActive (true);
			this._rightObj.SetActive (false);
			
		}
		void handleClick(){
			
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

