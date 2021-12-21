

/** @brief �u�[�g�B
*/


/** Scene
*/
namespace Scene
{
	/** Boot_MonoBehaviour
	*/
	public sealed class Boot_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** s_monobehaviour
		*/
		public static UnityEngine.MonoBehaviour s_monobehaviour;

		/** Initialize
		*/
		[UnityEngine.RuntimeInitializeOnLoadMethod]
		private static void Initialize()
		{
			//�폜���Ƀf�t�H���g�ɖ߂��B
			BlueBack.UnityPlayerLoop.UnityPlayerLoop.SetDefaultPlayerLoopOnUnityDestroy();

			UnityEngine.GameObject t_gameobject = new UnityEngine.GameObject("boot");
			s_monobehaviour = t_gameobject.AddComponent<Boot_MonoBehaviour>();
			UnityEngine.GameObject.DontDestroyOnLoad(t_gameobject);

			//�G���W���֘A�B
			Execute.Engine.CreateSingleton();

			//�V�[���Ǘ��������B�u�[�g�V�[���J�n�B
			s_monobehaviour.StartCoroutine(new Execute.SceneExecute().Boot(new Scene.Boot()));
		}

		/** OnDestroy
		*/
		private void OnDestroy()
		{
			//TODO:�V���b�g�_�E���R�[���o�b�N�B
			//Execute.Shutdown.Call();

			//�G���W���֘A�B
			Execute.Engine.DeleteSingleton();
		}
	}
}

