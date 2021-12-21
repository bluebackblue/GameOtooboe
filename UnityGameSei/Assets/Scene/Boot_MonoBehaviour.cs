

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
			Execute.Engine.GetSingleton().append_list = new System.Collections.Generic.List<Execute.AppEnd_Bases>();

			//�V�[���Ǘ��������B�u�[�g�V�[���J�n�B
			s_monobehaviour.StartCoroutine(new Execute.SceneExecute().Boot(new Scene.Boot()));
		}

		/** OnDisable
		*/
		private void OnDisable()
		{
			//�G���W���֘A�B
			Execute.Engine.DeleteSingleton();

			#if(UNITY_EDITOR)
			UnityEngine.Debug.Log("OnDisable");
			#endif
		}
	}
}

