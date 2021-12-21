

/** Game.Player
*/
namespace Game.Player
{
	/** Player
	*/
	public class Player : System.IDisposable
	{
		/** hud
		*/
		public Hud hud;

		/** status
		*/
		public Status status;

		/** constructor
		*/
		public Player()
		{
			//status
			this.status = new Status();

			//hud
			this.hud = new Hud(this.status);
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
			//model
			if(this.hud != null){
				this.hud.Dispose();
				this.hud = null;
			}

			//status
			this.status = null;
		}

		/** インゲーム。開始。
		*/
		public void StartInGame()
		{
			this.hud.StartInGame();
			this.status.StartInGame();
		}

		/** インゲーム。終了。
		*/
		public void EndInGame()
		{
			this.hud.EndInGame();
			this.status.EndInGame();
		}

		/** UnityUpdate
		*/
		public void UnityUpdate()
		{
			this.hud.Apply();
		}

		/** UnityFixedUpdate
		*/
		public void UnityFixedUpdate()
		{
		}
	}
}

