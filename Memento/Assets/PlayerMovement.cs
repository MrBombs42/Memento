using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f; // Movement speed
	public float jumpForce = 10f; // Jump force
	public float groundCheckDistance = 0.2f; // Distance to check for ground
	public LayerMask groundMask; // LayerMask for the ground

	private Rigidbody rb;
	private bool isGrounded;
	private Vector3 moveDirection;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		// Movement input
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

		// Jump input
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			Jump();
		}

		// Rotate the player towards the movement direction
		if (moveDirection != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(moveDirection);
		}
	}

	void FixedUpdate()
	{
		// Check if the player is grounded
		isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);
		Debug.DrawRay(transform.position, Vector3.down, Color.red);

		// Apply movement force
		Vector3 movement = moveDirection * moveSpeed * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + movement);
	}

	void Jump()
	{
		// Apply jump force if grounded
		if (isGrounded)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}
}
