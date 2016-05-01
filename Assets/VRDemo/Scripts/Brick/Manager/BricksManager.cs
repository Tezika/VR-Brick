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
}
namespace VRDemo.Game.Brick.Manager
{
	public class BricksManager : MonoBehaviour {
		public event BuildingFinish onBuildingFinish;
		public event APartFinish onAPartFinish;


		[SerializeField]private uint _numOfParts = 7;
		public uint NumOfParts{
			get
			{ return this._numOfParts;}
		}
		[SerializeField]private GameObject[] _buildingParts;
		private uint _curRightFlag = 1;
		private Dictionary<uint,Vector3> _posMap;
		// Use this for initialization
		void Start () {

		}

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
			

	}


}
