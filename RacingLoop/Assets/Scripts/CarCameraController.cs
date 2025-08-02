using UnityEngine;

public class CarCameraController : MonoBehaviour
{
	[Header("Target Settings")]
	public Transform target;           // The car's transform
	public Vector3 offset = new Vector3(0f, 5f, -10f);
	public float followSpeed = 10f;
	public float rotationDamping = 10f;

	[Header("Camera Shake Settings")]
	public float shakeDuration = 0.3f;
	public float shakeMagnitude = 0.2f;

	private Vector3 velocity = Vector3.zero;
	private float shakeTimer = 0f;

	private Vector3 shakeOffset = Vector3.zero;

	void LateUpdate()
	{
		if (target == null) return;

		// Calculate desired position
		Vector3 desiredPosition = target.position + target.rotation * offset;

		// Smoothly move camera
		transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 1f / followSpeed);

		// Smoothly rotate camera to match target's rotation
		Quaternion desiredRotation = Quaternion.LookRotation(target.position + target.forward * 10f - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationDamping * Time.deltaTime);

		// Apply camera shake
		if (shakeTimer > 0)
		{
			shakeOffset = Random.insideUnitSphere * shakeMagnitude;
			shakeTimer -= Time.deltaTime;
		}
		else
		{
			shakeOffset = Vector3.zero;
		}

		transform.position += shakeOffset;
	}

	// Public method to trigger shake
	public void ShakeCamera(float duration = -1f, float magnitude = -1f)
	{
		shakeTimer = (duration > 0f) ? duration : shakeDuration;
		shakeMagnitude = (magnitude > 0f) ? magnitude : shakeMagnitude;
	}
}
