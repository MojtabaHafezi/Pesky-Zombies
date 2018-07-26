using UnityEngine;
using System.Collections;

public class FlareMoveExplode : MonoBehaviour
{
	public GameObject explosion;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveUpwards ();
		if (this.transform.position.y > 75) {
			if (explosion != null) {
				Instantiate (explosion, this.transform.position, Quaternion.identity);
			}
			Destroy (gameObject);
		}
	}

	void MoveUpwards ()
	{
		Vector3 position = this.transform.position;
		position.y += 0.15f;
		this.transform.position = position;
	}
}
