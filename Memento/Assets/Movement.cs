using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] private float _speed = 10;
	private Rigidbody _rigidbody;

	private Vector3 _movementDirection;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.D))
		{
			_movementDirection = transform.right;
		}
		else

		if (Input.GetKey(KeyCode.A))
		{
			_movementDirection = -transform.right;
		}
		else

		if (Input.GetKey(KeyCode.W))
		{
			_movementDirection = transform.forward;
		}
		else

		if (Input.GetKey(KeyCode.S))
		{
			_movementDirection = -transform.forward;
		}
		else

		if (Input.GetKey(KeyCode.Space))
		{
			_movementDirection = transform.up;
		}
		else
		{
			_movementDirection = Vector3.zero;
		}

	}

	private void FixedUpdate()
	{
		var force = _speed * Time.fixedDeltaTime;
		_rigidbody.AddForce(_movementDirection * force, ForceMode.Impulse);
	}
}
