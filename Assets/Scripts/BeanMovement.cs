using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class BeanMovement : MonoBehaviour
{

	Vector3 velocity;
	static public bool isGrounded;

	public float Gravity = 19.81f;
	public float JumpHeight = 2f;

	public static BeanInput beanInput;
	InputAction movement;

	public Transform groundCheck;
	public float groundDistance = 0.44f;
	public LayerMask groundMask;

	static public bool aBarrierAhead;

	CheckpointManager gm;
	CharacterController controller;



	private void Awake()
	{
		isGrounded = false;
		aBarrierAhead = false;
		beanInput = new BeanInput();
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "MainMenu")
			StartCoroutine(Respawn());
	}
	void Update()
	{

		controller = GetComponent<CharacterController>();
		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -5f;
		}
		float x = movement.ReadValue<Vector2>().x;
		float z = 1;
		if (aBarrierAhead)
		{
			z = 0;
		}

		Vector3 move = transform.right * x + transform.forward * z;

		controller.Move(move * 3.6f * Time.deltaTime);

		//Jump Script Location


		velocity.y += Gravity * Time.deltaTime * -1;

		controller.Move(velocity * Time.deltaTime);

	}

	void OnEnable()
	{
		movement = beanInput.InGameWalk.Move;
		movement.Enable();

		beanInput.InGameWalk.Jump.started += Jumping;
		beanInput.InGameWalk.Jump.Enable();
	}

	private void Jumping(InputAction.CallbackContext obj)
	{
		if (isGrounded)
		{
			velocity.y = Mathf.Sqrt(JumpHeight * 2f * Gravity);
		}
	}



	private void OnDisable()
	{
		if (movement != null)
			movement.Disable();

	}



	IEnumerator Respawn()
	{
		gameObject.GetComponent<BeanMovement>().enabled = false;
		gameObject.GetComponent<CharacterController>().enabled = false;
		yield return new WaitForSeconds(0.08f);
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "MainMenu" && LevelDescription.canTrain)
			gm = GameObject.FindGameObjectWithTag("GM").GetComponent<CheckpointManager>();
		if (LevelDescription.canTrain)
			transform.position = gm.LastCheckpoint;
		yield return new WaitForSeconds(0.08f);
		gameObject.GetComponent<CharacterController>().enabled = true;
		gameObject.GetComponent<BeanMovement>().enabled = true;
	}
}
