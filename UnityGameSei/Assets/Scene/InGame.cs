

/** Scene
*/
namespace Scene
{
	/** インゲーム。
	*/
	public sealed class InGame : BlueBack.Scene.Scene_Base
	{
		/** constructor

			常駐データ初期化。

		*/
		public InGame()
		{
		}

		/** [BlueBack.Scene.Scene_Base]シーン名。
		*/
		public string GetSceneName()
		{
			return "InGame";
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
			return false;
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
	}
}

