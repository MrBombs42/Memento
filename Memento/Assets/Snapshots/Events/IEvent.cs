using Memento;

namespace Assets.Snapshots
{

	public enum SnapshotEventType
	{
		Created,
		Destroyed,
	}


	public interface IEvent : ISnapshot
	{
		SnapshotEventType EventType { get; }
	}
}
