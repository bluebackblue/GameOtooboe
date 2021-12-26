

/** Execute
*/
namespace Execute
{
	/** FontExecute
	*/
	public sealed class FontExecute
	{
		/** Boot
		*/
		public System.Collections.IEnumerator Boot()
		{
			UnityEngine.GameObject t_gameobject = UnityEngine.Resources.Load<UnityEngine.GameObject>("Font/Font");
			Execute.Engine.GetSingleton().font = t_gameobject.GetComponent<GameData.Font.Font_MonoBehaviour>().font;

			yield break;
		}
	}
}

