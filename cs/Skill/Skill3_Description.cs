//スキルボタンにマウスオーバーで説明を表示や非表示機能
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


public class Skill3_Description : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
	//表示する説明テキスト
	public Text Skill1_Dec;
	//表示するテキストのベースイメージ
	public Image Dec_Base_Image;
	
	//マウスカーソルが入ってきたとき
	public void OnPointerEnter(PointerEventData eventData)
	{
		//テキストとベースイメージを表示
		Skill1_Dec.text = "GLADUALY RISE" + "\n" + "SP1" + "\n" + "CT6.5sec";
		Skill1_Dec.enabled = true;
		Dec_Base_Image.enabled = true;
		
		
	}
	//マウスオーバーが出て行ったとき
	public void OnPointerExit(PointerEventData eventData)
	{
		//テキストとベースイメージを非表示にする
		Skill1_Dec.enabled = false;
		Dec_Base_Image.enabled = false;
	}
	
	
	// Use this for initialization
	void Start () {
		//テキストとベースイメージを非表示にする
		Skill1_Dec.enabled = false;
		Dec_Base_Image.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}