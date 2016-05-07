using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {
	[SerializeField]private GameObject[] _gos;
	// Use this for initialization
	void Start () {
		for (uint i = 0; i < this._gos.Length; ++i) {
			this._gos [i].SetActive (false);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
