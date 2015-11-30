//コンボスクリプト(UI)
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class combo_scriput : MonoBehaviour {

	//画像の取得
	public Image Now_image_Canvas;
	public Sprite Now_image;

	// Use this for initialization
	void Start () {

		Now_image_Canvas.sprite = Now_image;

		Now_image_Canvas.enabled = false;//消しとく
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
