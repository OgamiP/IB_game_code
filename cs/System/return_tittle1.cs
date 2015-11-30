//タイトルに戻る
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class return_tittle1 : MonoBehaviour {

	public Canvas menu_canvas;

	public AudioSource button_se2;//ボタン音
	
	
	
	public void OnClick()
	{
		

		menu_canvas.enabled = false;
		button_se2.Play ();
	}
	
	// Use this for initialization
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
