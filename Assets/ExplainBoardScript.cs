using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExplainBoardScript : MonoBehaviour {

	private float alphaValue;
	private bool disappearFlag;
	private Image myImage;

	private Color myImageColor;

	// Use this for initialization
	void Start () {
		alphaValue = 1f;
		disappearFlag = false;
		myImage = transform.GetComponent<Image>();
		myImageColor = myImage.color;
	}
	
	// Update is called once per frame
	void Update () {
//		if (disappearFlag) {
//			myImageColor = myImage.color;
//			myImageColor.a = myImageColor.a - 0.01f;
//			myImage.color = myImageColor;
//		}
		if (disappearFlag) {
			Destroy(gameObject);
		}
	}

	public void OnExplainBoardClick(){
		disappearFlag = true;
	}


}
