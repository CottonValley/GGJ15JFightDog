using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenkiGaugeScript : MonoBehaviour {

	private Image myImage;
	private Parameter gameParameter;
	private int MaxHp;
	private int nowHp;

	// Use this for initialization
	void Start () {
		myImage = gameObject.GetComponent<Image> ();
		gameParameter = Parameter.instance;
		gameParameter.Clear ();
		MaxHp = gameParameter.GetMaxHp();
		nowHp = gameParameter.GetHp();
		myImage.fillAmount = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if ( nowHp != gameParameter.GetHp ()) {
			nowHp = gameParameter.GetHp();
			Debug.Log ((float)nowHp / MaxHp);
			myImage.fillAmount = (float)nowHp / MaxHp;
		}
	}
}
