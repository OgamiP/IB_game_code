//マウスオーバーで説明表示
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class OP_object_num :MonoBehaviour,IPointerEnterHandler 
{


	
	public Text Info_message;//マウスカーソルを乗せたときに表示する文字
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		
		Info_message.text = "敵を出現させるオブジェクト数を設定します";
		
		
		
	}






	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
