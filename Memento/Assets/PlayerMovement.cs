using Assets;
using Memento;
using UnityEngine;

public class PlayerMovement : MementoBehavior
{
	public float moveSpeed = 5f; // Movement speed
	public float jumpForce = 10f; // Jump force
	public float groundCheckDistance = 0.2f; // Distance to check for ground
	public LayerMask groundMask; // LayerMask for the ground

	private Rigidbody rb;
	private bool isGrounded;
	private Vector3 moveDirection;
	private bool _blockedInput;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (_blockedInput)
		{
			return;
		}

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
		if (_blockedInput)
		{
			return;
		}

		// Check if the player is grounded
		isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);

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

	public override ISnapshot GetSnapshot()
	{
		return new MovementSnapshot
		{
			Position = transform.position,
			Rotation = transform.rotation
		};
	}

	public override void Restore(ISnapshot snapshot)
	{
		var memento = (MovementSnapshot)snapshot;
		transform.position = memento.Position;
		transform.rotation = memento.Rotation;
	}

	public override void OnEnterInState(CaretakerState state)
	{
		switch (state)
		{
			case CaretakerState.Rewind:
			case CaretakerState.Replay:
				_blockedInput = true;
				break;
			case CaretakerState.Record:
			default:
				_blockedInput = false;
				break;
		}
	}
}
