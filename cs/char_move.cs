//プレイヤーキャラクターのメインアクションスクリプト
using UnityEngine;
using System.Collections;

public class char_move : MonoBehaviour {



	private Rigidbody RG;
	private Animator anim;


	//ジャンプパーティクル用
	public ParticleSystemRenderer Jump_particle;
	public ParticleSystemRenderer Jump_wing_dust_particle;


	char_skill SKILL_FLAG;//スキル使用中にプレイヤーの移動を制限
	cahr_sound CHAR_SOUND;//サウンド

	/*****アニメータ用変数*****/
	private int GotoRunID;//runフラグ
	private int GotoBackID;//backフラグ
	private int GotoJump1ID;//jump1フラグ
	private int GotoJump2ID;//jump2フラグ
	private int GotoJump3ID;//jump3フラグ
	private int GotoFly1ID;//Fly1フラグ
	private int GotoFly2ID;//Fly2フラグ
	private int GotoFlyoutID;//Flyoutフラグ
	private int GotoRightturnID;//Rightturnフラグ
	private int GotoLeftturnID;//Leftturnフラグ
	private int GotoRollingID;//ローリングフラグ

	private int GotoIdleID;//待機フラグ(接地フラグ)

	/**Gun mode**/
	private int GotoGunmodeID;//Gunmode移行フラグ
	private int GotoFireID;//Gun発射フラグ
	private int GotoRun_GunID;//Gunmode Runフラグ
	private int GotoJump1_GunID;//Gun jump1 フラグ
	private int GotoJumpFireID;//Gun fire フラグ
	private int GotoRunFireGunID;//Gun Fire Run フラグ
	private int GotoRolling_GunID;//Gunmode rolling フラグ
	private int GotoBack_GunID;//gun back フラグ
	private int GotoBack_Gun_FileID;//back gun fire  フラグ
	private int GotoRightturnGunID;//right turn gun フラグ
	private int GotoRightturnGunFireID;//right turn gun fire フラグ
	private int GotoLeftturnGunID;//left turn gun　フラグ
	private int GotoLeftturnGunFireID;//left turn gun fire フラグ
	/**************************/

	public int Gun_Mode = 0;//Gunmode flag
	public int Gun_Jump_flag = 0;//gun mode jump flag
	public int jumpcount = 0;//ジャンプカウント
	public int rolling_duration_flag = 0;//回避行動中かどうか判定する
	public float rolling_duration = 5f;

	public float move_speed = 0.4f;//通常移動速度
	public Vector3 acceleration;//加速度




	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		RG = GetComponent<Rigidbody> ();
		SKILL_FLAG = GetComponent<char_skill> ();
		CHAR_SOUND = GetComponent<cahr_sound> (); 

		/*****IDハッシュ設定*****/
		GotoRunID = Animator.StringToHash("gotoRun");//アニメーターでrunへ遷移させるためのもの
		GotoBackID = Animator.StringToHash("gotoBack");//アニメーターでbackへ遷移させるためのもの
		GotoJump1ID = Animator.StringToHash("gotoJump1");
		GotoJump2ID = Animator.StringToHash("gotoJump2");
		GotoJump3ID = Animator.StringToHash("gotoJump3");
		GotoFly1ID = Animator.StringToHash("gotoFly1");
		GotoFly2ID = Animator.StringToHash("gotoFly2");
		GotoIdleID = Animator.StringToHash("gotoIdle");
		GotoFlyoutID = Animator.StringToHash("gotoFlyout");
		GotoRightturnID = Animator.StringToHash("gotoRightturn");
		GotoLeftturnID = Animator.StringToHash("gotoLeftturn");
		GotoRollingID = Animator.StringToHash("gotoRolling");

		/**Gun mode**/
		GotoGunmodeID = Animator.StringToHash("gotoGunmode");
		GotoRun_GunID = Animator.StringToHash("gotoRunGun");
		GotoFireID = Animator.StringToHash("gotoFire");
		GotoJump1_GunID = Animator.StringToHash("gotoJump1Gun");
		GotoJumpFireID = Animator.StringToHash("gotoJumpFire");
		GotoRunFireGunID = Animator.StringToHash("gotoRunFireGun");
		GotoRolling_GunID = Animator.StringToHash("gotoRolling_Gun");
		GotoBack_GunID = Animator.StringToHash("gotoBackGun");
		GotoBack_Gun_FileID = Animator.StringToHash("gotoBackGunFire");
		GotoRightturnGunID = Animator.StringToHash("gotoRightturnGun");
		GotoRightturnGunFireID = Animator.StringToHash ("gotoRightturnGunFire");
		GotoLeftturnGunID = Animator.StringToHash("gotoLeftturnGun");
		GotoLeftturnGunFireID = Animator.StringToHash ("gotoLeftturnGunFire");
		/**********************/

