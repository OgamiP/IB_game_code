//プレイヤーキャラクターサウンドスクリプト 主にアニメーションイベントより呼び出し
using UnityEngine;
using System.Collections;

public class char_sound : MonoBehaviour {

	/*****基本動作のオーディオクリップ*****/
	public AudioClip Run_Sound;
	public AudioClip Run_sound_secound;//run soundのバックSE
	public AudioClip Back_Run_sound;
	public AudioClip Landing_sound;
    public AudioClip jump_sound;
	public AudioClip jump2_sound;
	public AudioClip Gun_Fire_sound;
	/***********************************/

	/*****攻撃動作のオーディオクリップ*****/
	public AudioClip atk_small1;
	public AudioClip atk_small2;
	public AudioClip atk_big;
	/***********************************/

	/***********************************/
	public int flag = 0;//再生許可フラグ
	public int landing_sound_flag = 0;
	public int jump2_sound_flag = 0;
	/**********************************/

	char_skill SKILL_FLAG;//プレイヤー移動許可フラグ（音声制御版）
	char_move CHAR_MOVE;
	
	public AudioSource _audio;//audiosource
	public AudioSource _audio_secound;//main audio source と同時に鳴らすバックSE

	/*****オーディオソースのボリューム変数*****/
	static public float audio_Volume = 1.0f;
	static public float audio_secound_Volume = 1.0f;
	/**************************************/

	public int now_jumpsound2 = 0;
	

	//run sound
	public void Run_sound()
	{
		_audio_secound.clip = Run_Sound;
		_audio_secound.PlayOneShot(_audio_secound.clip,0.25f);//,0.25f

	}

	//jump sound
	public void Jump_sound()
	{
		_audio.clip = jump_sound;
		_audio.PlayOneShot (_audio.clip, 0.025f);


	}

	//gun fire sound
	public void Gun_Fire()
	{
		_audio.clip = Gun_Fire_sound;
		GameObject.Find("arm2_R_017").GetComponent<Bullet_script> ().bullet_fire();//gun bonename
		_audio.PlayOneShot (_audio.clip, 0.125f);


	}

	//jump2_sound
	public void Jump2_sound()
	{
		_audio.clip = jump2_sound;
		_audio_secound .clip = jump_sound;
		_audio.PlayOneShot (_audio.clip, 0.5f);
		_audio_secound.PlayOneShot (_audio_secound.clip, 0.025f);
	}

	//atk_sound_small小さい素振り音
	public void atk_small1_sound()
	{
		_audio.clip = atk_small1;
		_audio.PlayOneShot (_audio.clip, 0.025f);

	}

	//atk_sound_small大きい素振り音
	public void atk_big_sound()
	{
		_audio.clip = atk_big;
		_audio.PlayOneShot (_audio.clip, 0.025f);
		
	}

	// Use this for initialization
	void Start () {

		/*******************************/
		CHAR_MOVE = GetComponent<char_move> ();
		_audio = GetComponent<AudioSource> ();
		SKILL_FLAG = GetComponent<char_skill> ();
		/*******************************/

		_audio.clip = Run_Sound;//runsound取得

	}


	// Update is called once per frame
	void Update () {
		//音量を監視
		_audio.volume = audio_Volume;
		_audio_secound.volume = audio_secound_Volume;



	}
}
