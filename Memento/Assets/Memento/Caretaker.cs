using System.Collections.Generic;
using UnityEngine;

namespace Memento
{
	public class Caretaker : MonoBehaviour
	{
		// Current it will not work for more than one object
		public List<MementoBehavior> MementableObjects;

		private Dictionary<long, IFrame> _timeline;
		private CaretakerState _currentState;
		private long _frameCount;
		private long _currentFrame;

		private void Awake()
		{
			_timeline = new Dictionary<long, IFrame>();
			_currentState = CaretakerState.None;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				ChangeState(CaretakerState.Record);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				ChangeState(CaretakerState.Rewind);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				ChangeState(CaretakerState.Replay);
			}

			else if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				ChangeState(CaretakerState.None);
			}
		}

		private void FixedUpdate()
		{
			switch (_currentState)
			{
				case CaretakerState.Record:
					Record();
					break;
				case CaretakerState.Rewind:

					break;
				case CaretakerState.Replay:
					Replay();
					break;
				default:
					break;
			}
		}

		private void Record()
		{
			_frameCount++;
			foreach (var instance in MementableObjects)
			{
				var snapshot = instance.GetSnapshot();

				var frame = new Frame(_frameCount, snapshot);
				_timeline.Add(_frameCount, frame);
			}
		}

		private void ChangeState(CaretakerState state)
		{
			_currentState = state;
			if (_currentState == CaretakerState.Replay)
			{
				_currentFrame = 1;
			}

			if (_currentState == CaretakerState.Rewind)
			{
				_currentFrame = _frameCount;
			}

			foreach (var instance in MementableObjects)
			{
				instance.OnEnterInState(_currentState);
			}
		}

		private void Replay()
		{
			if (_currentFrame > _frameCount)
			{
				ChangeState(CaretakerState.None);
				return;
			}

			_timeline.TryGetValue(_currentFrame, out var frame);

			foreach (var instance in MementableObjects)
			{
				instance.Restore(frame.Snapshot);
			}

			_currentFrame++;
		}
	}
}
