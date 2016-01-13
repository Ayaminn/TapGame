using UnityEngine;
using System.Collections;

public class CharacterMain : MonoBehaviour {

	public Rigidbody rb;
	public float jump;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			rb.AddForce(transform.forward * jump);
		}
	}
}
