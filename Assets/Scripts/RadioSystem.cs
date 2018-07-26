using UnityEngine;
using System.Collections;

public class RadioSystem : MonoBehaviour
{
	private AudioSource audioSource;

	public AudioClip initialHelicopterCall;
	public AudioClip initialCallReply;


	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent <AudioSource> ();
		audioSource.loop = false;
	}


	void OnInitalHelicopterCall ()
	{
		audioSource.clip = initialHelicopterCall;
		audioSource.Play ();
		Invoke ("InitialReply", initialHelicopterCall.length + 1f);

	}

	void InitialReply ()
	{
		audioSource.clip = initialCallReply;
		audioSource.Play ();
		BroadcastMessage ("OnDispatchHelicopter");
	}
}
