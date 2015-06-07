using UnityEngine;
using System.Collections;

public class SmartFollower : MonoBehaviour {

	/*
		public float interpVelocity;
		public float minDistance;
		public float followDistance;
		public GameObject target;
		public Vector3 offset;
		Vector3 targetPos;
		*/
		public GameObject target;
		float final_offset = 28;
		float offset = 28;

		public void OnBegin(){
			final_offset = 18;
		}

		// Use this for initialization
		void Start () {
			//targetPos = transform.position;

			//Vector3 targetDirection = target.transform.rotation.eulerAngles;
		}
		
		// Update is called once per frame
		void FixedUpdate () {
			if(offset > final_offset) {
				offset -= Time.deltaTime * 1.6f;
				offset = Mathf.Max(offset, final_offset);
			}


			if (target)
			{

				Vector3 targetPosition = target.transform.position;
				Vector3 targetDirection = target.transform.up;

				//print (target.transform.up);

				Vector3 nextPosition = targetPosition - targetDirection.normalized * offset;

				//transform.position = nextPosition; //Vector3.Lerp(transform.position, nextPosition, 0.1f);
				//transform.rotation = target.transform.rotation; //Quaternion.Lerp(transform.rotation, target.transform.rotation, 0.1f);


				transform.position = Vector3.Lerp(transform.position, nextPosition, 0.25f);
				transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, 0.25f);

				/*
				Vector3 posNoZ = transform.position;
				posNoZ.z = target.transform.position.z;
				
				Vector3 targetDirection = (target.transform.position - posNoZ);
				
				interpVelocity = targetDirection.magnitude * 5f;
				
				targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 
				
				transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);
				*/
			}
		}

}
