using UnityEngine;
using System.Collections;

public class HomeCompass : MonoBehaviour {
	Transform home = null;
	Transform player = null;
	bool innitialized = false;

	bool setFlag = false;
	float setTimer = 0f;
	float setMinAngle = 0f;
	float setMaxAngle = 0f;

	// Use this for initialization
	void Start () {
	}

	void Innitialize(){
		home = GameObject.FindWithTag("Goal").transform;
		player = GameObject.FindWithTag("Player").transform;
		if(home==null || player==null) return;

		innitialized = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!innitialized){
			Innitialize();
			return;
		}

		if (Input.GetKey(KeyCode.Space) && !setFlag){
			setFlag = true;
			ViewCompass();
		}

		if(setFlag){
			setTimer += Time.deltaTime*2;
			float angle = Mathf.LerpAngle(setMinAngle, setMaxAngle, setTimer);
			transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
			if(setTimer >= 1f){
				setFlag = false;
				setTimer = 0f;
			}
		}
	}

	void ViewCompass(){
		var preR = (home.position - player.position).normalized;
		preR = new Vector3(preR.x, preR.z);

		var euler = Quaternion.FromToRotation( Vector3.up,  preR).eulerAngles;
		setMinAngle = transform.rotation.eulerAngles.z;
		setMaxAngle = euler.z;
	}
}
