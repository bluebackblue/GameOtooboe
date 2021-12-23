

/** Game.Hud
*/
namespace Game.Hud
{
	/** Hud
	*/
	public class Hud : System.IDisposable
	{
		/** disp_flag
		*/
		public bool disp_flag;

		/** onover_enemy
		*/
		public bool onover_enemy;

		/** bar
		*/
		public BlueBack.Gl.SpriteIndex bar_spriteindex;
		public int bar_y;

		/** constructor
		*/
		public Hud()
		{
			//disp_flag
			this.disp_flag = false;

			//onover_enemy
			this.onover_enemy = false;

			//bar_y
			this.bar_y = UnitySetting.Config.SCREEN_H / 2;

			//bar_spriteindex
			this.bar_spriteindex = Execute.Engine.GetSingleton().gl.spritelist[1].CreateSprite(false,(int)UnitySetting.MaterialIndex.Additive,(int)UnitySetting.TextureIndex.None,new UnityEngine.Color(0.5f,0.6f,0.7f,1),0,0,0,0,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
		}

		/** インゲーム。開始。
		*/
		public void StartInGame()
		{
		}

		/** インゲーム。終了。
		*/
		public void EndInGame()
		{
		}

		/** UnityUpdate
		*/
		public void UnityUpdate()
		{
			if(this.onover_enemy == true){
				this.bar_spriteindex.spritelist.buffer[this.bar_spriteindex.index].color = new UnityEngine.Color(0.5f + UnityEngine.Random.value,0.5f + UnityEngine.Random.value,0.5f + UnityEngine.Random.value,1.0f);
			}else{
				this.bar_spriteindex.spritelist.buffer[this.bar_spriteindex.index].color = new UnityEngine.Color(0.5f,0.6f,0.7f,1.0f);
			}
		}

		/** UnityFixedUpdate
		*/
		public void UnityFixedUpdate()
		{
			this.onover_enemy = false;
		}

		/** 表示。
		*/
		public void Disp(bool a_flag)
		{
			//disp_flag
			this.disp_flag = a_flag;

			if(this.disp_flag == true){
				BlueBack.Gl.SpriteTool.SetXYWH(ref this.bar_spriteindex.spritelist.buffer[this.bar_spriteindex.index],0,this.bar_y,UnitySetting.Config.SCREEN_W,4,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);
			}

			//bar_spriteindex
			this.bar_spriteindex.spritelist.buffer[this.bar_spriteindex.index].visible = a_flag;
		}
	}
}

