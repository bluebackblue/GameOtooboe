

/** Execute
*/
namespace Execute
{
	/** FadeExecute
	*/
	public sealed class FadeExecute
	{
		/** Boot
		*/
		public System.Collections.IEnumerator Boot()
		{
			Execute.Engine.GetSingleton().fade = new Game.Fade.Fade();

			yield break;
		}
	}
}

