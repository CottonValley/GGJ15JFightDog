using UnityEngine;
using System.Collections;

public class ItemTriggerScript : MonoBehaviour {

	private Parameter gameParameter;

	// Use this for initialization
	void Start () {
		gameParameter = Parameter.instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "ItemGet") {
			gameParameter.AddHp (5);
			Destroy(gameObject);
		}
	}
}
