using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class skill1_cool_time : MonoBehaviour {

	public Slider skill_cool_gauge;
	public Text skill_cool_time_output;
	public float cool_time;
	public Button skill1_button;

	public void skill_cool_restart(float Acc)
	{
		cool_time = Acc;//受け取ったクールタイムを入れる
		//初期化
		skill_cool_time_output.text = cool_time.ToString ();
		skill_cool_gauge.value = cool_time;
	}

	// Use this for initialization
	void Start () {
		//cool time 0で初期化
		cool_time = 0f;
		//cool time 表示　false
		skill_cool_time_output.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//クールタイム管理
		if (cool_time > 0) {
			skill_cool_time_output.enabled = true;
			skill1_button.enabled = false;
			//1秒マイナス
			cool_time -= Time.deltaTime;
			skill_cool_time_output.text = cool_time.ToString ("f1");//to stringの引数で表示桁管理
			skill_cool_gauge.value = cool_time;
		} else {
			skill_cool_time_output.enabled = false;
			skill1_button.enabled = true;			
		}
	}
}
