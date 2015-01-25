using UnityEngine;
using System.Collections;

public class AudioTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioController.instance.PlayBGM("bgm002");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			AudioController.instance.PlaySE("SEcrow");
		}
		else if(Input.GetKey(KeyCode.B)){
			AudioController.instance.PlaySE("SEcat");
		}
		else if(Input.GetKey(KeyCode.C)){
			AudioController.instance.PlaySE("SEdog");
		}
		else if(Input.GetKey(KeyCode.D)){
			AudioController.instance.PlaySE("SEwalk");
		}
	}
}
