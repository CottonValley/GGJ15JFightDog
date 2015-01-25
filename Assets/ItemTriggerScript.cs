using UnityEngine;
using System.Collections;

public class ItemTriggerScript : MonoBehaviour {

	private Parameter gameParameter;
	private GameObject gamePlayer;
	
	// Use this for initialization
	void Start () {
		gameParameter = Parameter.instance;
		gamePlayer = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Vector3 playerPos = gamePlayer.transform.position;
		Vector3 myItemPos = gameObject.transform.position;
		if (16 < Mathf.Pow (playerPos.x - myItemPos.x, 2) + Mathf.Pow (playerPos.z - myItemPos.z, 2)) {
			Debug.Log (":)");
		}
		*/
		transform.LookAt (Camera.main.transform.position);
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "ItemGet") {
			gameParameter.AddHp (5);
			Destroy(gameObject);
		}
	}
}
