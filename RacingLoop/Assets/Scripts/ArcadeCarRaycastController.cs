using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArcadeCarRaycastController : MonoBehaviour
{
	public float acceleration = 800f;
	public float turnStrength = 100f;
	public float maxSpeed = 50f;
	public float rayLength = 1.2f;
	public float downForce = 5f;
	public LayerMask groundLayer;
	public Transform[] groundCheckPoints; // 4 points under car corners

	private Rigidbody rb;
	private float moveInput;
	private float steerInput;
	public bool isGrounded;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.centerOfMass = new Vector3(0, -0.5f, 0);
	}

	void FixedUpdate()
	{
		CheckGrounded();

		// Apply forward force
		if (rb.linearVelocity.magnitude < maxSpeed)
		{
			rb.AddForce(transform.forward * moveInput * acceleration * Time.fixedDeltaTime);
		}

		// Turning
		if (rb.linearVelocity.magnitude > 1f)
		{
			float turn = steerInput * turnStrength * Time.fixedDeltaTime;
			Quaternion turnRot = Quaternion.Euler(0f, turn, 0f);
			rb.MoveRotation(rb.rotation * turnRot);
		}

		// Extra downforce
		rb.AddForce(-transform.up * downForce);
	}

	public void SimulateInput(float throttle, float steering)
	{
		moveInput = throttle;
		steerInput = steering;
	}

	public void SetLiveInput()
	{
		SimulateInput(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
	}

	void CheckGrounded()
	{
		isGrounded = false;
		foreach (Transform point in groundCheckPoints)
		{
			Debug.DrawRay(point.position, -transform.up * rayLength, Color.red); // For debugging
			if (Physics.Raycast(point.position, -transform.up, rayLength, groundLayer))
			{
				isGrounded = true;
				break;
			}
		}
	}

}
