using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArcadeCarController : MonoBehaviour
{
	public float acceleration = 500f;
	public float steering = 200f;
	public float maxSpeed = 50f;
	public float dragOnBrake = 5f;

	private Rigidbody rb;
	private float moveInput;
	private float steerInput;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.centerOfMass = new Vector3(0, -0.5f, 0); // Helps with stability
	}

	void FixedUpdate()
	{
		// Inputs
		moveInput = Input.GetAxis("Vertical");
		steerInput = Input.GetAxis("Horizontal");

		// Speed control
		if (rb.linearVelocity.magnitude < maxSpeed)
		{
			rb.AddForce(transform.forward * moveInput * acceleration * Time.fixedDeltaTime);
		}

		// Steering
		if (rb.linearVelocity.magnitude > 1f)
		{
			float steer = steerInput * steering * Time.fixedDeltaTime;
			Quaternion turn = Quaternion.Euler(0f, steer, 0f);
			rb.MoveRotation(rb.rotation * turn);
		}

		// Braking drag
		if (Input.GetKey(KeyCode.Space))
		{
			rb.linearDamping = dragOnBrake;
		}
		else
		{
			rb.linearDamping = 0.1f;
		}
	}
}
