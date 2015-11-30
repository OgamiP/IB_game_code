//gun modeやそのほか出現したパーティクルの空を破壊する
using UnityEngine;
using System.Collections;

public class Clear_Particle : MonoBehaviour {
	
	//particleをゲームオブジェクトとしてキャッシュ

	public GameObject dtp;
	public ParticleSystem destroy_target_particle;
	public float destroy_time = 5.0f;//設定秒で破壊

	public IEnumerator particle_destroy (float time)
	{
		yield return new WaitForSeconds (time);
		Destroy (dtp);


	}

	// Use this for initialization
	void Start () {

		StartCoroutine ("particle_destroy",destroy_time);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
