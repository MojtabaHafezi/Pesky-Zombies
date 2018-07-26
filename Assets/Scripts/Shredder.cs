using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour
{
	//Destroy bullets on hit or after some time
	private float timer;
	private float timeExistence;
	public GameObject hitflare;

	void Start ()
	{
		timer = 0;
		timeExistence = 8f;
	}

	void Update ()
	{
		timer += Time.deltaTime;

		if (timer > timeExistence) {
			Destroy (this.gameObject);
		}

	}

	void OnCollisionEnter ()
	{
		
		Invoke ("Destruction", 0.05f);
		if (hitflare != null) {
			Instantiate (hitflare, this.transform.position, Quaternion.identity);
		}
		
	}

	void Destruction ()
	{
		Destroy (this.gameObject);
	}
}
