//弾丸スクリプト
using UnityEngine;
using System.Collections;

public class Bullet_script : MonoBehaviour {



	public GameObject this_bullet;//弾オブジェクト
	public GameObject instantiate_position;//弾丸生成場所
	public ParticleSystem Gun_smoke;//発射パ-ティクル

	Rigidbody RB;




	public void bullet_fire()
	{
		//弾丸生成 発射パーティクル生成
		Instantiate (this_bullet,new Vector3(instantiate_position.transform.position.x,instantiate_position.transform.position.y,
		                                     instantiate_position.transform.position.z),Quaternion.identity);

		Instantiate (Gun_smoke,new Vector3(instantiate_position.transform.position.x,instantiate_position.transform.position.y,
		                                   instantiate_position.transform.position.z),Quaternion.identity);




	}

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
