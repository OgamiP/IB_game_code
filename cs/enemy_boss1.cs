using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enemy_boss1 : MonoBehaviour {

	public GameObject PLAYER;//プレイヤー取得
	public GameObject ENEMY;//最終的に消すために取得
	private Animator anim_E;//enemyアニメータ取得
	private Rigidbody RB;//rigitbody取得
	
	public Vector3 move_point;//enemyが向かう座標

	/*****enemy weapon collider*****/
	public GameObject enemy_weapon;
	/*******************************/
	
	/*****enemy status*****/
	public int enemy_health = 500;
//	public Slider Boss_gauge;
	/**********************/

	/*****enemy attack flag*****/
	public int enemy_attack_flag = 0;//何かしらの攻撃状態かどうか

	public float attack_rate = 5.0f;//攻撃頻度(x秒に1回攻撃)
	public float attack_duration = 0.7f;//攻撃持続時間(=攻撃モーション終了までの必要時間)

	/*****enemy sound*****/
	public AudioSource enemy_attacked_sound;
	public AudioClip attacked_sound_1;
	public AudioClip attacked_sound_2;
	private int attacked_sound_random = 0;
	/*********************/

	/*****enemy Animator*****/
	private int gotoIdle_Boss1ID;//エネミーIdleフラグ
	private int gotoWalk_Boss1ID;//エネミーWalkフラグ
	private int gotoAtk1_Boss1ID;//エネミーAtk1フラグ
	private int gotoAtk2_Boss1ID;//エネミーAtk2フラグ
	/**********************/

	/*****enemy range calc*****/
	public float PlayerDistance;//プレイヤーとの距離
	public float Range = 15.0f;//プレイヤーを攻撃する距離
	/*************************/

	/*****score update*****/
	public int add_score = 50000;//倒されたときに加算するスコア

	/*****hit particle*****/
	public ParticleSystem hit_particle;


	//攻撃待ちコルーチン
	public IEnumerator attack_wait()
	{
		Debug.Log("attack start");
		yield return new WaitForSeconds (attack_duration);//攻撃完了まで待つ
		Debug.Log("attack end");
		anim_E.SetBool (gotoAtk1_Boss1ID, false);//攻撃終了後攻撃false
		Debug.Log("attack flag off");
		anim_E.SetBool (gotoIdle_Boss1ID, true);//攻撃終了後idleで待機する
		yield return new WaitForSeconds (attack_rate);//次の攻撃までidleで待つ
		enemy_attack_flag = 0;//攻撃処理終了合図ロック解除


	}
	
	//ダメージ与える
	public void Take_damage(int dmg)
	{
		enemy_health -= dmg;
//		Boss_gauge.value = enemy_health;
		
		
	}

	
	//攻撃を受けたときの判定(collider)
	void OnTriggerEnter(Collider other)
	{
		//判定に入ってきたのが武器でPlayerがスキルを使用している場合に攻撃判定
		if (other.tag == "weapon") {

			hit_particle.Play();

			//	Debug.Log("Hit!");
			//敵ヘルス下げる
			//攻撃を受けたときにサウンドを乱数により決定
			attacked_sound_random = Random.Range(0,10);
			if(attacked_sound_random > 5)
			{
				
				enemy_attacked_sound.clip = attacked_sound_1;
				enemy_attacked_sound.PlayOneShot(enemy_attacked_sound.clip,0.5f);
				
			}else{
				
				enemy_attacked_sound.clip = attacked_sound_2;
				enemy_attacked_sound.PlayOneShot(enemy_attacked_sound.clip,0.5f);
				
			}

			
			Take_damage(10);
			
		}
		
		//結果的に敵のHPが0になったときに、Killカウントを追加とオブジェクト破壊
		if (enemy_health <= 0) {
			GameObject.Find("Canvas").GetComponent<Kill_Count_script>().Kill_Flag();//canvas上のkill数表示にアクセス
			/*
			//ドロップアイテムをランダムに決定
			droprate = Random.Range(0,100);//0から99の間の乱数
			if(droprate < 50)
			{
				//少し後ろでドロップするように
				Instantiate (DropItem3,new Vector3(transform.position.x,0,transform.position.z+10),Quaternion.identity);//ドロップアイテム出現
			}else if(49 < droprate && droprate < 76){
				//少し後ろでドロップするように
				Instantiate (DropItem1,new Vector3(transform.position.x,0,transform.position.z+10),Quaternion.identity);//ドロップアイテム出現
				
			}else if(75 < droprate){
				//少し後ろでドロップするように
				Instantiate (DropItem2,new Vector3(transform.position.x,0,transform.position.z+10),Quaternion.identity);//ドロップアイテム出現
				
			}
			*/
			GameObject.Find("Canvas").GetComponent<Kill_Count_script>().Score_Update(add_score);
			Destroy(ENEMY);
		}
	}


	
	//攻撃を受けたときの判定(collision)
	void OnCollisionEnter(Collision other)
	{
		//判定に入ってきたのが武器でPlayerがスキルを使用している場合に攻撃判定
		if (other.gameObject.tag == "bullet") {
			
	//		hit_particle.Play();
			
			//	Debug.Log("Hit!");
			//敵ヘルス下げる
			//攻撃を受けたときにサウンドを乱数により決定
			/*
			attacked_sound_random = Random.Range(0,10);
			if(attacked_sound_random > 5)
			{
				
				enemy_attacked_sound.clip = attacked_sound_1;
				enemy_attacked_sound.PlayOneShot(enemy_attacked_sound.clip,0.5f);
				
			}else{
				
				enemy_attacked_sound.clip = attacked_sound_2;
				enemy_attacked_sound.PlayOneShot(enemy_attacked_sound.clip,0.5f);
				
			}
			*/
			
			Take_damage(10);
			
		}
		
		//結果的に敵のHPが0になったときに、Killカウントを追加とオブジェクト破壊
		if (enemy_health <= 0) {
			GameObject.Find("Canvas").GetComponent<Kill_Count_script>().Kill_Flag();//canvas上のkill数表示にアクセス
			/*
			//ドロップアイテムをランダムに決定
			droprate = Random.Range(0,100);//0から99の間の乱数
			if(droprate < 50)
			{
				//少し後ろでドロップするように
				Instantiate (DropItem3,new Vector3(transform.position.x,0,transform.position.z+10),Quaternion.identity);//ドロップアイテム出現
			}else if(49 < droprate && droprate < 76){
				//少し後ろでドロップするように
				Instantiate (DropItem1,new Vector3(transform.position.x,0,transform.position.z+10),Quaternion.identity);//ドロップアイテム出現
				
			}else if(75 < droprate){
				//少し後ろでドロップするように
				Instantiate (DropItem2,new Vector3(transform.position.x,0,transform.position.z+10),Quaternion.identity);//ドロップアイテム出現
				
			}
			*/
			GameObject.Find("Canvas").GetComponent<Kill_Count_script>().Score_Update(add_score);
			Destroy(ENEMY);
		}
	}

	public void Boss1_Attack1()
	{
		//攻撃開始合図
		Debug.Log("attack flag");
		enemy_attack_flag = 1;//updateで再度呼ばれないようにロック
		anim_E.SetBool (gotoAtk1_Boss1ID, true);
		anim_E.SetBool (gotoIdle_Boss1ID, false);

		StartCoroutine("attack_wait");



	}
	

	// Use this for initialization
	void Start () {

		//プレイヤー取得
		PLAYER = GameObject.FindWithTag ("Player");
		
		RB = GetComponent<Rigidbody> ();
		anim_E = GetComponent<Animator> ();
		//ハッシュ設定
		gotoAtk1_Boss1ID = Animator.StringToHash("gotoAtk1_Boss1");
		gotoAtk2_Boss1ID = Animator.StringToHash("gotoAtk2_Boss1");
		gotoWalk_Boss1ID = Animator.StringToHash("gotoWalk_Boss1");
		gotoIdle_Boss1ID = Animator.StringToHash("gotoIdle_Boss1");
		
		move_point = new Vector3 (PLAYER.transform.position.x, transform.position.y, PLAYER.transform.position.z);//enemyが向かう場所
		transform.LookAt (move_point);//方向に向ける
		
		enemy_attack_flag = 0;//攻撃状態フラグ0

	//	Boss_gauge.value = enemy_health;
	
	}
	
	// Update is called once per frame
	void Update () {

		PlayerDistance = Vector3.Distance(transform.position,PLAYER.transform.position);//攻撃に行くためにプレイヤーとの距離を計算しておく
		//設定距離より近いとき攻撃フラグを立てる
		if (PlayerDistance <= Range && enemy_attack_flag == 0) {
			Debug.Log("boss atk");
			anim_E.SetBool (gotoWalk_Boss1ID, false);//直進停止
			Boss1_Attack1();
			
			
		} else if(PlayerDistance > Range){
			enemy_attack_flag = 0;//攻撃状態フラグ0
			//距離が離れたらまた走るように
			anim_E.SetBool (gotoAtk1_Boss1ID, false);
			anim_E.SetBool (gotoWalk_Boss1ID, true);

			//どこからでもプレイヤーに向かってくるように
			move_point = new Vector3 (PLAYER.transform.position.x, transform.position.y, PLAYER.transform.position.z);//enemyが向かう場所
			transform.LookAt (move_point);//方向に向ける
			transform.position += transform.forward * 0.2F;
			//RB.AddForce (transform.forward *0.3f, ForceMode.Impulse);
			
		}






	
	}
}
