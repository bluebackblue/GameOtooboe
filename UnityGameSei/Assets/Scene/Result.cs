

/** Scene
*/
namespace Scene
{
	/** リザルト。
	*/
	public sealed class Result : BlueBack.Scene.Scene_Base , Menu.EventCallBack_Base
	{
		/** menu
		*/
		private Menu.Menu_Base menu;

		/** endflag
		*/
		private bool endflag;

		/** constructor

			常駐データ初期化。

		*/
		public Result()
		{
			this.menu = new Menu.Result(this);
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
			this.endflag = false;
		}

		/** [BlueBack.Scene.Scene_Base]カレントシーン。開始。

			a_is_sceneloadend	: シーンの読み込みが完了したかどうか。 
			return == true		: CurrentSceneRunningへの遷移を許可。

		*/
		public bool CurrentSceneStart(bool a_is_sceneloadend)
		{
			if(a_is_sceneloadend == true){
				this.menu.Start();
				return true;
			}
			return false;
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
			this.menu.End();
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
			this.menu.UnityFixedUpdate();
		}

		/** [Menu.EventCallBack_Base]Call

			a_code : いろいろ。

		*/
		public void Call(int a_code)
		{
			//メニュー。操作。ロック。
			this.menu.Lock();

			//最初から。
			Game.OnMemory.GetSingleton().questplayer_dataindex = 1;


			switch((Menu.Result.Code)a_code){
			case Menu.Result.Code.Next:
				{
					//インゲームへ。
					this.endflag = true;
					Execute.Engine.GetSingleton().scene.SetNextScene(Execute.Engine.GetSingleton().scene_list[(int)UnitySetting.SceneIndex.InGame]);

					Game.OnMemory.GetSingleton().questplayer_dataindex++;
				}break;
			case Menu.Result.Code.Title:
				{
					//タイトルへ。
					this.endflag = true;
					Execute.Engine.GetSingleton().scene.SetNextScene(Execute.Engine.GetSingleton().scene_list[(int)UnitySetting.SceneIndex.Title]);
				}break;
			}
		}
	}
}

