namespace Memento
{
	public interface IMemento
	{
		ISnapshot GetSnapshot();
		void Restore(ISnapshot memento);

		void OnEnterInState(CaretakerState state);
	}
}
