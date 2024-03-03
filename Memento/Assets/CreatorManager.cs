using System;
using UnityEngine;

namespace Assets
{
	public class CreatorManager : MonoBehaviour
	{

		// aqui vai criar o objeto, caretaker vai salvar em q frame isso ocorreu, e no nome do modelo para poder recriar o objeto, posição e rotação

		public event Action<long, string> OnInstanceCreated;

		private void Update()
		{

			if (Input.GetKeyDown(KeyCode.C))
			{
				OnInstanceCreated?.Invoke(1, "objecto");
			}
		}
	}
}
