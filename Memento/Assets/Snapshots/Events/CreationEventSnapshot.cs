namespace Assets.Snapshots.Events
{
	public class CreationEventSnapshot : IEvent
	{
		public SnapshotEventType EventType => SnapshotEventType.Created;

		public SerializablePosition Position;
		public SerializableQuaternion Rotation;
		public string ModelName;
	}
}
