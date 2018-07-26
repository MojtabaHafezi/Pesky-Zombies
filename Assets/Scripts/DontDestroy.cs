using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour
{
	public static DontDestroy instance;
	// Use this for initialization
	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
		}


		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
