using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgSprites : MonoBehaviour {
	//IM TRYING
	public GameObject player;
	Vector2 findPos;
	Vector3 zPos;
	public float backPosZ;
	public float frontPosZ;


	void Start() {
		player = GameObject.FindGameObjectWithTag ("PlayerTag");
	}

	void Update() {
		//Debug.Log (findPos);
		findPos = (player.transform.position-gameObject.transform.position);

		if (findPos.y <= 0) {
			zPos = new Vector3 (transform.position.x, transform.position.y, backPosZ);
			gameObject.transform.position = zPos;
		} else if (findPos.y > 0) {
			zPos = new Vector3 (transform.position.x, transform.position.y, frontPosZ);
			gameObject.transform.position = zPos;
		}
	}
}
