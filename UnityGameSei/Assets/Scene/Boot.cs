

/** @brief ブート。
*/


/** Scene
*/
namespace Scene
{
	/** Boot
	*/
	public sealed class Boot : BlueBack.Scene.Scene_Base
	{
		/** endflag
		*/
		public bool endflag;

		/** [BlueBack.Scene.Scene_Base]シーン名。
		*/
		public string GetSceneName()
		{
			return null;
		}

		/** [BlueBack.Scene.Scene_Base]前シーン。終了。初回。
		*/
		public void BeforeSceneEndFirst()
		{
		}

		/** [BlueBack.Scene.Scene_Base]前シーン。終了。
		*/
		public void BeforeSceneEnd()
		{
		}

		/** [BlueBack.Scene.Scene_Base]前シーン。終了。ラスト。
		*/
		public void BeforeSceneEndLast()
		{
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。開始。初回。
		*/
		public void CurrentSceneStartFirst()
		{
			this.endflag = false;
			Boot_MonoBehaviour.s_monobehaviour.StartCoroutine(this.CoroutineMain());
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。開始。

			a_is_sceneloadend	: シーンの読み込みが完了したかどうか。 
			return == true		: CurrentSceneRunningへの遷移を許可。

		*/
		public bool CurrentSceneStart(bool a_is_sceneloadend)
		{
			return true;
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。実行。

			return == true : CurrentSceneEndFirstへの遷移を許可。

		*/
		public bool CurrentSceneRunning()
		{
			return this.endflag;
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。終了。初回。
		*/
		public void CurrentSceneEndFirst()
		{
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。終了。

			return == true : シーン遷移を許可。

		*/
		public bool CurrentSceneEnd()
		{
			return true;
		}

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		public void UnityUpdate()
		{
		}

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		public void UnityLateUpdate()
		{
		}

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		public void UnityFixedUpdate()
		{
		}

		/** CoroutineMain
		*/
		private System.Collections.IEnumerator CoroutineMain()
		{
			Execute.Engine t_engine = Execute.Engine.GetSingleton();
			UnityEngine.MonoBehaviour t_monobehaviour = Boot_MonoBehaviour.s_monobehaviour;

			//常駐。
			Game.OnMemory.CreateSingleton();

			//ＧＬ。
			t_monobehaviour.StartCoroutine(new Execute.GlExecute().Boot());

			//マウス。
			t_monobehaviour.StartCoroutine(new Execute.MouseExecute().Boot());

			//シーン。
			t_engine.scene_list = new BlueBack.Scene.Scene_Base[(int)UnitySetting.SceneIndex.Max];
			t_engine.scene_list[(int)UnitySetting.SceneIndex.Title] = new Scene.Title();
			t_engine.scene_list[(int)UnitySetting.SceneIndex.InGame] = new Scene.InGame();

			//タイトルへ。
			t_engine.scene.SetNextScene(t_engine.scene_list[(int)UnitySetting.SceneIndex.Title]);

			this.endflag = true;
			yield break;
		}
	}
}

