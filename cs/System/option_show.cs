//オプション表示スクリプト
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class option_show : MonoBehaviour {

	
	public Canvas option_canvas;
	public AudioSource button_se2;//ボタン音
	
	
	public void OnClick()
	{
		
		
		option_canvas.enabled = true;
		button_se2.Play ();

		
	}
	
	// Use this for initialization
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
