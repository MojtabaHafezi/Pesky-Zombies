using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	public GameObject bullet;
	public float speed = 1500f;
	public float shootRate = 0.1f;
	private AudioSource shootSound;
	float timer = 0;
	// Use this for initialization
	void Start ()
	{
		shootSound = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;

		//if left mouseclick + shootRate > elapsed time
		if (timer > shootRate && Input.GetButton ("Fire1")) {
			GameObject newBullet = Instantiate (bullet, transform.position, bullet.transform.rotation) as GameObject;
			newBullet.GetComponent <Rigidbody> ().AddForce (Camera.main.transform.forward * speed);
			newBullet.transform.rotation = Quaternion.Euler (new Vector3 (90, 0, 0));
			if (shootSound != shootSound.isPlaying)
				shootSound.Play ();
			timer = 0;
		} 
	}
}
