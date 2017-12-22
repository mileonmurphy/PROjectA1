using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleshbag : MonoBehaviour {

	public CapsuleCollider fleshCollider;
	public Rigidbody fleshBody;
	public AudioSource fleshbagSource;
	public AudioClip shortR, longR;
	public float cooldown = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
		} else {
			Collider[] hitColliders;
			bool near = false;

			hitColliders = Physics.OverlapSphere (transform.position, 5f);

			foreach (Collider c in hitColliders) {
				if (c.gameObject.CompareTag ("Player")) {
					near = true;
					fleshbagSource.clip = shortR;
					fleshbagSource.Play ();
					cooldown = 3f;
				}
			}



			if (!near) {

				hitColliders = Physics.OverlapSphere (transform.position, 10f);

				foreach (Collider c in hitColliders) {
					if (c.gameObject.CompareTag ("Player")) {
						fleshbagSource.clip = longR;
						fleshbagSource.Play ();
						cooldown = 3f;
					}
				}
			}
			near = false;
		}

	}
}
