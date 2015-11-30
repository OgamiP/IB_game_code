//オプション　時間制限設定
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class input_field_Time : MonoBehaviour {

	public InputField TimeInput;//制限時間入力空間取得
	public Text message_text;//エラー時正しい値を入力するよう警告

	public int error_flag = 0;//確定のOKボタンを押したときにエラーがないかを確認するフラグ


	//ステージ1制限時間設定
	public void End_Edit_time1()
	{

		if(float.TryParse(TimeInput.text, out time_count.stage1_limit_time) == true)
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
	//ステージ2制限時間設定
	public void End_Edit_time2()
	{
		
		if(float.TryParse(TimeInput.text, out time_count.stage2_limit_time) == true)
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

	//ステージ3制限時間設定
	public void End_Edit_time3()
	{
		
		if(float.TryParse(TimeInput.text, out time_count.stage3_limit_time) == true)
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
