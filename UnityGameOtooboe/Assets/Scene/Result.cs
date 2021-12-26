

/** Scene
*/
namespace Scene
{
	/** リザルト。
	*/
	public sealed class Result : BlueBack.Scene.Scene_Base , Menu.EventCallBack_Base
	{
		/** onmemory
		*/
		private Game.OnMemory onmemory;

		/** menu
		*/
		private Menu.Menu_Base menu;

		/** endflag
		*/
		private bool endflag;

		/** code
		*/
		private Menu.Result.Code code;

		/** constructor

			常駐データ初期化。

		*/
		public Result()
		{
			//onmemory
			this.onmemory = Game.OnMemory.GetSingleton();

			//menu
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
				if(Execute.Engine.GetSingleton().fade.SetVisible(false) == true){
					this.menu.Start();
					this.onmemory.hud.DispLife(true);
				}
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
			if(Execute.Engine.GetSingleton().fade.SetVisible(true) == true){
				this.onmemory.hud.DispLife(false);
				this.menu.End();
				return true;
			}
			return false;
		}

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		public void UnityUpdate()
		{
			//hud
			this.onmemory.hud.UnityUpdate();

			//menu
			this.menu.UnityUpdate();
		}

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		public void UnityLateUpdate()
		{
			//menu
			this.menu.UnityLateUpdate();
		}

		/** [BlueBack.Scene.Scene_Base]更新。
		*/
		public void UnityFixedUpdate()
		{
			//hud
			this.onmemory.hud.UnityFixedUpdate();

			//menu
			this.menu.UnityFixedUpdate();
		}

		/** [Menu.EventCallBack_Base]Call

			a_code : いろいろ。

		*/
		public void Call(int a_code)
		{
			//メニュー。操作。ロック。
			this.menu.Lock();

			//code
			this.code = (Menu.Result.Code)a_code;

			switch(this.code){
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

					//最初から。
					Game.OnMemory.GetSingleton().questplayer_dataindex = 0;
				}break;
			case Menu.Result.Code.Retry:
				{
					//インゲームへ。
					this.endflag = true;
					Execute.Engine.GetSingleton().scene.SetNextScene(Execute.Engine.GetSingleton().scene_list[(int)UnitySetting.SceneIndex.InGame]);
				}break;
			}
		}
	}
}

