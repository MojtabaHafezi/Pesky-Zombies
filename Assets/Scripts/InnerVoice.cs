using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class InnerVoice : MonoBehaviour
{

	private AudioSource audioSource;

	public AudioClip whatHappend;
	public AudioClip goodLandingArea;

	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent <AudioSource> ();
		audioSource.clip = whatHappend;
		Invoke ("PlayAudio", 1f);
	}

	void PlayAudio ()
	{
		audioSource.Play ();
	}

	void  OnFindClearArea ()
	{
		audioSource.clip = goodLandingArea;
		audioSource.Play ();
		Invoke ("CallHelicopter", audioSource.clip.length + 1f);
	}

	void CallHelicopter ()
	{
		SendMessageUpwards ("OnInitalHelicopterCall");
	}
}
