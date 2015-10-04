
//ステージ遷移等ボタンスクリプト
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button_quit : MonoBehaviour {

	public AudioSource button_se2;//ボタン音
	public Text Button_message;

	//ステージ遷移 ステージ番号より次のステージシーンを読み込み
	public void next_stage()
	{
		if (Result_Canvas_script.Stage_number == 1) {
			Application.LoadLevel ("Stage2_Collect_Item");
		} else if (Result_Canvas_script.Stage_number == 2) {
			Application.LoadLevel ("Stage3_boss1");
		} else if (Result_Canvas_script.Stage_number == 3) {
			Result_Canvas_script.Stage_number = 0;//初期化
			time_count.Collect_num = 0;//collect 初期化
			Application.LoadLevel ("Tittle");
		}
	}

	public void OnClick()
	{
		Application.Quit ();//終了
	}


}
