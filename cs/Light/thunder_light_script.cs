//環境ライトスクリプト
using UnityEngine;
using System.Collections;

public class thunder_light_script : MonoBehaviour {

	public Light thunder_light;//雷ライト

	public float light_intensity = 1.0f;//ライトの初期光度

	public int wait_flag = 0;//点灯待ちフラグ

	//ライトを光らせる間隔
	public float light_freq = 1.0f;

	public IEnumerator Thunder_Light(float freq)
	{

		yield return new WaitForSeconds (freq);
		//リセット
		light_intensity = 1.0f;
		thunder_light.intensity = 1.0f;
		wait_flag = 0;//フラグリセット

	}

	// Use this for initialization
	void Start () {

		thunder_light.intensity = 0f;
		StartCoroutine("Thunder_Light",light_freq);//次の点灯まで待つ
	}
	
	// Update is called once per frame
	void Update () {

		if (thunder_light.intensity > 0) {
			light_intensity -= (Time.deltaTime / 3f);//徐々に下げる
			thunder_light.intensity = light_intensity;

		}

		if (thunder_light.intensity <= 0 && wait_flag == 0) {
			wait_flag = 1;//多重に呼び出されることを防止
			StartCoroutine("Thunder_Light",light_freq);//次の点灯まで待つ

		}
	
	}
}
