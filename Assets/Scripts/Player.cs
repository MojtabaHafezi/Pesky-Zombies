using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private Transform[] spawnPoints;

	private bool lastRespawnToggle = false;


	public Transform playerSpawnPoints;
	public bool respawn = false;
	public GameObject landingAreaPrefab;

	// Use this for initialization
	void Start ()
	{
		spawnPoints = playerSpawnPoints.GetComponentsInChildren <Transform> ();


//		//Get the right audioSOurce as there are more than only 1 AudioSOurces on the player
//		AudioSource[] audioSources = GetComponents <AudioSource> ();
//		foreach (AudioSource audioSource in audioSources) {
//			if (audioSource.priority == 1) {
//				innerVoice = audioSource;
//				break;
//			}
//		}
//		if (innerVoice != null) {
//			innerVoice.clip = whatHappend;
//			innerVoice.Play ();
//		}

		Respawn ();
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (lastRespawnToggle != respawn) {
//			Respawn ();
//			respawn = false;
//		} else {
//			lastRespawnToggle = respawn;
//		}
	}

	private void Respawn ()
	{
		int i = Random.Range (1, spawnPoints.Length);
		transform.position = spawnPoints [i].transform.position;
	}

	private void OnFindClearArea ()
	{
		Invoke ("DropFlare", 13f);
	}

	void DropFlare ()
	{
		Instantiate (landingAreaPrefab, this.transform.position, transform.rotation);
		Helicopter heli = FindObjectOfType <Helicopter> ();
		heli.SetPlayerPosition (this.transform.position);

	}

	void OnCollisionEnter (Collision collider)
	{
		if (collider.transform.tag == "Zombie") {
			GameManager.instance.GameOver ();
		}
	}
}
