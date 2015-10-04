using UnityEngine;
using System.Collections;

public class enemy_weapon_script : MonoBehaviour {

	public GameObject enemy;//敵武器


	//攻撃を与える
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Debug.Log("ehit");
			GameObject.FindWithTag("Player").GetComponent<char_status>().TakeDamage(10);//playerに10のダメージ

		}

	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
