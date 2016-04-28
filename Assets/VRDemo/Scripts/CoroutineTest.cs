using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoroutineTest : MonoBehaviour
{
	// Use this for initialization
	[SerializeField]
	private float testFloat = 2.1f;
	//void Start () {
	IEnumerator Start (){
//		Debug.Log (Mathf.Exp (1));
		yield return StartCoroutine (firstCoroutine ());

	}

	IEnumerator firstCoroutine (){
		Debug.Log ("cur Time: " + Time.time);
		yield return new WaitForSeconds (3f);
		Debug.Log ("end Time: " + Time.time);
		yield return StartCoroutine (sCoroutine ());
	}

	IEnumerator sCoroutine (){
		Debug.Log ("cur Time: " + Time.time);
		yield return new WaitForSeconds (3f);
		Debug.Log ("end Time: " + Time.time);
	}

	// Update is called once per frame
	void Update (){
		
	}
    
}
