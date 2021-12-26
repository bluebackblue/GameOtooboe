

/** @brief ブート。
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
		public static UnityEngine.MonoBehaviour s_monobehaviour = null;

		/** Initialize
		*/
		[UnityEngine.RuntimeInitializeOnLoadMethod]
		private static void Initialize()
		{
			#if(UNITY_EDITOR)
			UnityEngine.Debug.Log("Boot_MonoBehaviour.Initialize");
			#endif

			//削除時にデフォルトに戻す。
			BlueBack.UnityPlayerLoop.UnityPlayerLoop.SetDefaultPlayerLoopOnUnityDestroy();

			UnityEngine.GameObject t_gameobject = new UnityEngine.GameObject("boot");
			s_monobehaviour = t_gameobject.AddComponent<Boot_MonoBehaviour>();
			UnityEngine.GameObject.DontDestroyOnLoad(t_gameobject);

			//エンジン関連。
			Execute.Engine.CreateSingleton();
			Execute.Engine.GetSingleton().append_list = new System.Collections.Generic.List<Execute.AppEnd_Bases>();

			//シーン管理初期化。ブートシーン開始。
			s_monobehaviour.StartCoroutine(new Execute.SceneExecute().Boot(new Scene.Boot()));
		}

		/** OnDisable
		*/
		private void OnDisable()
		{
			#if(UNITY_EDITOR)
			UnityEngine.Debug.Log("Boot_MonoBehaviour.OnDisable");
			#endif

			//エンジン関連。
			Execute.Engine.DeleteSingleton();
		}
	}
}

