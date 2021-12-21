

/** Menu
*/
namespace Menu
{
	/** Menu_Base
	*/
	public interface Menu_Base
	{
		/** [Menu.Menu_Base]破棄。
		*/
		void Dispose();

		/** [Menu.Menu_Base]Start
		*/
		void Start();

		/** [Menu.Menu_Base]End
		*/
		void End();

		/** [Menu.Menu_Base]Lock
		*/
		void Lock();

		/** [Menu.Menu_Base]更新。
		*/
		void UnityUpdate();

		/** [Menu.Menu_Base]更新。
		*/
		void UnityLateUpdate();

		/** [Menu.Menu_Base]更新。
		*/
		void UnityFixedUpdate();

	}
}

