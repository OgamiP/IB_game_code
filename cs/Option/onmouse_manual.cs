//マウスオーバーで文字表示
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

//マウスオーバーで文字表示
public class onmouse_manual : MonoBehaviour,IPointerEnterHandler
{
	
	
	public Text Info_message;//マウスカーソルを乗せたときに表示する文字
	public AudioSource button_se1;

	public void OnPointerEnter(PointerEventData eventData)
	{

		Info_message.text = "簡易マニュアル";
		button_se1.Play ();
		
		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}