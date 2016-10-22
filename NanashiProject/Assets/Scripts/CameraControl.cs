using System;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public Transform target;

	public float borderX = 1.6f;

	public float borderY = 0.5f;

	public float smoothTime = 0.2f;

	public bool useSmoothing = true;

	private Transform playerTransform;

	private Vector2 velocity;

	private void Start()
	{
		playerTransform = transform;
	}

	private void Update()
	{
		Vector2 zero = Vector2.zero;
		if (useSmoothing)
		{
			zero.x = Mathf.SmoothDamp(playerTransform.position.x, target.position.x + borderX, ref velocity.x, smoothTime);
			zero.y = Mathf.SmoothDamp(playerTransform.position.y, target.position.y + borderY, ref velocity.y, smoothTime);
		}
		Vector3 b = new Vector3(zero.x, zero.y, transform.position.z);
		transform.position = Vector3.Slerp(transform.position, b, Time.time);
	}
}

