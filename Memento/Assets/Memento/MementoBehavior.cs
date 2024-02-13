using UnityEngine;

namespace Memento
{
	public abstract class MementoBehavior : MonoBehaviour, IMemento
	{
		public abstract ISnapshot GetSnapshot();
		public abstract void Restore(ISnapshot memento);
		public abstract void OnEnterInState(CaretakerState state);
	}
}
