using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Result_Canvas_script : MonoBehaviour {


	//result canvas
	public Canvas Result;//ステージresult

	//result contents
	/*****共通*****/
	public Text Fast_Score;
	public Text Kill_Count;
	public Text Max_Combo;
	public Text Score;
	/*************/

	public static string new_score_board;
	public static string new_kill_score;//前回までの記録を記憶
	public static string new_score;


	/*****ステージ2 collect item number *****/
	public Text Collect_Number_Label;
	public Text Collect_Number;


	public static int Stage_number = 0;//ステージナンバーステージごとに足しこんでいく形で更新
	public int Old_Stage_number = 0;//前回のステージ番号と比較


	//各ステージ終了時終了したステージ番号を受け取り評価
	public void Show_reslt()
	{
		if (Stage_number == 1) {
			//スコア情報をstaticで持っているステージcanvasの情報を反映
			Fast_Score.text = time_count.result_score_num.ToString();
			Kill_Count.text = time_count.result_kill_count_num.ToString();
			Max_Combo.text = time_count.combo_score_num.ToString();
			Score.text = time_count.Last_score_num.ToString();
		//	Stage_number += 1;



		} else if (Stage_number == 2) {
			//collect情報を表示
			Collect_Number_Label.enabled = true;
			Collect_Number.enabled = true;
			Collect_Number.text = time_count.Collect_num.ToString();

			Fast_Score.text = time_count.result_score_num.ToString();
			Kill_Count.text = time_count.result_kill_count_num.ToString();
			Max_Combo.text = time_count.combo_score_num.ToString();
			Score.text = time_count.Last_score_num.ToString();

		//	Stage_number += 1;

		} else if (Stage_number == 3) {
			//collect情報消しておく
			Collect_Number_Label.enabled = false;
			Collect_Number.enabled = false;
			Collect_Number.text = time_count.Collect_num.ToString();

			Fast_Score.text = time_count.result_score_num.ToString();
			Kill_Count.text = time_count.result_kill_count_num.ToString();
			Max_Combo.text = time_count.combo_score_num.ToString();
			Score.text = time_count.Last_score_num.ToString();

			//記録を追加
			score_bord.update_score += time_count.Final_Kill_count.ToString() + "     " + time_count.Final_Score.ToString() + "\n";
			new_score_board = score_bord.update_score;
			//	Stage_number += 1;



		}


	}

	// Use this for initialization
	void Start () {
		//共通しないresult contentsを消しておく
		Collect_Number_Label.enabled = false;
		Collect_Number.enabled = false;


	}
	
	// Update is called once per frame
	void Update () {
		if (Stage_number != Old_Stage_number) {
			Old_Stage_number = Stage_number;//更新
			Show_reslt();

		}
	
	}
}
