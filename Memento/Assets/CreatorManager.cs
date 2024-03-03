using Assets.Snapshots.Events;
using Memento;
using System.Linq;
using UnityEngine;

namespace Assets
{
	public class CreatorManager : MementoBehavior
	{

		// aqui vai criar o objeto, caretaker vai salvar em q frame isso ocorreu, e no nome do modelo para poder recriar o objeto, posição e rotação
		private CreationEventSnapshot _eventSnapshot;

		private void Update()
		{

			if (Input.GetKeyDown(KeyCode.C))
			{
				_eventSnapshot.CreateList.Add(new CreationData()
				{
					ModelName = "Bla",
					Position = new SerializablePosition(1, 2, 3)
				});
			}
		}

		public override ISnapshot GetSnapshot()
		{
			var copy = new CreationEventSnapshot();
			copy.CreateList = _eventSnapshot.CreateList.ToList();

			return copy;
		}

		public override void Restore(ISnapshot memento)
		{

		}
	}
}
