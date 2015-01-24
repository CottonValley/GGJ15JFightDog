using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomeCompass : MonoBehaviour {
	Transform home = null;
	Transform player = null;
	bool innitialized = false;

	public Transform target = null;
	bool setFlag = false;
	float setTimer = 0f;
	float setMinAngle = 0f;
	float setMaxAngle = 0f;

	// Use this for initialization
	void Start () {
		InvisibleCompass();
	}

	void Innitialize(){
		home = GameObject.FindWithTag("Goal").transform;
		player = GameObject.FindWithTag("Player").transform;
		if(home==null || player==null) return;
		if(target == null) target = transform;

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
			target.rotation = Quaternion.Euler(new Vector3(0,0,angle));
			if(setTimer >= 4f){
				setFlag = false;
				setTimer = 0f;
				InvisibleCompass();
			}
		}
	}

	void ViewCompass(){

		var children = transform.GetComponentsInChildren<Renderer>();

		foreach(Renderer render in children){
			render.enabled = true;
		}

		var imageChildren = gameObject.GetComponentsInChildren<Image>();

		foreach(Image aimage in imageChildren){
			aimage.enabled = true;
		}


		var preR = (home.position - player.position).normalized;
		preR = new Vector3(preR.x, preR.z);

		var euler = Quaternion.FromToRotation (Vector3.up, preR).eulerAngles;
//		setMinAngle = target.rotation.eulerAngles.z;
		setMaxAngle = euler.z + player.localEulerAngles.y;

	}

	void InvisibleCompass(){

		var children = transform.GetComponentsInChildren<Renderer>();

		foreach(Renderer render in children){
			render.enabled = false;
		}

		var imageChildren = gameObject.GetComponentsInChildren<Image>();

		foreach(Image aimage in imageChildren){
			aimage.enabled = false;
		}

	}
}
