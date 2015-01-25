using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultManeger : MonoBehaviour {

	public Sprite clearSprite;
	public Sprite gameoverSprite;
	public Text stepText;

	private bool started = false;
	private bool result = false;

	private float timer = 0f;

	// Use this for initialization
	void InnerStart () {
		var image = GameObject.Find("BGImage").GetComponent<Image>();
		if( Parameter.instance.gameClear ){
			image.sprite = clearSprite;
		}
		else{
			image.sprite = gameoverSprite;
			AudioController.instance.PlaySE("SEshock");
		}

		stepText.enabled = false;
		started = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!started){
			InnerStart();
			return;
		}

		if(Input.GetKey(KeyCode.Space) && !result){
			result = true;
			ViewResultBord();
		}

		if(result){
			timer+= Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.Space) && timer > 1f){
			Application.LoadLevel("Title");
		}
	}

	void ViewResultBord(){
		stepText.text = "Step : "+Parameter.instance.GetStep();
		stepText.enabled = true;
	}
}
