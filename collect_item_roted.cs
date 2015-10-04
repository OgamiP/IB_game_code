using UnityEngine;
using System.Collections;

public class collect_item_roted : MonoBehaviour {

	public GameObject this_collect_item;//後で消す為自身をキャッシュ

	void OnCollisionEnter(Collision other)
	{
		//プレイヤーが取得したとき
		if (other.gameObject.tag == "Player") {
		//	GameObject.Find("Canvas").GetComponent<time_count>().Collect_num += 1;//集めた数を足す
			time_count.Collect_num+=1;
			//自身を消す
			Destroy(this_collect_item);

		}

	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (0, 0.5f, 0);//アイテム回転
	
	}
}
