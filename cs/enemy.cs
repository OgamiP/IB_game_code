using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {


	public GameObject PLAYER;//プレイヤー取得
	public GameObject ENEMY;//最終的に消すために取得
	public GameObject DropItem1;//ドロップアイテム
	public GameObject DropItem2;//ドロップアイテム
	public GameObject DropItem3;//ドロップアイテム
	private Animator anim_E;//enemyアニメータ取得
	private Rigidbody RB;//rigitbody取得

	public Vector3 move_point;//enemyが向かう座標
	public int droprate;//ドロップ率
	private int drop_flag = 0;//何か1ドロップで1

	public float attack_rate = 2.5f;//攻撃頻度


	/*****enemy weapon collider*****/
	public GameObject enemy_weapon;
	/*******************************/

	/*****enemy status*****/
	public int enemy_health = 10;
	/**********************/

	/*****enemy Animator*****/
	private int gotoIdle_EID;//エネミーIdleフラグ
	private int gotoWalk_EID;//エネミーWalkフラグ
	private int gotoAtk1_EID;//エネミーAtk1フラグ
	/**********************/

	/*****enemy range calc*****/
	public float PlayerDistance;//プレイヤーとの距離
	public float Range = 5.0f;//プレイヤーを攻撃する距離
	/*************************/

	/*****enemy sound*****/
	public AudioSource enemy_attacked_sound;
	public AudioClip attacked_sound_1;
	public AudioClip attacked_sound_2;
	private int attacked_sound_random = 0;
	/*********************/

	/*****enemy attack flag*****/
	public int enemy_attack_flag = 0;

	/*****score update*****/
	public int add_score = 1000;//倒されたときに加算するスコア

	/*****hit particle*****/
	public ParticleSystem hit_particle;



	//攻撃待ちコルーチン
	public IEnumerator attack_wait(float wait_time)
	{
		enemy_attack_flag = 1;//攻撃状態フラグ1
		anim_E.SetBool (gotoIdle_EID, true);//次の攻撃までIdleにしておく
		yield return new WaitForSeconds (wait_time);
		enemy_attack_flag = 0;//攻撃状態フラグ0
	}

	//ダメージ与える
	public void Take_damage(int dmg)
	{
		enemy_health -= dmg;


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
		if (enemy_health <= 0 && drop_flag == 0) {
			GameObject.Find("Canvas").GetComponent<Kill_Count_script>().Kill_Flag();//canvas上のkill数表示にアクセス

			//ドロップアイテムをランダムに決定
			droprate = Random.Range(0,100);//0から99の間の乱数
			if(drop_flag == 0)
			{
				drop_flag = 1;//複数ドロップしないようロック
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
			
			}
			GameObject.Find("Canvas").GetComponent<Kill_Count_script>().Score_Update(add_score);
			Destroy(ENEMY,0.5f);
		}
	}

	//攻撃を受けたときの判定(collision)
	void OnCollisionEnter(Collision other)
	{
		//判定に入ってきたのが武器でPlayerがスキルを使用している場合に攻撃判定
		if (other.gameObject.tag == "bullet") {
			
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
			GameObject.Find("Canvas").GetComponent<Kill_Count_script>().Score_Update(add_score);
			Destroy(ENEMY);
		}
	}

	// Use this for initialization
	void Start () {
		//プレイヤー取得
		PLAYER = GameObject.FindWithTag ("Player");

		RB = GetComponent<Rigidbody> ();
		anim_E = GetComponent<Animator> ();
		//ハッシュ設定
		gotoAtk1_EID = Animator.StringToHash("gotoAtk1_E");
		gotoWalk_EID = Animator.StringToHash("gotoWalk_E");
		gotoIdle_EID = Animator.StringToHash("gotoIdle_E");
		
		move_point = new Vector3 (PLAYER.transform.position.x, transform.position.y, PLAYER.transform.position.z);//enemyが向かう場所
		transform.LookAt (move_point);//方向に向ける

		enemy_attack_flag = 0;//攻撃状態フラグ0

	}
	
	// Update is called once per frame
	void Update () {

		PlayerDistance = Vector3.Distance(transform.position,PLAYER.transform.position);//攻撃に行くためにプレイヤーとの距離を計算しておく\
		//設定距離より近いとき攻撃フラグを立てる
		if (PlayerDistance <= Range) {

			anim_E.SetBool (gotoWalk_EID, false);
			anim_E.SetBool (gotoAtk1_EID, true);
			StartCoroutine("attack_wait",attack_rate);



		} else {
			enemy_attack_flag = 0;//攻撃状態フラグ0
			//距離が離れたらまた走るように
			anim_E.SetBool (gotoWalk_EID, true);


			//どこからでもプレイヤーに向かってくるように
			move_point = new Vector3 (PLAYER.transform.position.x, transform.position.y, PLAYER.transform.position.z);//enemyが向かう場所
			transform.LookAt (move_point);//方向に向ける
			transform.position += transform.forward * 0.2F;
			//RB.AddForce (transform.forward *0.3f, ForceMode.Impulse);

		}



	
	}
}
