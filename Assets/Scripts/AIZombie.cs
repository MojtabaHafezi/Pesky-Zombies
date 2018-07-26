using UnityEngine;
using System.Collections;

[RequireComponent (typeof(UnityEngine.AI.NavMeshAgent))]
public class AIZombie : MonoBehaviour
{

	public UnityEngine.AI.NavMeshAgent agent { get; private set; }
	// the navmesh agent required for the path finding
	private Transform target;
	// target to aim for

	//for making the collider disappear after death
	private BoxCollider boxCollider;
	private Rigidbody rigidBody;

	//Some attributes for checking if there exists a path to the target
	private bool reachable;
	private UnityEngine.AI.NavMeshPath path;
	private float elapsed = 0.0f;
	private float soundElapsed;

	//health
	private int health;

	//animator
	private Animator animator;

	//Audio
	private AudioSource audioSource;
	public AudioClip attackSound, roaringSound;

	// Use this for initialization
	void Start ()
	{
		// get the components on the object we need ( should not be null due to require component so no need to check )
		agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent> ();
		target = FindObjectOfType <Player> ().GetComponent <Transform> ();
		audioSource = GetComponent <AudioSource> ();
		agent.updateRotation = true;
		agent.updatePosition = true;
		animator = GetComponent <Animator> ();
		path = new UnityEngine.AI.NavMeshPath ();
		elapsed = 6.1f;
		soundElapsed = 0;
		reachable = TargetReachable ();
		audioSource.clip = roaringSound;

		boxCollider = GetComponent <BoxCollider> ();
		rigidBody = GetComponent <Rigidbody> ();
		RandomSpeedAndHealth ();
	}

	
	// Update is called once per frame
	void Update ()
	{
		elapsed += Time.deltaTime;

		if (target != null) {
			
		
			agent.SetDestination (target.position);


			if (reachable && agent.hasPath && (agent.remainingDistance > agent.stoppingDistance)) {
				agent.destination = target.transform.position;

			} else if (!reachable) {
				MoveAwayFromTarget ();

			} else {
				
			}
		}

		if (elapsed > 1f) {
			reachable = TargetReachable ();
			elapsed = 0;
		}
		soundElapsed += Time.deltaTime;

		if (soundElapsed > 6f) {

			RandomSound ();
		}

	}

	private void RandomSound ()
	{
		int rand = Random.Range (1, 100);
		if (rand > 95) {
			if (!audioSource.isPlaying) {
				audioSource.clip = roaringSound;
				audioSource.Play ();
				soundElapsed = 0;
			}
		} 

	}

	//give each individual zombie a different speed
	private void RandomSpeedAndHealth ()
	{
		float randomSpeed = Random.Range (1.5f, 2.5f);
		this.agent.speed = randomSpeed;

		int randomHealth = Random.Range (2, 7);
		this.health = randomHealth;

	}

	public void SetTarget (Transform target)
	{
		this.target = target;
	}

	private void MoveAwayFromTarget ()
	{
		Vector3 direction = target.transform.position;

		Vector3 targetDestination = new Vector3 (0, 0, 0);
		targetDestination.x = target.transform.position.x - 20;
		targetDestination.z = target.transform.position.z - 20;
		agent.destination = targetDestination;
	}

	private bool TargetReachable ()
	{
		return UnityEngine.AI.NavMesh.CalculatePath (transform.position, target.position, 1, path);
	}

	//When hit by bullet, reduce health; attack player
	void OnCollisionEnter (Collision collision)
	{
		
		if (collision.transform.tag == "Bullet") {
			health--;
			if (health < 1) {
				Death ();
			}
		}

		if (collision.transform.tag == "Player") {
			animator.SetBool ("isAttacking", true);
			if (audioSource.isPlaying == false) {
				audioSource.clip = attackSound;
				audioSource.Play ();
			}
	
		}
	}

	//stop player attacking
	void OnCollisionExit (Collision collision)
	{
		if (collision.transform.tag == "Player") {
			animator.SetBool ("isAttacking", false);
		}
	
	}



	private void Death ()
	{
		
		animator.SetTrigger ("death");
		audioSource.Stop ();
		//Deactivate the collider and make rigidbody kinematic so not to fall through ground
		boxCollider.enabled = false;
		rigidBody.isKinematic = true;
		agent.updatePosition = false;
		agent.updateRotation = false;
		Invoke ("Destruction", 7.2f);

	}

	private void Destruction ()
	{
		Destroy (gameObject);
	}

	//	public void SetHealth (int damage)
	//	{
	//		this.health -= damage;
	//		if (health < 1) {
	//			Death ();
	//		}
	//
	//	}
}
