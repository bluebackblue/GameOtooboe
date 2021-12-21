

/** Game
*/
namespace Game
{
	/** �풓�Ǘ��B
	*/
	public sealed class OnMemory : Execute.AppEnd_Bases
	{
		/** [singleton]s_instance
		*/
		private static OnMemory s_instance = null;

		/** [singleton]�쐬�B
		*/
		public static OnMemory CreateSingleton()
		{
			s_instance = new OnMemory();
			return s_instance;
		}

		/** [singleton]�擾�B
		*/
		public static OnMemory GetSingleton()
		{
			return s_instance;
		}

		/** [singleton]�폜�B
		*/
		public static void DeleteSingleton()
		{
			s_instance.Dispose();
			s_instance = null;
		}

		/** player
		*/
		public Player.Player player;

		/** [singleton]constructor
		*/
		private OnMemory()
		{
			Execute.Engine.GetSingleton().append_list.Add(this);

			//player
			this.player = null;
		}

		/** [singleton]�j���B
		*/
		private void Dispose()
		{
			if(this.player != null){
				this.player.Dispose();
				this.player = null;
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

