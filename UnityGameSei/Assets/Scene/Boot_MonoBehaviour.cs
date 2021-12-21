

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
		public static UnityEngine.MonoBehaviour s_monobehaviour;

		/** Initialize
		*/
		[UnityEngine.RuntimeInitializeOnLoadMethod]
		private static void Initialize()
		{
			//削除時にデフォルトに戻す。
			BlueBack.UnityPlayerLoop.UnityPlayerLoop.SetDefaultPlayerLoopOnUnityDestroy();

			UnityEngine.GameObject t_gameobject = new UnityEngine.GameObject("boot");
			s_monobehaviour = t_gameobject.AddComponent<Boot_MonoBehaviour>();
			UnityEngine.GameObject.DontDestroyOnLoad(t_gameobject);

			//エンジン関連。
			Execute.Engine.CreateSingleton();

			//シーン管理初期化。ブートシーン開始。
			s_monobehaviour.StartCoroutine(new Execute.SceneExecute().Boot(new Scene.Boot()));
		}

		/** OnDestroy
		*/
		private void OnDestroy()
		{
			//TODO:シャットダウンコールバック。
			//Execute.Shutdown.Call();

			//エンジン関連。
			Execute.Engine.DeleteSingleton();
		}
	}
}

