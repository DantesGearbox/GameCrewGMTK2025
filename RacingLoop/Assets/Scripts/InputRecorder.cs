using UnityEngine;
using System.Collections.Generic;

public class InputRecorder : MonoBehaviour
{
	public List<InputFrame> recordedInputs = new List<InputFrame>();
	private float recordTimer = 0f;
	private ArcadeCarRaycastController car;

	void Start()
	{
		car = GetComponent<ArcadeCarRaycastController>();
	}

	void Update()
	{
		car.SetLiveInput();

		InputFrame frame = new InputFrame
		{
			time = recordTimer,
			throttle = Input.GetAxis("Vertical"),
			steering = Input.GetAxis("Horizontal")
		};

		recordedInputs.Add(frame);
		recordTimer += Time.deltaTime;
	}

	public List<InputFrame> GetRecordedData() => recordedInputs;
}
