namespace Memento
{
	public class Frame : IFrame
	{
		public long TimeStamp { get; private set; }

		public ISnapshot Snapshot { get; private set; }

		public Frame(long timeStamp, ISnapshot snapshot)
		{
			TimeStamp = timeStamp;
			Snapshot = snapshot;
		}
	}
}
