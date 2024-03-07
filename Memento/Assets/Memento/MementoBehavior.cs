using UnityEngine;

namespace Memento
{
	public abstract class MementoBehavior : MonoBehaviour, IMemento
	{
		public long Id { get; private set; }

		public abstract ISnapshot GetSnapshot();
		public abstract void Restore(ISnapshot memento);
		public abstract void Prepare(ISnapshot memento);

		public virtual void OnEnterInState(CaretakerState state) { }

		protected void Awake()
		{
			Id = MementoId.GetId();
		}
	}
}
