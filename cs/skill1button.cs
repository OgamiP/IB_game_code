using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class skill1button : MonoBehaviour {

	public GameObject PLAYER;//プレイヤー取得




	char_status PINFO;
	char_skill SKILL;//スキルを使うため

	public Sprite skill_name_image;
	public float cool_time = 4.0f;//クールタイム

	public void OnClick()
	{
		PINFO = PLAYER.GetComponent<char_status> ();
		SKILL = PLAYER.GetComponent<char_skill> ();


		if (PINFO.skill_point <= 0) {
			SKILL.state_atk1 (0);//フラグ

		} else {

			PINFO.Useskill (1);//スキルポイント10使うことに
			//スキル名表示
			GameObject.Find("Canvas").GetComponent<Kill_Count_script>().skill_name_P.sprite = skill_name_image;
			GameObject.Find("Canvas").GetComponent<Kill_Count_script>().skill_name_P.enabled = true;
		
			SKILL.state_atk1 (1);//フラグ

			GetComponent<skill1_cool_time>().skill_cool_restart(cool_time);//クールタイム開始
		}

	}


	void Update()
	{



	}
}



