using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Kill_Count_script : MonoBehaviour {



	//result canvas
	public Canvas result_canvas;

	//表示する数字画像の桁
	public Image num1;//一桁目
	public Image num2;//二桁目
	public Image num3;//三桁目

	//表示する数字画像を特定する数値
	private int set_digit1;
	private int set_digit2;
	private int set_digit3;

	//表示するスキル名画像
	public Image skill_name_P;
	public Image skill_name_M;
	
	//number image
	public Sprite image0;
	public Sprite image1;
	public Sprite image2;
	public Sprite image3;
	public Sprite image4;
	public Sprite image5;
	public Sprite image6;
	public Sprite image7;
	public Sprite image8;
	public Sprite image9;
	

	//kill count
	public int Kill_count=0;
	public int Old_Kill_Count=0;//前回と差があったかどうか


	//score output
	public int Total_score = 0;
	public Text score;


	//各桁の値特定関数
	public void Find_number(int cnt)
	{
		if (cnt < 10) {
			number_set(0,0,cnt);

		} else if (100 > cnt && cnt >= 10){
			set_digit2 = cnt / 10;
			set_digit1 = cnt % 10;
			number_set(0,set_digit2,set_digit1);


		}else if(cnt >= 100){
			set_digit3 = cnt / 100;
			set_digit2 = (cnt % 100) / 10;
			set_digit1 = cnt % 10;
			number_set(set_digit3,set_digit2,set_digit1);


		}



	}

	//受け取った数値に対応する数字画像を各桁ごとに表示する関数
	public void number_set(int num_digit3 ,int num_digit2 ,int num_digit1)
	{
		//1桁目
		if(num_digit1 == 0)
			num1.sprite = image0;
		if(num_digit1 == 1)
			num1.sprite = image1;
		if(num_digit1 == 2)
			num1.sprite = image2;
		if(num_digit1 == 3)
			num1.sprite = image3;
		if(num_digit1 == 4)
			num1.sprite = image4;
		if(num_digit1 == 5)
			num1.sprite = image5;
		if(num_digit1 == 6)
			num1.sprite = image6;
		if(num_digit1 == 7)
			num1.sprite = image7;
		if(num_digit1 == 8)
			num1.sprite = image8;
		if(num_digit1 == 9)
			num1.sprite = image9;

		//2桁目
		if(num_digit2 == 0)
			num2.sprite = image0;
		if(num_digit2 == 1)
			num2.sprite = image1;
		if(num_digit2 == 2)
			num2.sprite = image2;
		if(num_digit2 == 3)
			num2.sprite = image3;
		if(num_digit2 == 4)
			num2.sprite = image4;
		if(num_digit2 == 5)
			num2.sprite = image5;
		if(num_digit2 == 6)
			num2.sprite = image6;
		if(num_digit2 == 7)
			num2.sprite = image7;
		if(num_digit2 == 8)
			num2.sprite = image8;
		if(num_digit2 == 9)
			num2.sprite = image9;

		//3桁目
		if(num_digit3 == 0)
			num3.sprite = image0;
		if(num_digit3 == 1)
			num3.sprite = image1;
		if(num_digit3 == 2)
			num3.sprite = image2;
		if(num_digit3 == 3)
			num3.sprite = image3;
		if(num_digit3 == 4)
			num3.sprite = image4;
		if(num_digit3 == 5)
			num3.sprite = image5;
		if(num_digit3 == 6)
			num3.sprite = image6;
		if(num_digit3 == 7)
			num3.sprite = image7;
		if(num_digit3 == 8)
			num3.sprite = image8;
		if(num_digit3 == 9)
			num3.sprite = image9;

		//次回更新用
		Old_Kill_Count = Kill_count;


	}



	//kill count manage
	public void Kill_Flag()
	{

		Kill_count++;
	}

	//score update
	public void Score_Update(int point)
	{
		//スコアを更新し表示
		Total_score += point;
		score.text = Total_score.ToString ();

	}



	// Use this for initialization
	void Start () {


		//result canvas hide
	//	result_canvas.enabled = false;

		//初期値0画像セット
		num1.sprite = image0;
		num2.sprite = image0;
		num3.sprite = image0;

		//スキル名画像消しとく
		skill_name_P.enabled = false;
		skill_name_M.enabled = false;

		//スコア0で初期化
		score.text = Total_score.ToString ();

	
	}
	
	// Update is called once per frame
	void Update () {


	

			//killが更新されたとき
			if (Kill_count != Old_Kill_Count) {

			Find_number(Kill_count);



		}


	}



}
