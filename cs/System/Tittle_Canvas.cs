//タイトルキャンバス
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tittle_Canvas : MonoBehaviour {

	public Canvas menu_canvas;
	public Canvas Manual_canvas;
	public Canvas option_canvas;

	// Use this for initialization
	void Start () {
		//後から出現させる為消しておく
		menu_canvas.enabled = false;
		Manual_canvas.enabled = false;
		option_canvas.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
