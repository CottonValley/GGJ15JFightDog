using UnityEngine;
using System.Collections;

public class StageObject : MonoBehaviour {

	GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag ("Player") as GameObject;
	}

	void Starter(){

		}
	
	// Update is called once per frame
	void Update () {
	if (Mathf.Abs (Player.transform.position.x - transform.position.x) <= 3.0f)
		{
						renderer.enabled = true;
				} 
		else if (Mathf.Abs (Player.transform.position.z - transform.position.z) <= 3.0f) 
		{
						renderer.enabled = true;
				} 
		else 
		{
			renderer.enabled = false;
				}
	}
}
