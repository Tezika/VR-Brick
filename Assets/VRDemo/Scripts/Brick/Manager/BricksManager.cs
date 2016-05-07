using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using VRDemo.Game.Brick;
using VRDemo.Game.Brick.Delegate;

namespace VRDemo.Game.Brick.Delegate
{
	public delegate IEnumerator BuildingFinish();
	public delegate IEnumerator APartFinish();
	public delegate IEnumerator BrickStartAniFinish();
}
namespace VRDemo.Game.Brick.Manager
{
	public class BricksManager : MonoBehaviour {
		public event BuildingFinish onBuildingFinish;
		public event APartFinish onAPartFinish;
		public event BrickStartAniFinish onBrickAniFinish;


		[SerializeField]private uint _numOfParts = 7;
		public uint NumOfParts{
			get
			{ return this._numOfParts;}
		}
		[SerializeField]private GameObject[] _buildingParts;
		[SerializeField]private Vector3[] _buildingPartsPos;
		private uint _curRightFlag = 1;


		// Update is called once per frame
		void Update () {

		}
		public bool judgeBrickIsRight(uint flag){
			if (flag == this._curRightFlag) {
				return true;
			} else {
				return false;
			}
			
		}
		//当选择了正确的部分
		public void changeBuildingPart(uint flag){
			this._buildingParts [flag].SetActive (true);
			++this._curRightFlag;
			if (this._curRightFlag == this._numOfParts) {
				if (this.onBuildingFinish != null) {
					StartCoroutine (this.onBuildingFinish ());
				
				}
			} else {
				if (this.onAPartFinish != null) {
					StartCoroutine (this.onAPartFinish ());
				}
			}
		}
		//恢复part到原来的位置
		public void restorePartPos(){
			//must disenable animator else cant modify the
			this.GetComponent<Animator>().enabled = false;
			for (uint i = 1; i < this._buildingParts.Length; ++i) {
				this._buildingParts [i].transform.localPosition = this._buildingPartsPos [i];
			}
		if (this.onBrickAniFinish != null) {
				StartCoroutine (this.onBrickAniFinish ());

			}
		}
			

	}


}
