//ゲームスタートボタン
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game_Start_Button : MonoBehaviour {




	public void OnClick()
	{
		Application.LoadLevel("Stage1_battle");
		
	}

	
}
