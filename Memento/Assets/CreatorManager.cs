using Assets.Memento;
using Assets.Snapshots.Events;
using Memento;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
	public class CreatorManager : MementoBehavior
	{
		[SerializeField] private List<GameObject> _poll;

		private CreationEventSnapshot _eventSnapshot;
		private CaretakerState _currentState;

		private List<GameObject> _createdObjects = new List<GameObject>();

		private void Start()
		{
			_eventSnapshot = new CreationEventSnapshot();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.C))
			{
				var name = $"Instance{_createdObjects.Count}";


				var instance = Instantiate(_poll[0]);
				instance.name = name;
				_eventSnapshot.CreateList.Add(new CreationData()
				{
					ModelName = name,
					Position = new SerializablePosition(instance.transform.position.x, instance.transform.position.y, instance.transform.position.z)
				});

				_createdObjects.Add(instance);
			}
		}

		public override ISnapshot GetSnapshot()
		{
			if (_eventSnapshot.CreateList.Count == 0)
			{
				return new EmptySnapshot();
			}

			var copy = new CreationEventSnapshot();
			copy.CreateList = _eventSnapshot.CreateList.ToList();
			_eventSnapshot.CreateList.Clear();
			return copy;
		}

		public override void Restore(ISnapshot memento)
		{
			var createEvent = (CreationEventSnapshot)memento;
			var data = createEvent.CreateList[0];
			var name = data.ModelName;
			var instance = _createdObjects.First(i => i.name == name);
			instance.transform.position = data.Position;
			instance.transform.rotation = data.Rotation;
			if (_currentState == CaretakerState.Rewind)
			{
				instance.SetActive(false);
			}
			else
			{

				instance.SetActive(true);
			}
		}

		public override void Prepare(ISnapshot memento)
		{
		}

		public override void OnEnterInState(CaretakerState state)
		{
			_currentState = state;
		}
	}
}
