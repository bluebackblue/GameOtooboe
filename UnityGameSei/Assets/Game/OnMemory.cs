

/** Game
*/
namespace Game
{
	/** �풓�Ǘ��B
	*/
	public sealed class OnMemory
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

		/** [singleton]constructor
		*/
		private OnMemory()
		{
		}

		/** [singleton]�j���B
		*/
		private void Dispose()
		{
		}
	}
}

