// RPG Top Down / Isometric Camera Controller

// Tested on Unity 2018.3.0f1

// While using the setup suggested by 
// https://answers.unity.com/questions/12027/how-to-do-a-camera-that-is-top-downisometric.html
// I found no off the shelf camera controllers that worked as I would have liked
// This is for basic mouse control (Rotate, Pan, Zoom)

// Improvement suggestions left as exercise for the reader:
//
// * Replacing magic numbers with serialised floats
//   that could be modified in the editor
// * Include keyboard controls
// * Add tilting

// Attach this script to any GameeObject
// Make sure the Camera is tagged as "Main Camera" in the inspector

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCameraController : MonoBehaviour
{
	public Transform target;
	public float smoothing = 5f;
	Vector3 offset;

	// Use this for initialization
	void Start()
	{
		offset = transform.position - target.position;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
