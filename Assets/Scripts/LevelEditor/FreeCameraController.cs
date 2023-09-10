using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
	/// <summary>
	/// Normal speed of camera movement.
	/// </summary>
	public float movementSpeed = 10f;

	/// <summary>
	/// Speed of camera movement when shift is held down,
	/// </summary>
	public float fastMovementSpeed = 100f;

	/// <summary>
	/// Sensitivity for free look.
	/// </summary>
	public float freeLookSensitivity = 0.1f;

	/// <summary>
	/// Amount to zoom the camera when using the mouse wheel.
	/// </summary>
	public float zoomSensitivity = 10f;

	/// <summary>
	/// Amount to zoom the camera when using the mouse wheel (fast mode).
	/// </summary>
	public float fastZoomSensitivity = 50f;

	/// <summary>
	/// Set to true when free looking (on right mouse button).
	/// </summary>
	private bool looking = false;

#pragma warning disable CS0436 // Type conflicts with imported type
	public static FreeCam MoveInput;
#pragma warning restore CS0436 // Type conflicts with imported type
	InputAction Walk;
	InputAction Looking;

	//InputAction movement;
	private void Awake()
	{
#pragma warning disable CS0436 // Type conflicts with imported type
		MoveInput = new FreeCam();
#pragma warning restore CS0436 // Type conflicts with imported type
	}
	void Update()
	{
		var fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		var movementSpeed = fastMode ? this.fastMovementSpeed : this.movementSpeed;
		float x = Walk.ReadValue<Vector2>().x;
		float y = Walk.ReadValue<Vector2>().y;

		if (x == -1 || x < 0)
		{
			transform.position = transform.position + (transform.right * x * movementSpeed * Time.deltaTime);
		}

		if (x == 1 || x > 0)
		{
			transform.position = transform.position + (transform.right * x * movementSpeed * Time.deltaTime);
		}

		if (y == 1 || x > 0)
		{
			transform.position = transform.position + (transform.forward * y * movementSpeed * Time.deltaTime);
		}

		if (y == -1 || x < 0)
		{
			transform.position = transform.position + (transform.forward * y * movementSpeed * Time.deltaTime);
		}
		#region somecode
		//if (Input.GetKey(KeyCode.Q))
		//{
		//	transform.position = transform.position + (transform.up * movementSpeed * Time.deltaTime);
		//}

		//if (Input.GetKey(KeyCode.E))
		//{
		//	transform.position = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
		//}

		//if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.PageUp))
		//{
		//	transform.position = transform.position + (Vector3.up * movementSpeed * Time.deltaTime);
		//}

		//if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.PageDown))
		//{
		//	transform.position = transform.position + (-Vector3.up * movementSpeed * Time.deltaTime);
		//}
		#endregion

		if (looking)
		{
			float newRotationX = transform.localEulerAngles.y + Looking.ReadValue<Vector2>().x * freeLookSensitivity;
			float newRotationY = transform.localEulerAngles.x - Looking.ReadValue<Vector2>().y * freeLookSensitivity;
			transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
		}
		if (!MouseChecker.IsPointerOverUIElement())
		{
			float axis = Input.GetAxis("Mouse ScrollWheel");
			if (axis != 0)
			{
				var zoomSensitivity = fastMode ? this.fastZoomSensitivity : this.zoomSensitivity;
				transform.position = transform.position + transform.forward * axis * zoomSensitivity;
			}


			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				StartLooking();
			}
		}
		if (Input.GetKeyUp(KeyCode.Mouse1))
		{
			StopLooking();
		}
		
	}

	void OnDisable()
	{
		Looking.Disable();
		Walk.Disable();
		StopLooking();
	}
	private void OnEnable()
	{
		Walk = MoveInput.Roaming.Walk;
		Looking = MoveInput.Roaming.Looking;

		Walk.Enable();
		Looking.Enable();
	}

	public void StartLooking()
	{
		looking = true;
	}

	public void StopLooking()
	{
		looking = false;
	}
}
