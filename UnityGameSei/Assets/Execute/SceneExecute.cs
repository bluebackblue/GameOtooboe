

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
			//�V�[���Ǘ��������B
			Execute.Engine.GetSingleton().scene = new BlueBack.Scene.Scene();

			//�u�[�g�V�[���J�n�B
			Execute.Engine.GetSingleton().scene.SetNextScene(a_scene);

			yield break;
		}
	}
}

