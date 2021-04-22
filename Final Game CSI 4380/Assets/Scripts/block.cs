using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collisionInfo) {
		FindObjectOfType<AudioManager>().Play("hitBlock");
		Destroy(gameObject);

	}
}
