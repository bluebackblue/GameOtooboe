

/** Game.Enemy
*/
namespace Game.Enemy
{
	/** Enemy
	*/
	public sealed class Enemy : System.IDisposable
	{
		/** 出現順序。
		*/
		public int index;

		/** 位置。
		*/
		public int position;

		/** sprite
		*/
		public BlueBack.Gl.SpriteIndex sprite;
		public int sprite_x;

		/** height
		*/
		public int height;

		/** Mode
		*/
		public enum Mode
		{
			/** 入場。
			*/
			In,

			/** 表示中。
			*/
			View,

			/** 退場。
			*/
			Out,
		}

		/** Result
		*/
		public enum Result
		{
			/** 未設定。
			*/
			None,

			/** 正解。
			*/
			Success,

			/** 失敗。
			*/
			Miss,

			/** 時間切れ。
			*/
			TimeOut,
		}

		/** mode
		*/
		public Mode mode;

		/** result
		*/
		public Result result;

		/** constructor
		*/
		public Enemy(int a_rawindex,int a_index,int a_position)
		{
			this.index = a_index;
			this.position = a_position;

			UnityEngine.Color t_color;
			switch(this.position){
			case 1:
				{
					t_color = new UnityEngine.Color(1,0,0,1);
					this.sprite_x = UnitySetting.Config.SCREEN_W / 2 - 100;
				}break;
			case 2:
				{
					t_color = new UnityEngine.Color(0,1,0,1);
					this.sprite_x = UnitySetting.Config.SCREEN_W / 2 + 100;
				}break;
			default:
				{
					#if(UNITY_EDITOR)
					UnityEngine.Debug.Assert(false);
					#endif

					t_color = new UnityEngine.Color(0,1,0,1);
				}break;
			}

			this.sprite = Execute.Engine.GetSingleton().gl.spritelist[0].CreateSprite(false,(int)UnitySetting.MaterialIndex.Opaque,(int)UnitySetting.TextureIndex.None,in t_color,0,0,0,0,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);
			this.mode = Game.Enemy.Enemy.Mode.In;

			#if(DEF_BLUEBACK_GL_DEBUGVIEW)
			this.sprite.SetDebugName("sprite_enemy_" + a_index.ToString("D2"));
			#endif

			this.height = 128;
		}

		/** Damage
		*/
		public void Damage()
		{
		}

		/** Reset
		*/
		public void Reset()
		{
			this.mode = Game.Enemy.Enemy.Mode.In;
			this.sprite.spritelist.buffer[this.sprite.index].visible = false;
			this.result = Result.None;
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
			if(this.sprite != null){
				this.sprite.spritelist.DeleteSprite(this.sprite);
				this.sprite = null;
			}
		}

		/** UnityFixedUpdate
		*/
		public void UnityFixedUpdate()
		{
			Game.OnMemory t_onmemory = Game.OnMemory.GetSingleton();

			if(t_onmemory.param.phasetype == Param.PhaseType.View){
				switch(this.mode){
				case Mode.In:
					{
						//表示待ち。

						if(t_onmemory.param.gametime_sec >= this.index * t_onmemory.param.popinterval){
							this.mode = Mode.View;
						}
					}break;
				case Mode.View:
					{
						//表示。

						float t_time = t_onmemory.param.gametime_sec - this.index * t_onmemory.param.popinterval;

						int t_y_offset = 256;
						int t_w = 64;
						int t_h = this.height;
						int t_x = this.sprite_x - t_w / 2;
						int t_y = UnitySetting.Config.SCREEN_H + t_y_offset - (int)(t_time * t_onmemory.param.movespeed);

						this.sprite.spritelist.buffer[this.sprite.index].visible = true;
						BlueBack.Gl.SpriteTool.SetXYWH(ref this.sprite.spritelist.buffer[this.sprite.index],t_x,t_y,t_w,t_h,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);

						if(t_y < - t_y_offset){
							this.mode = Mode.Out;
							this.sprite.spritelist.buffer[this.sprite.index].visible = false;
							break;
						}

						//ヒットチェック。
						if((t_y <= t_onmemory.hud.bar_y)&&(t_onmemory.hud.bar_y <= t_y + t_h)){
							t_onmemory.hud.onover_enemy = true;
						}

					}break;
				case Mode.Out:
					{
					}break;
				}
			}else if(t_onmemory.param.phasetype == Param.PhaseType.Play){
				switch(this.mode){
				case Mode.In:
					{
						//表示待ち。

						if(t_onmemory.param.gametime_sec >= this.index * t_onmemory.param.popinterval){
							this.mode = Mode.View;
						}
					}break;
				case Mode.View:
					{
						//表示。

						float t_time = t_onmemory.param.gametime_sec - this.index * t_onmemory.param.popinterval;

						int t_y_offset = 256;
						int t_w = 64;
						int t_h = this.height;
						int t_x = this.sprite_x - t_w / 2;
						int t_y = (int)(t_time * t_onmemory.param.movespeed) - t_y_offset;

						this.sprite.spritelist.buffer[this.sprite.index].visible = true;
						BlueBack.Gl.SpriteTool.SetXYWH(ref this.sprite.spritelist.buffer[this.sprite.index],t_x,t_y,t_w,t_h,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);

						if(t_y > UnitySetting.Config.SCREEN_H + t_y_offset){
							this.mode = Mode.Out;
						}

						//ヒットチェック。
						if((this.result == Result.None)&&(Game.OnMemory.GetSingleton().param.life > 0)){
							if((t_y <= t_onmemory.hud.bar_y)&&(t_onmemory.hud.bar_y <= t_y + t_h)){
								t_onmemory.hud.onover_enemy = true;

								if(Execute.Engine.GetSingleton().mouse_fixedupdate.left.down == true){
									if(this.position == 1){
										//成功。
										this.result = Result.Success;
										this.mode = Mode.Out;
										this.sprite.spritelist.buffer[this.sprite.index].visible = false;

										#if(UNITY_EDITOR)
										UnityEngine.Debug.Log("success");
										#endif

										break;
									}else{
										//ミス。
										this.result = Result.Miss;
										//this.mode = Mode.Out;
										this.sprite.spritelist.buffer[this.sprite.index].visible = false;

										#if(UNITY_EDITOR)
										UnityEngine.Debug.Log("miss");
										#endif

										this.Damage();

										break;
									}
								}else if(Execute.Engine.GetSingleton().mouse_fixedupdate.right.down == true){
									if(this.position == 2){
										//成功。
										this.result = Result.Success;
										this.mode = Mode.Out;
										this.sprite.spritelist.buffer[this.sprite.index].visible = false;

										#if(UNITY_EDITOR)
										UnityEngine.Debug.Log("success");
										#endif

										break;
									}else{
										//ミス。
										this.result = Result.Miss;
										//this.mode = Mode.Out;
										this.sprite.spritelist.buffer[this.sprite.index].visible = false;

										#if(UNITY_EDITOR)
										UnityEngine.Debug.Log("miss");
										#endif

										this.Damage();

										break;
									}
								}
							}else if(t_y > t_onmemory.hud.bar_y){
							
								this.result = Result.TimeOut;
								this.sprite.spritelist.buffer[this.sprite.index].visible = false;

								#if(UNITY_EDITOR)
								UnityEngine.Debug.Log("timeout");
								#endif

								this.Damage();

								break;
							}
						}
					}break;
				case Mode.Out:
					{
					}break;
				}
			}
		}
	}
}

