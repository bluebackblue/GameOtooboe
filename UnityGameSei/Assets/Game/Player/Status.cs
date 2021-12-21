

/** Game.Player
*/
namespace Game.Player
{
	/** Status
	*/
	public sealed class Status
	{
		/** 位置。
		*/
		public UnityEngine.Vector2 pos;

		/** energy
		*/
		public int energy_l;
		public int energy_r;

		/** インゲーム。開始。
		*/
		public void StartInGame()
		{
			//pos
			this.pos = new UnityEngine.Vector2(UnitySetting.Config.SCREEN_W * 0.5f,UnitySetting.Config.SCREEN_H * 0.7f);

			//energy
			this.energy_l = 0;
			this.energy_r = 0;
		}

		/** インゲーム。終了。
		*/
		public void EndInGame()
		{
		}
	}
}

