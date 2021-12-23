

/** Execute
*/
namespace Execute
{
	/** HudExecute
	*/
	public sealed class HudExecute
	{
		/** Boot
		*/
		public System.Collections.IEnumerator Boot()
		{
			Game.OnMemory t_onmemory = Game.OnMemory.GetSingleton();
			t_onmemory.hud = new Game.Hud.Hud();

			yield break;
		}
	}
}

