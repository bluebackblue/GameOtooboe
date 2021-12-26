

/** Game
*/
namespace Game
{
	/** 常駐管理。
	*/
	public sealed class OnMemory : Execute.AppEnd_Bases
	{
		/** [singleton]s_instance
		*/
		private static OnMemory s_instance = null;

		/** [singleton]作成。
		*/
		public static OnMemory CreateSingleton()
		{
			#if(UNITY_EDITOR)
			UnityEngine.Debug.Assert(s_instance == null);
			#endif

			s_instance = new OnMemory();
			return s_instance;
		}

		/** [singleton]取得。
		*/
		public static OnMemory GetSingleton()
		{
			return s_instance;
		}

		/** [singleton]削除。
		*/
		public static void DeleteSingleton()
		{
			UnityEngine.Debug.Log("OnMemory.DeleteSingleton");

			s_instance.Dispose();
			s_instance = null;
		}

		/** hud
		*/
		public Hud.Hud hud;

		/** questplayer
		*/
		public QuestPlayer.QuestPlayer<GameData.QuestPlayer.QuestItem> questplayer;
		public int questplayer_dataindex;
		public string[] questplayer_filenamelist;

		/** enemy_list
		*/
		public System.Collections.Generic.List<Game.Enemy.Enemy> enemy_list;

		/** param
		*/
		public Param.Param param;

		/** [singleton]constructor
		*/
		private OnMemory()
		{
			Execute.Engine.GetSingleton().append_list.Add(this);

			//hud
			this.hud = null;

			//questplayer
			this.questplayer = null;
			this.questplayer_dataindex = 0;
			this.questplayer_filenamelist = null;

			//enemy_list
			this.enemy_list = null;

			//param
			this.param = null;
		}

		/** [singleton]破棄。
		*/
		private void Dispose()
		{
			if(this.hud != null){
				this.hud.Dispose();
				this.hud = null;
			}
		}

		/** [Execute.AppEnd_Bases]OnAppEnd
		*/
		public void OnAppEnd()
		{
			DeleteSingleton();
		}
	}
}

