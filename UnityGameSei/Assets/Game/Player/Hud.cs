

/** Game.Player
*/
namespace Game.Player
{
	/** Hud
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

		/** sprite_energy
		*/
		private BlueBack.Gl.SpriteIndex sprite_energy_l;
		private BlueBack.Gl.SpriteIndex sprite_energy_r;

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

			//sprite_player
			this.sprite_player = this.engine.gl.spritelist[0].CreateSprite(false,(int)UnitySetting.MaterialIndex.Opaque,(int)UnitySetting.TextureIndex.None,new UnityEngine.Color(1,1,1,1),0,0,0,0,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);

			//sprite_energy
			this.sprite_energy_l = this.engine.gl.spritelist[0].CreateSprite(false,(int)UnitySetting.MaterialIndex.Opaque,(int)UnitySetting.TextureIndex.None,new UnityEngine.Color(0,0,1,1),0,0,0,0,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);
			this.sprite_energy_r = this.engine.gl.spritelist[0].CreateSprite(false,(int)UnitySetting.MaterialIndex.Opaque,(int)UnitySetting.TextureIndex.None,new UnityEngine.Color(1,0,0,1),0,0,0,0,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);

			//GcWithSwapBuffer
			//TODO:this.engine.gl.spritelist[0].list.GcWithSwapBuffer();
		}

		/** [System.IDisposable]
		*/
		public void Dispose()
		{
			this.sprite_player.spritelist.DeleteSprite(this.sprite_player);
			this.sprite_player = null;
		}

		/** 適応。
		*/
		public void Apply()
		{
			BlueBack.Gl.SpriteTool.SetXYWH(ref this.sprite_player.spritelist.buffer[this.sprite_player.index],(int)(this.status.pos.x - SIZE / 2),(int)(this.status.pos.y - SIZE / 2),SIZE,SIZE,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);

			{
				int t_w = (int)(64);
				int t_h = (int)(100 * this.status.energy_l);
				int t_x = (int)(100) - t_w / 2;
				int t_y = (int)(UnitySetting.Config.SCREEN_H - t_h);

				BlueBack.Gl.SpriteTool.SetXYWH(ref this.sprite_energy_l.spritelist.buffer[this.sprite_energy_l.index],t_x,t_y,t_w,t_h,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);
			}

			{
				int t_w = (int)(64);
				int t_h = (int)(100 * this.status.energy_r);
				int t_x = (int)(UnitySetting.Config.SCREEN_W - 100) - t_w / 2;
				int t_y = (int)(UnitySetting.Config.SCREEN_H - t_h);

				BlueBack.Gl.SpriteTool.SetXYWH(ref this.sprite_energy_r.spritelist.buffer[this.sprite_energy_r.index],t_x,t_y,t_w,t_h,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);
			}
		}

		/** インゲーム。開始。
		*/
		public void StartInGame()
		{
			this.sprite_player.spritelist.buffer[this.sprite_player.index].visible = true;
			this.sprite_energy_l.spritelist.buffer[this.sprite_energy_l.index].visible = true;
			this.sprite_energy_r.spritelist.buffer[this.sprite_energy_r.index].visible = true;
		}

		/** インゲーム。終了。
		*/
		public void EndInGame()
		{
			this.sprite_player.spritelist.buffer[this.sprite_player.index].visible = false;
			this.sprite_energy_l.spritelist.buffer[this.sprite_energy_l.index].visible = false;
			this.sprite_energy_r.spritelist.buffer[this.sprite_energy_r.index].visible = false;
		}
	}
}

