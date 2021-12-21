

/** Game.Player
*/
namespace Game.Player
{
	/** Model
	*/
	public sealed class Hud : System.IDisposable
	{
		/** engine
		*/
		private Execute.Engine engine;

		/** status
		*/
		private Status status;

		/** sprite_player
		*/
		private BlueBack.Gl.SpriteIndex sprite_player;

		/** spritelist
		*/
		private BlueBack.Gl.SpriteList spritelist;

		/** SIZE
		*/
		private const int SIZE = 32;

		/** constructor
		*/
		public Hud(Status a_status)
		{
			//status
			this.status = a_status;

			//engine
			this.engine = Execute.Engine.GetSingleton();

			//spritelist
			this.spritelist = this.engine.gl.spritelist[0];

			//sprite_player
			this.sprite_player = this.spritelist.CreateSprite((int)UnitySetting.MaterialIndex.Opaque,(int)UnitySetting.TextureIndex.None,new UnityEngine.Color(1,1,1,1),0,0,0,0);
			this.spritelist.buffer[this.sprite_player.index].visible = false;
		}

		/** [System.IDisposable]
		*/
		public void Dispose()
		{
			this.spritelist.DeleteSprite(this.sprite_player);
			this.sprite_player = null;
		}

		/** 適応。
		*/
		public void Apply()
		{
			float t_x = this.status.pos.x - SIZE / 2;
			float t_y = this.status.pos.y - SIZE / 2;

			this.spritelist.buffer[this.sprite_player.index].vertex_0 = t_x / UnitySetting.Config.SCREEN_W;
			this.spritelist.buffer[this.sprite_player.index].vertex_1 = 1.0f - t_y / UnitySetting.Config.SCREEN_H;
			this.spritelist.buffer[this.sprite_player.index].vertex_2 = (t_x + SIZE) / UnitySetting.Config.SCREEN_W;
			this.spritelist.buffer[this.sprite_player.index].vertex_3 = 1.0f - t_y / UnitySetting.Config.SCREEN_H;
			this.spritelist.buffer[this.sprite_player.index].vertex_4 = (t_x + SIZE) / UnitySetting.Config.SCREEN_W;
			this.spritelist.buffer[this.sprite_player.index].vertex_5 = 1.0f - (t_y + SIZE) / UnitySetting.Config.SCREEN_H;
			this.spritelist.buffer[this.sprite_player.index].vertex_6 = t_x / UnitySetting.Config.SCREEN_W;
			this.spritelist.buffer[this.sprite_player.index].vertex_7 = 1.0f - (t_y + SIZE) / UnitySetting.Config.SCREEN_H;
		}

		/** インゲーム。開始。
		*/
		public void StartInGame()
		{
			this.spritelist.buffer[this.sprite_player.index].visible = true;
		}

		/** インゲーム。終了。
		*/
		public void EndInGame()
		{
			this.spritelist.buffer[this.sprite_player.index].visible = false;
		}
	}
}

