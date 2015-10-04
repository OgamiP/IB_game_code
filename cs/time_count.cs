using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class time_count : MonoBehaviour {

	public Canvas re_canvas;
	public Text Time_text;
	public static float limit_time = 180.0f;//別シーンからの参照を許可
	public static float stage1_limit_time = 180.0f;//オプション変更反映
	public static float stage2_limit_time = 180.0f;//オプション変更反映
	public static float stage3_limit_time = 300.0f;//オプション変更反映

	//respawn area
	public GameObject respawn_object;

	//result
	public Text result_score;
	public Text result_kill_count;

	public static int result_score_num;
	public static int result_kill_count_num;

	public Text combo_score;//->トレイルスクリプト
	public static int combo_score_num;

	public Text Last_score;
	public static int Last_score_num;

	//last score　3ステージ合計のkillとscore
	public static int Final_Kill_count = 0;
	public static int Final_Score = 0;

	/*****ステージ2用*****/
	public int max_Collect_num = 3;//集める最大数
	public static int Collect_num = 0;//集めた数
	public Text collect_num_text;//テキスト表示


	//リザルト表示
	public void Result()
	{

		//情報取得
		result_score_num = GameObject.Find ("Canvas").GetComponent<Kill_Count_script> ().Total_score;
		result_kill_count_num = GameObject.Find ("Canvas").GetComponent<Kill_Count_script> ().Kill_count;
		combo_score_num = GameObject.FindWithTag ("weapon").GetComponent<particle_test> ().max_combo_count;
		Last_score_num = (int)(result_score_num + (result_kill_count_num * 500) + (combo_score_num * 1000) + (Collect_num * 10000));
		//Result_Canvas_script.Stage_number += 1;//ステージナンバー更新

		//制限時間リセット
		if (Result_Canvas_script.Stage_number == 1) {
			limit_time = stage2_limit_time;//次のステージの時間を初期化

		} else if (Result_Canvas_script.Stage_number == 2) {
			limit_time = stage3_limit_time;//次のステージの時間を初期化
		}

		//最終スコア用に足しこみ
		Final_Score += Last_score_num;
		Final_Kill_count += result_kill_count_num;

		Application.LoadLevel("Result");
	}



	// Use this for initialization
	void Start () {

		
		if (Result_Canvas_script.Stage_number == 0) {

			limit_time = stage1_limit_time;//ステージ1時間セット
			//スタート時ステージナンバー更新

		}

		Result_Canvas_script.Stage_number += 1;

		if (Result_Canvas_script.Stage_number == 2) {
			collect_num_text.enabled = true;//collect情報表示

		} else {
			collect_num_text.enabled = false;//collect情報非表示
		}

		
		Time_text.text = ((int)limit_time).ToString();//intでキャスト　stringに変換
	}
	
	// Update is called once per frame
	void Update () {

		if (limit_time >= 0) {
			limit_time -= Time.deltaTime;//1秒で1減らす

			Time_text.text = ((int)limit_time).ToString ();//表示
		}else if (limit_time < 0) {
	//		re_canvas.enabled = true;
			//タイムアップで結果表示



			Result();//結果表示 resultcanvasへ

		}

		//collect情報を更新
		if (Result_Canvas_script.Stage_number == 2) {
			collect_num_text.text = Collect_num.ToString () + "/3";
		}


	
	}

}
