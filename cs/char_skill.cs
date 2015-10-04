using UnityEngine;
using System.Collections;

public class char_skill : MonoBehaviour {

	public GameObject PLAYER;
	public GameObject Weapon;//プレイヤーの武器を取得
	private Animator anim;


	particle_test Trail_particle;//トレイル取得

	//各スキルボタン押した瞬間からのタイム兼スキル終わった後のNow表示までの時間
	public float Skill1_Time = 1.5f;
	public float Skill2_Time = 1.2f;
	public float Skill3_Time = 1.6f;
	public float Skill4_Time = 2.4f;

	public float skill_duration_time = 0f;//スキルの持続時間武器当たり判定削除に使用

	public int Skill_Flag = 0;//スキル使用中かどうか(プレイヤーの移動をさせないように等)


//	private int gotoAtk1ID;//攻撃1フラグ

	// Use this for initialization
	void Start () {
		Trail_particle = GetComponent<particle_test> ();
		anim = GetComponent<Animator> ();
	//	gotoAtk1ID = Animator.StringToHash("gotoAtk1");

		//武器の当たり判定を切っておく
		Weapon.GetComponent<Collider> ().enabled = false;



	
	}

	public void state_atk1(int ID)
	{
		if (ID == 1) {

			anim.SetTrigger ("gotoAtk1");
			skill_duration_time += Skill1_Time*0.8f;//8割り時間
			GameObject.Find ("Canvas").GetComponent<combo_scriput> ().Now_image_Canvas.enabled = false;//nowを消す
			//スキル1のみ足のトレイル,ライトを個別にon
			GameObject.Find("weapon").GetComponent<particle_test>().foot_trail.enabled = true;
			GameObject.Find("weapon").GetComponent<particle_test>().foot_trail_right.enabled = true;
			GameObject.Find("weapon").GetComponent<particle_test>().StartCoroutine("trail_and_particle",Skill1_Time);
			GameObject.Find("weapon").GetComponent<particle_test>().Combo_Flag_On();//コンボフラグon

		} else if (ID == 2) {

			anim.SetTrigger ("gotoAtk2");
			skill_duration_time += Skill2_Time*0.8f;
			GameObject.Find ("Canvas").GetComponent<combo_scriput> ().Now_image_Canvas.enabled = false;//nowを消す
			GameObject.Find("weapon").GetComponent<particle_test>().weapon_light.enabled = true;//ライトon
			GameObject.Find("weapon").GetComponent<particle_test>().StartCoroutine("trail_and_particle",Skill2_Time);
			GameObject.Find("weapon").GetComponent<particle_test>().Combo_Flag_On();//コンボフラグon

		} else if (ID == 3) {

			anim.SetTrigger("gotoAtk3");
			skill_duration_time += Skill3_Time*0.8f;
			GameObject.Find ("Canvas").GetComponent<combo_scriput> ().Now_image_Canvas.enabled = false;//nowを消す
			GameObject.Find("weapon").GetComponent<particle_test>().weapon_light.enabled = true;//ライトon
			GameObject.Find("weapon").GetComponent<particle_test>().StartCoroutine("trail_and_particle",Skill3_Time);
			GameObject.Find("weapon").GetComponent<particle_test>().Combo_Flag_On();//コンボフラグon

		}else if (ID == 4) {

			anim.SetTrigger("gotoAtk4");
			skill_duration_time += Skill4_Time*0.8f;
			GameObject.Find ("Canvas").GetComponent<combo_scriput> ().Now_image_Canvas.enabled = false;//nowを消す
			GameObject.Find("weapon").GetComponent<particle_test>().weapon_light.enabled = true;//ライトon
			GameObject.Find("weapon").GetComponent<particle_test>().StartCoroutine("trail_and_particle",Skill4_Time);
			GameObject.Find("weapon").GetComponent<particle_test>().Combo_Flag_On();//コンボフラグon
		}



	}
	
	// Update is called once per frame
	void Update () {

		//gun mode でないときのみ
		if (GameObject.FindWithTag ("Player").GetComponent<char_move> ().Gun_Mode == 0) {
		
			if (skill_duration_time >= 0) {
				//使用スキルの持続時間を足しこんでいく最終的に0で現在何もスキルが持続していないのいで当たり判定を消せる
				skill_duration_time -= Time.deltaTime;
				GameObject.Find ("weapon").GetComponent<Collider> ().enabled = true;
				Skill_Flag = 1;
			} else {
				GameObject.Find ("weapon").GetComponent<Collider> ().enabled = false;
				Skill_Flag = 0;

			}

	
		}


	}
}
