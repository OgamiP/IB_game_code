using UnityEngine;
using System.Collections;

public class Flashing_light : MonoBehaviour {


//点滅させるライト
	public Light flashing_light;
	public float light_intensity = 8.0f;
	public int flashing_late = 0;//点滅頻度


	//点滅
	public IEnumerator flashing(int rate)
	{
		flashing_light.intensity = light_intensity = 8.0f;//点灯
		flashing_late = Random.Range (5, 10);//ライトが消灯している時間をランダムに決定
		yield return new WaitForSeconds (rate);//ライト点灯時間
		flashing_late = Random.Range (1, 3);//ライトが消灯している時間をランダムに決定
		flashing_light.intensity = 0f;//消す
		yield return new WaitForSeconds (rate);//ライト消灯
		StartCoroutine ("flashing", flashing_late);

	}


	// Use this for initialization
	void Start () {
		flashing_late = Random.Range (2, 10);//ライトが消灯している時間をランダムに決定
		StartCoroutine ("flashing", flashing_late);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
