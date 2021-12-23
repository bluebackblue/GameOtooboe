

/** Game.Hud
*/
namespace Game.Hud
{
	/** Hud
	*/
	public class Hud : System.IDisposable
	{
		/** onover_enemy
		*/
		public bool onover_enemy;

		/** bar
		*/
		public BlueBack.Gl.SpriteIndex bar_spriteindex;
		public int bar_y;
		public bool bar_flag;

		/** life
		*/
		public BlueBack.Gl.SpriteIndex[] life_spriteindex;
		public bool life_flag;

		/** constructor
		*/
		public Hud()
		{
			//onover_enemy
			this.onover_enemy = false;

			//bar_y
			this.bar_y = UnitySetting.Config.SCREEN_H / 2;

			//bar_spriteindex
			this.bar_spriteindex = Execute.Engine.GetSingleton().gl.spritelist[1].CreateSprite(false,(int)UnitySetting.MaterialIndex.Additive,(int)UnitySetting.TextureIndex.None,new UnityEngine.Color(0.5f,0.6f,0.7f,1.0f),0,0,0,0,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);

			this.bar_flag = false;

			//life_spriteindex
			this.life_spriteindex = new BlueBack.Gl.SpriteIndex[4];
			for(int ii=0;ii<this.life_spriteindex.Length;ii++){
				this.life_spriteindex[ii] = Execute.Engine.GetSingleton().gl.spritelist[1].CreateSprite(false,(int)UnitySetting.MaterialIndex.Additive,(int)UnitySetting.TextureIndex.None,new UnityEngine.Color(0.87f,0.68f,0.0f,1.0f),0,0,0,0,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);
			}

			this.life_flag = false;
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
			this.bar_spriteindex.spritelist.DeleteSprite(this.bar_spriteindex);
			for(int ii=0;ii<this.life_spriteindex.Length;ii++){
				this.life_spriteindex[ii].spritelist.DeleteSprite(this.life_spriteindex[ii]);
			}
		}

		/** UnityUpdate
		*/
		public void UnityUpdate()
		{
			if(this.bar_flag == true){
				if(this.onover_enemy == true){
					this.bar_spriteindex.spritelist.buffer[this.bar_spriteindex.index].color = new UnityEngine.Color(0.5f + UnityEngine.Random.value,0.5f + UnityEngine.Random.value,0.5f + UnityEngine.Random.value,1.0f);
				}else{
					this.bar_spriteindex.spritelist.buffer[this.bar_spriteindex.index].color = new UnityEngine.Color(0.5f,0.6f,0.7f,1.0f);
				}
			}

			if(this.life_flag == true){
				for(int ii=0;ii<this.life_spriteindex.Length;ii++){
					if(ii < Game.OnMemory.GetSingleton().param.life){
						this.life_spriteindex[ii].spritelist.buffer[this.life_spriteindex[ii].index].visible = true;
					}else{
						this.life_spriteindex[ii].spritelist.buffer[this.life_spriteindex[ii].index].visible = false;
					}
				}
			}
		}

		/** UnityFixedUpdate
		*/
		public void UnityFixedUpdate()
		{
			this.onover_enemy = false;
		}

		/** DispLife
		*/
		public void DispLife(bool a_flag)
		{
			//life_flag
			this.life_flag = a_flag;

			if(a_flag == true){
				for(int ii=0;ii<this.life_spriteindex.Length;ii++){
					int t_x = UnitySetting.Config.SCREEN_W - 50 - ii * 40;
					int t_y = 20;
					BlueBack.Gl.SpriteTool.SetXYWH(ref this.life_spriteindex[ii].spritelist.buffer[this.life_spriteindex[ii].index],t_x,t_y,30,45,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);
				}
			}
			for(int ii=0;ii<this.life_spriteindex.Length;ii++){
				this.life_spriteindex[ii].spritelist.buffer[this.life_spriteindex[ii].index].visible = false;
			}

			if(this.life_flag == true){
				for(int ii=0;ii<this.life_spriteindex.Length;ii++){
					if(ii < Game.OnMemory.GetSingleton().param.life){
						this.life_spriteindex[ii].spritelist.buffer[this.life_spriteindex[ii].index].visible = true;
					}else{
						this.life_spriteindex[ii].spritelist.buffer[this.life_spriteindex[ii].index].visible = false;
					}
				}
			}
		}

		/** DispBar
		*/
		public void DispBar(bool a_flag)
		{
			//bar_flag
			this.bar_flag = a_flag;

			if(a_flag == true){
				BlueBack.Gl.SpriteTool.SetXYWH(ref this.bar_spriteindex.spritelist.buffer[this.bar_spriteindex.index],0,this.bar_y,UnitySetting.Config.SCREEN_W,4,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);
			}
			this.bar_spriteindex.spritelist.buffer[this.bar_spriteindex.index].visible = a_flag;

			if(this.bar_flag == true){
				if(this.onover_enemy == true){
					this.bar_spriteindex.spritelist.buffer[this.bar_spriteindex.index].color = new UnityEngine.Color(0.5f + UnityEngine.Random.value,0.5f + UnityEngine.Random.value,0.5f + UnityEngine.Random.value,1.0f);
				}else{
					this.bar_spriteindex.spritelist.buffer[this.bar_spriteindex.index].color = new UnityEngine.Color(0.5f,0.6f,0.7f,1.0f);
				}
			}
		}
	}
}

