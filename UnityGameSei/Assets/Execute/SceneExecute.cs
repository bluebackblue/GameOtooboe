

/** Execute
*/
namespace Execute
{
	/** SceneExecute
	*/
	public sealed class SceneExecute
	{
		/** Boot
		*/
		public System.Collections.IEnumerator Boot(BlueBack.Scene.Scene_Base a_scene)
		{
			//シーン管理初期化。
			Execute.Engine.GetSingleton().scene = new BlueBack.Scene.Scene();

			//ブートシーン開始。
			Execute.Engine.GetSingleton().scene.SetNextScene(a_scene);

			yield break;
		}
	}
}

