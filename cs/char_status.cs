//キャラクターの基本的なステータスを管理

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class char_status : MonoBehaviour 
{

	//キャラクターステータス
	
	//最大体力
	public int max_health = 1000;
	//現在体力
	public int health = 1000;
	//最大スキルポイント
	public int max_skill_point = 100;
	//スキルゲージポイント
	public int skill_point = 100;
	//最大値超えたときの処理用
	public int Limit_over;
	
	//ヘルスバー
	public Slider healthSlider;
	//スキルゲージバー
	public Slider skillber;

	//スキル使用時メッセージ表示
	public Text skill_use_message;

	//ヘルス値表示テキスト
	public Text healthprint;
	//スキルポイント表示テキスト
	public Text skillprint;
	

	//体力管理ダメージを受けたとき
	public void TakeDamage(int damage)
	{
		health -= damage;
		healthSlider.value = health;
		healthprint.text = health.ToString ();//表示
	}

	//体力回復
	public void Recoverythealthpoint(int RP)
	{
		//スキルポイントが最大状態でないときのみ回復処理
		if (health != max_health) {
			Limit_over = health + RP;
			if (Limit_over >= max_health) {
				health = max_health;//最大値にする
				healthSlider.value = health;
				healthprint.text = health.ToString ();//表示
				
			} else {
				health += RP;//回復
				healthSlider.value = health;
				healthprint.text = health.ToString ();//表示
			}
			
			
			
		}

	}
		




	//スキルを使ったときに消費する
	public void Useskill(int UseSP)
	{
		if (skill_point >= UseSP) {
			skill_point -= UseSP;
			skillber.value = skill_point;
			skillprint.text = skill_point.ToString();//表示
		//	skill_use_message.text = "スキル使用";//使用時メッセージ
		} else {

			//skill_use_message.text = "SP不足!";//使用負荷時メッセージ

		}
	}

	//スキルポイント回復処理
	public void RecoverytSkillpoint(int RP)
	{
		//スキルポイントが最大状態でないときのみ回復処理
		if (skill_point != max_skill_point) {
			Limit_over = skill_point + RP;
			if (Limit_over >= max_skill_point) {
				skill_point = max_skill_point;//最大値にする
				skillber.value = skill_point;
				skillprint.text = skill_point.ToString ();//表示
		
			} else {
				skill_point += RP;//回復
				skillber.value = skill_point;
				skillprint.text = skill_point.ToString ();//表示
			}



		}

	}


	// 初期化
	void Start () {
		//バーセット
		healthSlider.value = health;
		skillber.value = skill_point;

		//ヘルス、スキルポイント初期値表示
		healthprint.text = health.ToString ();
		skillprint.text = skill_point.ToString ();


	
	}
	/*
	// Update is called once per frame
	void Update () {
	
	}

*/




}

