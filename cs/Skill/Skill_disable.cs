//キャラクターがジャンプ中にスキルを使用不可にするためのイメージを表示する
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill_disable : MonoBehaviour {

	//表示イメージ
	public Image Skill_disable_Image;

	// Use this for initialization
	void Start () {

		//消しておく
		Skill_disable_Image.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		//キャラクターがジャンプしている間(jumpcount!=0)スキル使用不可イメージ表示
		if (GameObject.FindWithTag ("Player").GetComponent<char_move> ().jumpcount != 0) {
			//表示
			Skill_disable_Image.enabled = true;


		} else {
			//消す
			Skill_disable_Image.enabled = false;

		}
	
	}
}
