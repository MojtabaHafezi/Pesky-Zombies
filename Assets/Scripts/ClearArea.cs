using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour
{
	[SerializeField]
	private float timeSinceLastTrigger;
	private bool foundClearArea;

	// Use this for initialization
	void Start ()
	{
		timeSinceLastTrigger = 0f;
		foundClearArea = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeSinceLastTrigger += Time.deltaTime;
		if (timeSinceLastTrigger > 8f && Input.GetButtonDown ("Helicopter") && !foundClearArea) {
			foundClearArea = true;
			SendMessageUpwards ("OnFindClearArea");
		}
	}

	void OnTriggerStay (Collider collider)
	{
		if (collider.tag != "Zombie" && collider.tag != "Player")
			timeSinceLastTrigger = 0;
	}
}
