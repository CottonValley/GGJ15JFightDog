using UnityEngine;
using System.Collections;

public class TitleManeger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioController.instance.PlayBGM("bgm003");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			Application.LoadLevel("Game");
		}
	}
}
