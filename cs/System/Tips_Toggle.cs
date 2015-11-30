//Tipsを表示・非表示を管理する
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tips_Toggle : MonoBehaviour {

	//トグル
	public Toggle isTips;

	//トグルが更新されたときTips_Flagに変更を反映
	public void Change_Tips_Toggle()
	{
		if (isTips.isOn == true) {
	//		Debug.Log("on");
			Tips_Controller.Tips_Flag = 1;

		} else if (isTips.isOn == false) {
	//		Debug.Log("off");
			Tips_Controller.Tips_Flag = 0;
		}
	

	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
