//敵リスポーンスクリプト
using UnityEngine;
using System.Collections;

public class respawn_area_script : MonoBehaviour {

	public GameObject prefab;//プレハブ生成


//	public int max_Instantiate = 5;//最大生成数
	public int prefab_num;//フィールド上の生成した数

	public GameObject respawn_zone;//自身　タイムリミットで消す

	public static float Respawn_freq = 10f;//敵の再出現間隔

	//敵出現コルーチン
	private IEnumerator Respawn()
	{
		//まだ時間内かつ、最大数に満たない場合であれば敵を出す
		prefab_num = GameObject.FindGameObjectsWithTag ("enemy").Length;//敵の数を取得

			Debug.Log ("enemy respawn!");
			Instantiate (prefab, transform.position, Quaternion.identity);
			yield return new WaitForSeconds (Respawn_freq);



		
		StartCoroutine ("Respawn");
	}



	// Use this for initialization
	void Start () {

	//	Instantiate (prefab,transform.position,Quaternion.identity);
		StartCoroutine ("Respawn");//コルーチン開始

	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (GameObject.Find ("Canvas").GetComponent<time_count> ().limit_time < 0) {

			Destroy(respawn_zone);

		}
*/

	}
}
