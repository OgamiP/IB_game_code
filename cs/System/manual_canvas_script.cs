//マニュアル表示スクリプト
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class manual_canvas_script : MonoBehaviour {

	public Canvas manual_canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			manual_canvas.enabled = false;

		}
	
	}
}
