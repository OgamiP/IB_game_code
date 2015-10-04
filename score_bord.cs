using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score_bord : MonoBehaviour {

	//表示テキスト
	public Text score_board_text;
	public static string update_score;//result canvas script との相互更新



	//合計スコアkillをキャッシュ
	static int score_board_score;
	static int score_board_kill;

	//ループ制御変数
	private int i;
	private int j;

	//order
	public int score_number = 0;

	//result管理

	//横の0番目:オーダ　1番目:kill数　2番目:score
	public int[,]result_manage = new int[10,3];

	//set result score
	public void set_result_manager(int x,int y)
	{
		result_manage [score_number, 1] = x;//kill数格納
		result_manage [score_number, 2] = y;//score格納
		Debug.Log (score_board_text.text.ToString ());


		//次のスコアを羅列するため記憶
	//	Old_score_board = score_board_text.text;
		score_number += 1;//インクリメント

	}

	// Use this for initialization
	void Start () {
		score_board_text.text = Result_Canvas_script.new_score_board;
		time_count.Final_Kill_count = 0;
		time_count.Final_Score = 0;


	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
