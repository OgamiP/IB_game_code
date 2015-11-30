//トレイルパーティクル制御
using UnityEngine;
using System.Collections;

public class particle_test : MonoBehaviour {

	//public ParticleSystem test_particle;
	public TrailRenderer test_trail;//武器のトレイル
	public TrailRenderer foot_trail;//足のトレイル

	//トレイル用ライト取得
	public Light weapon_light;
	public Light foot_trail_right;

	public float trail_time;//トレイルの発生時間

	//コンボに関する変数
	public int combo_count = 0;
	public int max_combo_count = 0;//最大コンボ数
	public int Combo_Flag = 0;



	public IEnumerator trail_and_particle(float time)
	{
		//スキルの終わりを各スキルごとにキャッシュしておく

		test_trail.enabled = true;//トレイル入れる
		combo_count += 1;//コンボ+1
		yield return new WaitForSeconds (time);
		//onになってる可能性のあるトレイル,ライトは全部きる
		test_trail.enabled = false;
		foot_trail.enabled = false;
		weapon_light.enabled = false;
		foot_trail_right.enabled = false;

		GameObject.Find ("Canvas").GetComponent<combo_scriput> ().Now_image_Canvas.enabled = true;//コンボ可能イメージ表示



		StartCoroutine ("Combo_Success_Time",time);//コンボ許容に移行




	}

	//コンボ許可コルーチン
	public IEnumerator Combo_Success_Time(float time)
	{
	//	GameObject.FindWithTag("Player").GetComponent<char_skill>().Skill_Flag = 0;//一度skill flagを0にする
		yield return new WaitForSeconds (time);
		if (test_trail.enabled == true) {

			//combo_count += 1;//コンボ+1

			yield break;//コンボ許容時間内にもう一度onでbreak

		}
		GameObject.Find ("Canvas").GetComponent<combo_scriput> ().Now_image_Canvas.enabled = false;//nowを消す=コンボ終了
		//表示中のスキル名画像を消す
		GameObject.Find ("Canvas").GetComponent<Kill_Count_script> ().skill_name_P.enabled = false;
		GameObject.Find ("Canvas").GetComponent<Kill_Count_script> ().skill_name_M.enabled = false;

		//コンボ数リセット
		//最大コンボ数更新
		if (combo_count > max_combo_count) {
			max_combo_count = combo_count;
		}

		combo_count = 0;



	}


	//コンボフラグon
	public void Combo_Flag_On()
	{

		Combo_Flag = 1;


	}




	// Use this for initialization
	void Start () {
		Combo_Flag = 0;//コンボフラグ0
		//トレイルを切っておく
		test_trail.enabled = false;
		foot_trail.enabled = false;

		//ライトをきっておく
		weapon_light.enabled = false;
		foot_trail_right.enabled = false;
	
	
	}
	
	// Update is called once per frame
	void Update () {

		//テスト出力
		if (Input.GetKey ("p")) {
		//	test_particle.Play();

		
			test_trail.enabled = false;//トレイル切る



		}
		if (Input.GetKey ("l")) {
			//	test_particle.Play();
			
			test_trail.enabled = true;//トレイル入れる
			
			
			
		}

	
	}
}
