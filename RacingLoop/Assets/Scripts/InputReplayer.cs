using UnityEngine;
using System.Collections.Generic;

public class InputReplayer : MonoBehaviour
{
	public List<InputFrame> inputData;
	private int currentFrame = 0;
	private float replayTimer = 0f;
	private ArcadeCarRaycastController carController;

	void Start()
	{
		carController = GetComponent<ArcadeCarRaycastController>();
	}

	void FixedUpdate()
	{
		if (inputData == null || inputData.Count == 0 || currentFrame >= inputData.Count)
			return;

		replayTimer += Time.fixedDeltaTime;

		// Replay frame when time matches
		while (currentFrame < inputData.Count && inputData[currentFrame].time <= replayTimer)
		{
			var frame = inputData[currentFrame];
			carController.SimulateInput(frame.throttle, frame.steering);
			currentFrame++;
		}
	}

	public void SetReplayData(List<InputFrame> data)
	{
		inputData = data;
		replayTimer = 0f;
		currentFrame = 0;
	}
}
