//標的をUIでエイム
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class char_aim : MonoBehaviour {
	
	//カメラ取得
	public Camera main_camera;
	public Camera UI_camera;

	//表示するaim UI
	public Image Aim_UI;
	public Sprite Aim_UI_Sprite;

	//Aim対象
	public GameObject aim_target;
	//UI表示座標
	public Vector3 Aim_UI_position;
	//recttrans
	public RectTransform aim_ui_rect;
	//フィールド上のenemy数を確認
	public int enemy_number;
	//Aim表示フラグ=1でaim表示
	public int Aim_flag = 0;

	// Use this for initialization
	void Start () {
		Aim_UI.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		enemy_number = GameObject.FindGameObjectsWithTag ("enemy").Length;//フィールド上のenemy数確認
		//対象が不在の場合適当にキャッシュする
		if (enemy_number == 0) {
			Aim_flag = 0;//対象がフィールド上のどこにもいない場合aimflagを0にする
		}
		if (aim_target == null && enemy_number != 0) {
			aim_target = GameObject.FindWithTag("enemy");

		}

		//ターゲットが存在fキーを押した場合にAim表示を行う
		if (aim_target != null && Input.GetKey ("f") || Aim_flag == 1) {

			Aim_UI.enabled = true;
			Aim_flag = 1;
			//ワールド座標からビューポート座標へ変換
			Aim_UI_position = main_camera.WorldToViewportPoint (aim_target.transform.position);

			//対象のアンカーmax,minをAim_UI_positionで更新
			aim_ui_rect.anchorMax = Aim_UI_position;
			aim_ui_rect.anchorMin = Aim_UI_position;


		} else if (aim_target == null) {
			Aim_flag = 0;
			Aim_UI.enabled = false;

		}


	}


}
