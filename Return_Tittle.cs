using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Return_Tittle : MonoBehaviour {




	// Use this for initialization
	void Start () {

	}

	
	// Update is called once per frame
	void Update () {

		//緊急脱出タイトルに強制遷移
		if (Input.GetKeyDown ("escape")) {
			Result_Canvas_script.Stage_number = 0;//ステージナンバー初期化
			Application.LoadLevel("Tittle");

		}
	
	}
}
