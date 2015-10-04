using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


public class OP_Timelimit :MonoBehaviour,IPointerEnterHandler 
{

	public Text Info_message;//マウスカーソルを乗せたときに表示する文字

	public void OnPointerEnter(PointerEventData eventData)
	{
		
		Info_message.text = "制限時間を設定します(単位は秒)";
		
		
		
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
