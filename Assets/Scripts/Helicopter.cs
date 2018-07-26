using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour
{
	

	private Rigidbody rigidBody;
	private float elapsed;
	private bool startCountdown;
	private Vector3 playerPosition;


	// Use this for initialization
	void Start ()
	{
		
		rigidBody = GetComponent <Rigidbody> ();
		elapsed = 0;
		startCountdown = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (startCountdown) {
			elapsed += Time.deltaTime;
			if (elapsed > 300) {
				Vector3 newPosition = playerPosition;
				newPosition.y = 80;
				this.transform.position = newPosition;

			}
		}
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player") {
			Invoke ("TellGameManagerWin", 3f);
		
		}
	}

	void TellGameManagerWin ()
	{
		GameManager.instance.Win ();
	}

	void OnDispatchHelicopter ()
	{
		//rigidBody.velocity = new Vector3 (0, 0, 50f);
		startCountdown = true;
		GameManager.instance.ActivateTimeText ();
	}

	public void SetPlayerPosition (Vector3 position)
	{
		playerPosition = position;
	}

	public float GetTime ()
	{
		return elapsed;
	}
}
