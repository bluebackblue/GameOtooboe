

/** Execute
*/
namespace Execute
{
	/** ParamExecute
	*/
	public sealed class ParamExecute
	{
		/** Boot
		*/
		public System.Collections.IEnumerator Boot()
		{
			Game.OnMemory t_onmemory = Game.OnMemory.GetSingleton();
			t_onmemory.param = new Game.Param.Param();

			yield break;
		}
	}
}

