//ドロップコイン移動スクリプト
using UnityEngine;
using System.Collections;

public class coin_turn : MonoBehaviour {

	public GameObject PLAYER;//プレイヤーを追従し自動取得に
	public GameObject coin;
	
	public Vector3 move_point;

	public int add_score_coin_skill = 100;//取得スコア


	// Use this for initialization
	void Start () {

		PLAYER = GameObject.FindWithTag ("Player");


	//	RB.AddForce (transform.up * 5.0f, ForceMode.Impulse);


	
	}
	//トリガーで判定　触れたら消える
	void OnTriggerEnter(Collider collider)
	{
		//プレイヤーとの衝突のみ消えるように
		if (collider.gameObject.tag == "Player") {
			GameObject.FindWithTag ("Player").GetComponent<char_status> ().RecoverytSkillpoint (10);
			GameObject.Find("Canvas").GetComponent<Kill_Count_script>().Score_Update(add_score_coin_skill);//スコア更新
			Destroy (coin);
		}

	}
	
	// Update is called once per frame
	void Update () {

		move_point = new Vector3 (PLAYER.transform.position.x, PLAYER.transform.position.y+3.0f, PLAYER.transform.position.z);//enemyが向かう場所
		transform.LookAt (move_point);//方向に向ける

		transform.position += transform.forward * 0.6f;
	//	RB.AddForce (transform.forward *0.5f, ForceMode.Impulse);

		transform.Rotate (0, 0.5f, 0);
	
	}
}
