//マウスオーバーで文字表示
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


public class onmouse_quit : MonoBehaviour ,IPointerEnterHandler
{

	
	
	public Text Info_message;//マウスカーソルを乗せたときに表示する文字
	public AudioSource button_se1;

	public void OnPointerEnter(PointerEventData eventData)
	{
		
		
		Info_message.text = "ゲームを終了";
		button_se1.Play ();
		
		
	}
	
	
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}






}
