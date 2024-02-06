using UnityEngine;

namespace Assets
{

	public class FollowObject3D : MonoBehaviour
	{
		public Transform target; // The object to follow
		public Vector3 offset = new Vector3(0f, 2f, -10f); // Offset from the target
		public float smoothSpeed = 0.125f; // Smoothness of camera movement

		void LateUpdate()
		{
			if (target == null)
			{
				Debug.LogWarning("No target assigned to the 3D camera controller.");
				return;
			}

			// Calculate the desired position for the camera
			Vector3 desiredPosition = target.position + offset;

			// Smoothly move the camera towards the desired position
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

			// Update the camera's position
			transform.position = smoothedPosition;

			// Make the camera look at the target
			transform.LookAt(target);
		}
	}

}
