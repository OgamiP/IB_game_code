//オプション　リスポーン間隔設定
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class input_field_respawn_freq : MonoBehaviour {

	public InputField TimeInput;//制限時間入力空間取得
	public Text message_text;//エラー時正しい値を入力するよう警告
	
	public int error_flag = 0;//確定のOKボタンを押したときにエラーがないかを確認するフラグ


	//stage1 リスポーン時間
	public void End_Edit_stage1()
	{
		//数値かどうか(値を格納してから評価)
		if(float.TryParse(TimeInput.text, out time_count.respawn_freq_1) == true)
		{
			error_flag = 0;//エラー無し
			message_text.text = "";
			Debug.Log(TimeInput.text);
			
		}else{
			error_flag = 1;//エラー有り
			message_text.text = "数値を入力してください";
			Debug.Log("error");
			
		}
		
		
		
	}

	//stage2 リスポーン時間
	public void End_Edit_stage2()
	{
		//数値かどうか(値を格納してから評価)
		if(float.TryParse(TimeInput.text, out time_count.respawn_freq_2) == true)
		{
			error_flag = 0;//エラー無し
			message_text.text = "";
			Debug.Log(TimeInput.text);
			
		}else{
			error_flag = 1;//エラー有り
			message_text.text = "数値を入力してください";
			Debug.Log("error");
			
		}
		
		
		
	}

	//stage3 リスポーン時間
	public void End_Edit_stage3()
	{
		//数値かどうか(値を格納してから評価)
		if(float.TryParse(TimeInput.text, out time_count.respawn_freq_3) == true)
		{
			error_flag = 0;//エラー無し
			message_text.text = "";
			Debug.Log(TimeInput.text);
			
		}else{
			error_flag = 1;//エラー有り
			message_text.text = "数値を入力してください";
			Debug.Log("error");
			
		}
		
		
		
	}





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
