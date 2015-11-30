//ゲームーバースクリプト
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game_Over_Script : MonoBehaviour {

	//ゲームオーバーキャンバス
	public Canvas Game_Over_Canvas;
	//タイトルへ戻るまでの時間表示テキスト
	private float Return_Titlle_Limit = 5.0f;
	public Text Return_Tittle_Msg;
	//ゲームオーバー表示フラグ(static)0:非表示1:表示
	public static int Show_Game_Over_Flag = 0;

	// Use this for initialization
	void Start () {
		//ゲーム開始時ゲームオーバーを表示するキャンバスを隠す
		Game_Over_Canvas.enabled = false;

	
	}
	
	// Update is called once per frame
	void Update () {
		//キャラクターステータスからゲームーバー表示フラグが1になったとき表示
		if (Show_Game_Over_Flag == 1) {

			Game_Over_Canvas.enabled = true;

			//タイトルに戻るまでのタイムカウントを行う
			if(Return_Titlle_Limit >= 0)
			{
				Return_Titlle_Limit -= Time.deltaTime;
				Return_Tittle_Msg.text = "Return Tittel" + ((int)Return_Titlle_Limit).ToString() + "...";
				//タイムカウント0でタイトルシーンに飛ばす
				if(Return_Titlle_Limit <= 0)
				{
					Application.LoadLevel("Tittle");

				}

			}


		}
	
	}
}
