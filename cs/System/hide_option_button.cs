//オプションを隠すスクリプト
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hide_option_button : MonoBehaviour {


	public Canvas option_canvas;

	public Text error_message_text;
	
	public void OnClick()
	{
		if (GameObject.Find("enemy_freq").GetComponent<input_field_respawn_freq>().error_flag == 0
		    && GameObject.Find("Time_input_field").GetComponent<input_field_Time>().error_flag == 0)
		{
			error_message_text.enabled = false;//隠しておく
			option_canvas.enabled = false;
		} else {
			error_message_text.enabled = true;//エラー表示


		}
		
	}


	// Use this for initialization
	void Start () {
		error_message_text.enabled = false;//隠しておく
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
