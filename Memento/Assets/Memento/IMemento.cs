namespace Memento
{
	public interface IMemento
	{
		long Id { get; }
		ISnapshot GetSnapshot();
		void Restore(ISnapshot memento);
		void Prepare(ISnapshot memento);

		void OnEnterInState(CaretakerState state);
	}
}
