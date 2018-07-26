using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
	public static MusicManager instance;
	public AudioMixer master;
	private bool mute;

	// Use this for initialization
	void Awake ()
	{
		if (instance != null) {
			Destroy (this);
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this);
		mute = false;
	}
	//MUTE THE GAME
	public void MuteGame ()
	{
		//		audioMaster = GameObject.FindObjectOfType <AudioListener> ();
		//		audioMaster.enabled = !audioMaster.enabled;

		mute = !mute;
		if (mute) {
			master.SetFloat ("master", -80);
		} else {
			master.SetFloat ("master", 0);
		}


	}
	

}
