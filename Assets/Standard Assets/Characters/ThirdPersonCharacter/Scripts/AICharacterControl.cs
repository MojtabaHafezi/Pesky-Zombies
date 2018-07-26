using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent (typeof(UnityEngine.AI.NavMeshAgent))]
	[RequireComponent (typeof(ThirdPersonCharacter))]
	public class AICharacterControl : MonoBehaviour
	{
		public UnityEngine.AI.NavMeshAgent agent { get; private set; }
		// the navmesh agent required for the path finding
		public ThirdPersonCharacter character { get; private set; }
		// the character we are controlling
		public Transform target;
		// target to aim for

		private bool reachable;
		private UnityEngine.AI.NavMeshPath path;
		private float elapsed = 0.0f;

		private void Start ()
		{
			// get the components on the object we need ( should not be null due to require component so no need to check )
			agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent> ();
			character = GetComponent<ThirdPersonCharacter> ();

			agent.updateRotation = false;
			agent.updatePosition = true;

			path = new UnityEngine.AI.NavMeshPath ();
			elapsed = 0.0f;
			reachable = TargetReachable ();

		}


		private void Update ()
		{
			elapsed += Time.deltaTime;

			if (target != null)
				agent.SetDestination (target.position);

		
			if (reachable && agent.hasPath && (agent.remainingDistance > agent.stoppingDistance)) {
				character.Move (agent.desiredVelocity, false, false);

			} else if (!reachable) {
				MoveAwayFromTarget ();

			} else {
				character.Move (Vector3.zero, false, false);
			
			}

			if (elapsed > 1f) {
				reachable = TargetReachable ();
				elapsed = 0;
			}

		}


		public void SetTarget (Transform target)
		{
			this.target = target;
		}

		private void MoveAwayFromTarget ()
		{
			Vector3 direction = target.transform.position;
			character.Move (new Vector3 (-direction.x, 0, -direction.z), false, false);
		}

		private bool TargetReachable ()
		{
			return UnityEngine.AI.NavMesh.CalculatePath (transform.position, target.position, 1, path);
		}

	}
}
