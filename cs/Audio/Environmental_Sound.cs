//環境音スクリプト
using UnityEngine;
using System.Collections;

public class Environmental_Sound : MonoBehaviour {

	//環境音オーディオクリップ
	public AudioClip ES_Rain;
	public AudioClip ES_Wind;

	//オーディオソース
	public AudioSource _ES_1;
	public AudioSource _ES_2;

	//オーディオソースのボリューム変数
	static public float ES_Volume = 0.1f;


	// Use this for initialization
	void Start () {

		_ES_1.clip = ES_Rain;
		_ES_1.Play ();
		_ES_2.clip = ES_Wind;
		_ES_2.Play ();
	
	}
	
	// Update is called once per frame
	void Update () {

		//音量を監視
		_ES_1.volume = ES_Volume;
		_ES_2.volume = ES_Volume;
	
	}
}