		//ジャンプパーティクルをoffにしておく
		Jump_particle.enabled = false;
		Jump_wing_dust_particle.enabled = false;
	}


	//接地時フラグtrue
	void  OnCollisionEnter(Collision collision)
	{
		//敵.壁とは接地しないことにする
		if (collision.gameObject.tag != "enemy" && collision.gameObject.tag != "wall") {
			//ジャンプカウント初期化
			jumpcount = 0;
			Gun_Jump_flag = 0;
			anim.SetBool (GotoIdleID, true);
			anim.SetBool (GotoRunID, true);
			anim.SetBool (GotoJump1ID, false);
			anim.SetBool (GotoJump1_GunID, false);
			//ジャンプパーティクルoff
			Jump_particle.enabled = false;
			Jump_wing_dust_particle.enabled = false;

		} else if (collision.gameObject.tag == "object") {
			anim.SetBool (GotoIdleID, true);
			anim.SetBool (GotoRunID, true);
			anim.SetBool (GotoJump1ID, false);
			anim.SetBool (GotoJump1_GunID, false);


		}


	}

	//プレイヤーが地面から離れたとき（高地から落ちたときなど）も1段ジャンプと判定し遷移
	//離陸時Idleはfalseに
	void  OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag != "enemy" && Input.GetKey ("space") == false 
		    && collision.gameObject.tag != "wall" && collision.gameObject.tag != "object") {//スペース押してない場合(押してれば通常ジャンプ)
			anim.SetBool (GotoIdleID, false);
			anim.SetBool (GotoRunID, false);
			//	anim.SetBool (GotoJump1ID,true);
			jumpcount += 1;//ジャンプしたとみなし
			anim.SetBool (GotoJump1ID, true);

		}else if(jumpcount == 0 && collision.gameObject.tag == "object"){
			//ジャンプしていない状態でオブジェクトに接地状態で離れたとき
			anim.SetBool (GotoIdleID, true);
			anim.SetBool (GotoRunID, true);
			anim.SetBool (GotoJump1ID, false);
			anim.SetBool (GotoJump1_GunID, false);

		}
	}

	//rolling中にジャンプはできないようrolling timeを設ける
	public IEnumerator Rolling_Time(float duration_time)
	{
		//回避行動フラグ管理
		rolling_duration_flag = 1;
		yield return new WaitForSeconds (duration_time);
		rolling_duration_flag = 0;


	}



	
	// Update is called once per frame
	void Update () {
		//加速度追加
		RG.AddForce (acceleration, ForceMode.Acceleration);

		//移動はスキル使用中負負荷にGun mode時は通常と違う方のフラグを設定
		//前進
		if (Input.GetKey ("w") && SKILL_FLAG.Skill_Flag == 0 && Gun_Mode == 0) {
			transform.position += transform.forward * move_speed;
			anim.SetBool (GotoRunID, true);//w押したときにbool:trueセット
		
		} else {
			anim.SetBool (GotoRunID, false);//それ以外bool:falseセット

			//	anim.SetBool(GotoIdleID,true);
		}


		//後退
		if (Input.GetKey ("s") && SKILL_FLAG.Skill_Flag == 0 && Gun_Mode == 0) {
			transform.position -= transform.forward * move_speed;
			anim.SetBool (GotoBackID, true);//s押したときにbool:trueセット
		} else {
			anim.SetBool (GotoBackID, false);//それ以外bool:falseセット
		}



		//右旋回

		if (Input.GetKey ("d") && SKILL_FLAG.Skill_Flag == 0 && Gun_Mode == 0) {

			transform.position += transform.forward * move_speed / 4f;
			transform.Rotate (0, 4, 0);
			anim.SetBool (GotoRightturnID, true);//w押したときにbool:trueセット
		} else {
			anim.SetBool (GotoRightturnID, false);//それ以外bool:falseセット
			
		}

		//左旋回
		if (Input.GetKey ("a") && SKILL_FLAG.Skill_Flag == 0 && Gun_Mode == 0) {
			transform.position += transform.forward * move_speed / 4f;
			transform.Rotate (0, -4, 0);
			anim.SetBool (GotoLeftturnID, true);//w押したときにbool:trueセット
			
		} else {

			anim.SetBool (GotoLeftturnID, false);//それ以外bool:falseセット
			
		}

		//ローリング(回避行動)行動制限をかけておく
		if (Input.GetKeyDown ("e") && SKILL_FLAG.Skill_Flag == 0 
		    && rolling_duration_flag == 0 && jumpcount == 0 && Gun_Mode == 0) {

			anim.SetBool (GotoRollingID, true);
			RG.AddForce (transform.forward * 15f, ForceMode.Impulse);
			StartCoroutine ("Rolling_Time", rolling_duration);//回避行動フラグフラグ管理へ

		} else {

			anim.SetBool (GotoRollingID, false);

		}

		/*****Gun mode*****/
		//gun fire left mousebutton
		if (Input.GetKeyDown ("z") && Gun_Mode == 0) {
			GameObject.Find("Weapon").GetComponent<SkinnedMeshRenderer>().enabled = false;
			Gun_Mode = 1;//gun mode startf
			anim.SetBool (GotoGunmodeID, true);
		
		} 
	

		//gun mode 前進
		if (Gun_Mode == 1 && Input.GetKey ("w") && SKILL_FLAG.Skill_Flag == 0) {

			transform.position += transform.forward * move_speed;
			anim.SetBool (GotoRun_GunID, true);

		} else {

			anim.SetBool (GotoRun_GunID, false);
		}

		//Gun mode fire前進
		if (Gun_Mode == 1 && Input.GetKey ("w") && SKILL_FLAG.Skill_Flag == 0&& Input.GetMouseButton (0) ) {

			anim.SetBool (GotoRunFireGunID, true);

		} else {

			anim.SetBool (GotoRunFireGunID, false);

		}
		//gun mode 中のジャンプ
		if (jumpcount == 0 && Input.GetButtonDown ("Jump") && SKILL_FLAG.Skill_Flag == 0 
		    && rolling_duration_flag == 0 && Gun_Mode == 1 && Gun_Jump_flag == 0) 
		{
			Gun_Jump_flag = 1;
			RG.AddForce (transform.up * 50f, ForceMode.Impulse);
			anim.SetBool (GotoJump1_GunID, true);
			
		} 

		//gun_fire
		if (Gun_Mode == 1 && Input.GetMouseButton (0)) {

			anim.SetBool (GotoFireID, true);

		} else {
			anim.SetBool (GotoFireID, false);
		}

		//gun jump fire
		if (Gun_Mode == 1 && Input.GetMouseButton (0) && Gun_Jump_flag == 1) {

			anim.SetBool (GotoJumpFireID, true);

		} else {
			anim.SetBool (GotoJumpFireID, false);
		}

		//Run Fire 走りながら右クリック
		if (Gun_Mode == 1 && Input.GetKey ("w") && Input.GetMouseButton (0)) {
			//transform.position += transform.forward * move_speed;

			anim.SetBool (GotoRunFireGunID, true);

		} else {
			anim.SetBool (GotoRunFireGunID, false);
		}

		//Gun back
		if (Gun_Mode == 1 && Input.GetKey ("s") && SKILL_FLAG.Skill_Flag == 0) {
			transform.position -= transform.forward * move_speed;
			anim.SetBool (GotoBack_GunID, true);
		} else {
			anim.SetBool (GotoBack_GunID, false);
		}

		//gun back fire
		if (Gun_Mode == 1 && Input.GetKey ("s") && SKILL_FLAG.Skill_Flag == 0 && Input.GetMouseButton(0)) {

			anim.SetBool (GotoBack_Gun_FileID, true);
		} else {
			anim.SetBool (GotoBack_Gun_FileID, false);
		}


		//gun mode right turn
		
		if (Input.GetKey ("d") && SKILL_FLAG.Skill_Flag == 0 && Gun_Mode == 1) {
			
			transform.position += transform.forward * move_speed / 4f;
			transform.Rotate (0, 4, 0);
			anim.SetBool (GotoRightturnGunID, true);//w押したときにbool:trueセット
		} else {
			anim.SetBool (GotoRightturnGunID, false);//それ以外bool:falseセット
			
		}

		if (Input.GetKey ("d") && SKILL_FLAG.Skill_Flag == 0 && Gun_Mode == 1 && Input.GetMouseButton(0)) {

			anim.SetBool (GotoRightturnGunFireID, true);//w押したときにbool:trueセット
		} else {
			anim.SetBool (GotoRightturnGunFireID, false);//それ以外bool:falseセット
			
		}


		
		//gun mode left turn
		if (Input.GetKey ("a") && SKILL_FLAG.Skill_Flag == 0 && Gun_Mode == 1) {
			transform.position += transform.forward * move_speed / 4f;
			transform.Rotate (0, -4, 0);
			anim.SetBool (GotoLeftturnGunID, true);//w押したときにbool:trueセット
			
		} else {
			
			anim.SetBool (GotoLeftturnGunID, false);//それ以外bool:falseセット
			
		}

		if (Input.GetKey ("a") && SKILL_FLAG.Skill_Flag == 0 && Gun_Mode == 1 && Input.GetMouseButton(0)) {

			anim.SetBool (GotoLeftturnGunFireID, true);//w押したときにbool:trueセット
			
		} else {
			
			anim.SetBool (GotoLeftturnGunFireID, false);//それ以外bool:falseセット
			
		}


		//gun mode rolling
		if (Gun_Mode == 1 && Input.GetKeyDown ("e") && SKILL_FLAG.Skill_Flag == 0 
			&& rolling_duration_flag == 0 && jumpcount == 0) {
			anim.SetBool (GotoRolling_GunID, true);
			RG.AddForce (transform.forward * 15f, ForceMode.Impulse);
			StartCoroutine ("Rolling_Time", rolling_duration);//回避行動フラグフラグ管理へ


		} else {
			anim.SetBool (GotoRolling_GunID, false);
		}


		//gun mode end
		if (Input.GetKeyDown ("x") && Gun_Mode == 1) {

			Gun_Mode = 0;
			anim.SetBool(GotoGunmodeID,false);
			GameObject.Find("Weapon").GetComponent<SkinnedMeshRenderer>().enabled = true;


		}

		/*****************/


		//一段ジャンプ
		//スキル使用中はジャンプ禁止
		if (jumpcount == 0 && Input.GetButtonDown ("Jump") && SKILL_FLAG.Skill_Flag == 0 && rolling_duration_flag == 0 && Gun_Mode == 0) {
			GetComponent<cahr_sound>().landing_sound_flag = 0;//着地サウンドフラグ0に


			anim.SetBool (GotoIdleID, false);
			anim.SetBool (GotoRunID, false);
			jumpcount++;
			RG.AddForce (transform.up * 50f, ForceMode.Impulse);
			anim.SetBool (GotoJump1ID, true);

		} else if (jumpcount == 1 && Input.GetButtonDown ("Jump")) {//2段ジャンプ
			jumpcount++;
			RG.AddForce (transform.up * 70f, ForceMode.Impulse);
			anim.SetBool (GotoJump2ID, true);
			//ジャンプパーティクルonに
			Jump_particle.enabled = true;



		} else if (jumpcount == 2 && Input.GetButtonDown ("Jump")) {//3段ジャンプ
			jumpcount++;
			//RG.AddForce (transform.forward * 30f, ForceMode.Impulse);
			RG.AddForce (transform.up * 80f, ForceMode.Impulse);
			anim.SetBool (GotoJump3ID, true);

		} else if (jumpcount >= 3 && Input.GetButtonDown ("Jump") ) {//飛行
			Jump_wing_dust_particle.enabled = true;//羽が落ちるパーティクルを発生

			if(jumpcount==3)
			{			//jumpcountは4以上を保つ
				jumpcount++;
				RG.AddForce(transform.up * 70f,ForceMode.Impulse);//一回強く上げる
				anim.SetBool(GotoFly1ID,true);
				anim.SetBool(GotoFly2ID,true);

			}else{
				jumpcount++;
				RG.AddForce(transform.up * 70f,ForceMode.Impulse);//押したときに浮かす
			//	RG.AddForce(transform.forward * 10f,ForceMode.Impulse);
				anim.SetBool(GotoFly2ID,true);
			}


		}else{
			//anim.SetBool(GotoJump1ID,false);
			anim.SetBool(GotoJump2ID,false);
			anim.SetBool(GotoJump3ID,false);
			anim.SetBool(GotoFly1ID,false);
		}

		//飛行中にQで下降する
		if (jumpcount >= 4 && Input.GetKey ("q")) {
			RG.AddForce (transform.up * -2.0f, ForceMode.Impulse);
			anim.SetBool (GotoFlyoutID, true);


		} else {
			anim.SetBool (GotoFlyoutID, false);

	}

		//jumopcount3まではメリハリのあるジャンプに
		if (jumpcount <= 3) {
			RG.AddForce (transform.up * -2f, ForceMode.VelocityChange);
		}
	}
}
