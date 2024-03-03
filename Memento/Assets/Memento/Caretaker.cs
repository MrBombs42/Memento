using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Memento
{
	public static class MementoId
	{
		private static long _idGenerator;

		public static long GetId()
		{
			return ++_idGenerator;
		}
	}

	public class Caretaker : MonoBehaviour
	{
		public List<MementoBehavior> MementableObjects;
		public CaretakerState CurrentState { get; private set; }
		public long FrameCount => _frameCount;

		private Dictionary<long, IFrame> _timeline;
		private long _frameCount;
		private long _currentFrame;

		private void Awake()
		{
			_timeline = new Dictionary<long, IFrame>();
			CurrentState = CaretakerState.None;
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
			switch (CurrentState)
			{
				case CaretakerState.Record:
					Record();
					break;
				case CaretakerState.Rewind:
					Rewind();
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
			var snapshots = new Dictionary<long, ISnapshot>();
			foreach (var instance in MementableObjects)
			{
				var snapshot = instance.GetSnapshot();

				snapshots.Add(instance.Id, snapshot);
			}

			var frame = new Frame(_frameCount, snapshots);
			_timeline.Add(_frameCount, frame);
		}

		private void ChangeState(CaretakerState state)
		{
			CurrentState = state;
			if (CurrentState == CaretakerState.Replay)
			{
				_currentFrame = 1;
			}

			if (CurrentState == CaretakerState.Rewind)
			{
				_currentFrame = _frameCount;
			}

			foreach (var instance in MementableObjects)
			{
				instance.OnEnterInState(CurrentState);
			}
		}

		private void Replay()
		{
			if (_currentFrame > _frameCount)
			{
				ChangeState(CaretakerState.None);
				return;
			}

			RestoreCurrentFrame(_currentFrame);

			_currentFrame++;
		}

		private void Rewind()
		{
			if (_currentFrame <= 0)
			{
				ChangeState(CaretakerState.None);
				return;
			}

			RestoreCurrentFrame(_currentFrame);

			_currentFrame--;
		}

		private void RestoreCurrentFrame(long frameTime)
		{
			_timeline.TryGetValue(frameTime, out var frame);

			foreach (var snapshot in frame.Snapshots)
			{
				var instance = MementableObjects.First(i => i.Id == snapshot.Key);// TODO change to dictionary
				instance.Restore(snapshot.Value);
			}
		}
	}
}
