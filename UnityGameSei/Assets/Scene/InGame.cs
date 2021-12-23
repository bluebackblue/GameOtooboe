

/** Scene
*/
namespace Scene
{
	/** インゲーム。
	*/
	public sealed class InGame : BlueBack.Scene.Scene_Base
	{
		/** onmemory
		*/
		private Game.OnMemory onmemory;

		/** constructor

			常駐データ初期化。

		*/
		public InGame()
		{
			//onmemory
			this.onmemory = Game.OnMemory.GetSingleton();
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
			if(a_is_sceneloadend == true){

				//enemy_list
				this.onmemory.enemy_list = new System.Collections.Generic.List<Game.Enemy.Enemy>();

				//questplayer
				this.onmemory.questplayer.Load(Game.OnMemory.GetSingleton().questplayer_dataindex);

				//ライフ表示。
				this.onmemory.hud.DispLife(true);

				return true;
			}

			return false;
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。実行。

			return == true : CurrentSceneEndFirstへの遷移を許可。

		*/
		public bool CurrentSceneRunning()
		{
			#pragma warning disable 0162
			switch(this.onmemory.questplayer.result){
			case Game.QuestPlayer.QuestResult.Success:
			case Game.QuestPlayer.QuestResult.Faild:
				{
					Execute.Engine t_engine = Execute.Engine.GetSingleton();
					t_engine.scene.SetNextScene(t_engine.scene_list[(int)UnitySetting.SceneIndex.Result]);
					return true;
				}break;
			}
			#pragma warning restore

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
			//ライフ非表示。
			this.onmemory.hud.DispLife(false);

			//questplayer
			this.onmemory.questplayer.UnLoad();

			//enemy_list
			this.onmemory.enemy_list = null;

			return true;
		}

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		public void UnityUpdate()
		{
			//hud
			this.onmemory.hud.UnityUpdate();
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
			//hud
			this.onmemory.hud.UnityFixedUpdate();

			//questplayer
			this.onmemory.questplayer.UnityFixedUpdate();

			//enemy
			foreach(Game.Enemy.Enemy t_enemy in this.onmemory.enemy_list){
				t_enemy.UnityFixedUpdate();
			}
		}
	}
}

