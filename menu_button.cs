using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu_button : MonoBehaviour {

	public Canvas menu_canvas;
	public AudioSource button_se2;//ボタン音


	public void OnClick()
	{

		button_se2.Play ();
		menu_canvas.enabled = true;

	}

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
