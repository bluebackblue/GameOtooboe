

/** Execute
*/
namespace Execute
{
	/** PlayerExecute
	*/
	public sealed class PlayerExecute
	{
		/** Boot
		*/
		public System.Collections.IEnumerator Boot()
		{
			Game.OnMemory t_onmemory = Game.OnMemory.GetSingleton();
			t_onmemory.player = new Game.Player.Player();

			yield break;
		}
	}
}

