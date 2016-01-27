using UnityEngine;
using System.Collections;

public class CharacterMain : MonoBehaviour {

	public Rigidbody rb;
	public float jump;
	Camera _2DCamera;
	Camera _3DCamera;
	public bool camera2D = true;
	public bool onGround = false;
	Coll coll;

	// Use this for initialization
	void Start () {
		coll = transform.findchild ("On").GetComponent<Coll> ().nowOn;

		rb = GetComponent<Rigidbody> ();

		_2DCamera = GameObject.Find("2D Camera").GetComponent<Camera>();
		_3DCamera = GameObject.Find ("3D Camera").GetComponent<Camera> ();
		_3DCamera.enabled = false;
	}

	void OnCollisionEnter(Collision col){
		onGround = true;
	}

	void OnCollisionExit(Collision col){
		onGround = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			//カメラ切り替え
			if(_2DCamera.enabled){
				_2DCamera.enabled = false;
				_3DCamera.enabled = true;

				camera2D = false;
			}else{
				_2DCamera.enabled = true;
				_3DCamera.enabled = false;

				camera2D = true;
			}
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			if (camera2D == true){
				transform.position += new Vector3 (0.1f, 0, 0);
			} else {
				transform.position += new Vector3 (0, 0, -0.1f);
			}
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			if (camera2D == true){
				transform.position += new Vector3 (-0.1f, 0, 0);
			} else {
				transform.position += new Vector3 (0, 0, 0.1f);
			}
		}

		if (Input.GetKeyDown(KeyCode.Space) && onGround == true) {
			//ジャンプ
			rb.AddForce(transform.up * jump);
		}

		if (Input.GetKey(KeyCode.UpArrow) && camera2D == false){
			transform.position += new Vector3 (0.1f, 0, 0);
		}

		if (Input.GetKey(KeyCode.DownArrow) && camera2D == false){
			transform.position += new Vector3 (-0.1f, 0, 0);
		}
	}
}
