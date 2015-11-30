//画面右上にTipsを表示する
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tips_Controller : MonoBehaviour {

	//Tipsを表示するかどうか(1:表示)
	static public int Tips_Flag = 1;

	//表示テキスト
	public Text Tips_Text;
	//表示Tipsを決定する変数
	private int Tips_Selecter;
	

	public IEnumerator Show_Tips()
	{
		//適当に乱数を生成し表示Tips内容を変化させる
		Tips_Selecter = Random.Range (0, 6);

		//待つ
		yield return new WaitForSeconds (10.0f);

		if (Tips_Selecter == 0) {
			Tips_Text.enabled = true;
			Tips_Text.text = "Tips:「e」でローリングができます";
		}else if(Tips_Selecter == 1){
			Tips_Text.enabled = true;
			Tips_Text.text = "Tips:3段ジャンプからもう一度「スペース」で飛行モードになります";
		}else if(Tips_Selecter == 2){
			Tips_Text.enabled = true;
			Tips_Text.text = "Tips:「Now!!」の表示のタイミングでスキルを発動するとコンボになり得点が加算されます";
		}else if(Tips_Selecter == 3){
			Tips_Text.enabled = true;
			Tips_Text.text = "Tips:敵を倒したときのドロップアイテムでSPを回復します";
		}else{
			//Tips非表示
			Tips_Text.enabled = false;

		}
		//自身を再コール
		StartCoroutine("Show_Tips");


	}

	// Use this for initialization
	void Start () {
		//Tips非表示
		Tips_Text.enabled = false;
		//Tips_Flagが1ならコルーチン開始
		if (Tips_Flag == 1) {
			StartCoroutine ("Show_Tips");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
