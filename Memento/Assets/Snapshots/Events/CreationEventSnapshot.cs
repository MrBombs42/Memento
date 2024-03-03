using System.Collections.Generic;

namespace Assets.Snapshots.Events
{
	public class CreationEventSnapshot : IEvent
	{
		public SnapshotEventType EventType => SnapshotEventType.Created;
		public List<CreationData> CreateList = new List<CreationData>();

	}

	public class CreationData
	{
		public SerializablePosition Position;
		public SerializableQuaternion Rotation;
		public string ModelName;
	}
}
