//音量調整
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Change_Volume : MonoBehaviour {

	//音量スライダー
	public Slider Char_Volume_Bar;
	public Slider ES_Volume_Bar;
	//音量値変数(他スクリプトから参照可)
	static public float Char_Volume_Value = 1.0f;//キャラクター効果音ボリューム
	static public float ES_Volume_Value = 0.1f;//環境音ボリューム

	//音量調整バーからの変更を反映
	//キャラクター効果音
	public void Char_Volume()
	{
		Char_Volume_Value = Char_Volume_Bar.value;
		//キャラクターサウンドに変更を反映
		char_sound.audio_Volume = Char_Volume_Value;
		char_sound.audio_secound_Volume = Char_Volume_Value;
	}

	//環境音
	public void ES_Volume()
	{
		ES_Volume_Value = ES_Volume_Bar.value;
		//環境音に変更を反映
		Environmental_Sound.ES_Volume = ES_Volume_Value;


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
