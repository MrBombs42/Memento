namespace Memento
{
	public interface IFrame
	{
		long TimeStamp { get; }
		ISnapshot Snapshot { get; } // dicionario de Snapshot, key id do objeto
	}
}
