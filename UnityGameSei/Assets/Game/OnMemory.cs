

/** Game
*/
namespace Game
{
	/** 常駐管理。
	*/
	public sealed class OnMemory
	{
		/** [singleton]s_instance
		*/
		private static OnMemory s_instance = null;

		/** [singleton]作成。
		*/
		public static OnMemory CreateSingleton()
		{
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
			s_instance.Dispose();
			s_instance = null;
		}

		/** [singleton]constructor
		*/
		private OnMemory()
		{
		}

		/** [singleton]破棄。
		*/
		private void Dispose()
		{
		}
	}
}

