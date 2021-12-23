

/** Scene
*/
namespace Scene
{
	/** インゲーム。
	*/
	public sealed class Result : BlueBack.Scene.Scene_Base
	{
		/** onmemory
		*/
		private Game.OnMemory onmemory;

		/** constructor

			常駐データ初期化。

		*/
		public Result()
		{
			//onmemory
			this.onmemory = Game.OnMemory.GetSingleton();
		}

		/** [BlueBack.Scene.Scene_Base]シーン名。
		*/
		public string GetSceneName()
		{
			return "Result";
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
			//onmemory
			this.onmemory.player.StartInGame();

			return true;
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。実行。

			return == true : CurrentSceneEndFirstへの遷移を許可。

		*/
		public bool CurrentSceneRunning()
		{
			/* TODO:ゲームオーバー
			this.time++;
			if(this.time >= 100){
				Execute.Engine t_engine = Execute.Engine.GetSingleton();
				t_engine.scene.SetNextScene(t_engine.scene_list[(int)UnitySetting.SceneIndex.Title]);
				return true;
			}
			*/

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
			//onmemory
			this.onmemory.player.EndInGame();

			return true;
		}

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		public void UnityUpdate()
		{
			this.onmemory.player.UnityUpdate();
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
			this.onmemory.player.UnityFixedUpdate();
		}
	}
}

