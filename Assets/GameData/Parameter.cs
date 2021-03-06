﻿using System.Collections;
using UnityEngine;

public class Parameter {
	public int MaxHp = 50;
	public bool gameClear = false;
	private int hp = 0;
	private int step = 0;

	private static volatile Parameter _instance = null;
	public static Parameter instance {
		get{
			if(_instance == null) _instance = new Parameter();
			return _instance;
		}
	}

	public void Clear(){
		gameClear = false;
		hp = MaxHp;
		step = 0;
	}

	public int GetHp(){
		return hp;
	}

	public int GetStep(){
		return step;
	}

	public int GetMaxHp(){
		return MaxHp;
	}

	public int AddHp(int add){
		if(add < 0) return hp;
		hp += add;
		if(hp > MaxHp) hp = MaxHp;
		return hp;
	}

	public int DamageHp(int damage){
		if(damage < 0) return hp;
		hp -=damage;
		if (hp <= 0) {
			hp = 0;
			Application.LoadLevel("Result");
		}
		Debug.Log (hp);
		return hp;
	}

	public int StepUp(){
		step ++;
		return step;
	}
}
