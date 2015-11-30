//カメラスクリプト
using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	public GameObject PLAYER;//プレイヤー取得(通常カメラ用gizmo)
	public GameObject Head_Gizmo;//プレイヤーの頭部gizmoを取得(fpsカメラ用)
	//高さ
	public float height = 3.0f;
	//カメラ距離(半径)
	public float radius = 15.0f;
	//目標の高さ
	private float targetheight;
	//回転角度
	private float rotatedegree;
	//新しい目標地点
	private Vector3 newposition;


	//対象がカメラに対し正面の場合、キー入力でカメラを背後に持っていくための新しい位置情報
	private Vector3 Move_Back_camera;
	private Vector3 Move_Back_camera_point;



	// Use this for initialization
	void Start () {

		//カメラの初期位置
		transform.position = (transform.position - PLAYER.transform.position).normalized * radius + PLAYER.transform.position;
		//カメラの初期高さ
		targetheight = PLAYER.transform.position.y;
		transform.position =new Vector3(transform.position.x, targetheight+height, transform.position.z);

		transform.LookAt (PLAYER.transform.position);
	}
	
	// Update is called once per frame
	void Update () {

		//Playerがgunmodeで右クリックを押している間fps視点それ以外は通常カメラ

		if (Input.GetMouseButton (1) && GameObject.FindWithTag ("Player").GetComponent<char_move> ().Gun_Mode == 1) {

			transform.position = Head_Gizmo.transform.position;
			transform.forward = Head_Gizmo.transform.forward;


		} else if (Input.GetMouseButtonUp (1) && GameObject.FindWithTag ("Player").GetComponent<char_move> ().Gun_Mode == 1) {
			//fps終了後カメラを戻す
			Move_Back_camera_point = transform.position - PLAYER.transform.position;
			
			Move_Back_camera = new Vector3(PLAYER.transform.position.x-Move_Back_camera_point.x,0f,PLAYER.transform.position.z - Move_Back_camera_point.z);
			transform.position = Move_Back_camera;

		}else{

		rotatedegree = 0f;

		//カメラ追従
		transform.RotateAround (PLAYER.transform.position, Vector3.up, rotatedegree);//キャラクターの周りを旋回
		//キャラクターを中心にカメラの位置を決定
		newposition = (transform.position - PLAYER.transform.position).normalized * radius + PLAYER.transform.position;
		//位置更新
		transform.position = Vector3.MoveTowards (transform.position, newposition,3.0f);
		//高さ更新
		targetheight = PLAYER.transform.position.y;
		transform.position =new Vector3(transform.position.x, targetheight+height, transform.position.z);
		//キャラクターへ向かす
		transform.LookAt (PLAYER.transform.position);
		}

		//カメラ位置反転

		if (Input.GetKeyDown ("tab")) 
		{

			//transform.forward = PLAYER.transform.forward;
			//位置更新

			Move_Back_camera_point = transform.position - PLAYER.transform.position;

			Move_Back_camera = new Vector3(PLAYER.transform.position.x-Move_Back_camera_point.x,0f,PLAYER.transform.position.z - Move_Back_camera_point.z);
			transform.position = Move_Back_camera;
		}

	}
}
