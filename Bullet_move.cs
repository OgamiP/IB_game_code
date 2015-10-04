//弾丸発射スクリプト
using UnityEngine;
using System.Collections;

public class Bullet_move : MonoBehaviour {

	public Vector3 move_direction;//発射位置
	public float bullet_speed = 10f;//弾速
	public ParticleSystem Gun_Bomb;//発射パーティクル


	//何かに衝突時
	void  OnCollisionEnter(Collision collision)
	{
		//誤爆防止
		if(collision.gameObject.tag != "Player");
	//	Debug.Log("bullet hit");
		Instantiate (Gun_Bomb,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);//bulletと同じ位置
		Gun_Bomb.Play ();

		Destroy(gameObject);


	}

	// Use this for initialization
	void Start () {


		//発射時点のプレイヤーの位置情報をキャッシュ
		move_direction = GameObject.FindWithTag ("Player").transform.forward;
		transform.forward = GameObject.FindWithTag ("Player").transform.forward;

	}
	
	// Update is called once per frame
	void Update () {
		//弾丸移動
		transform.position +=  move_direction * bullet_speed;
	
	}
}
