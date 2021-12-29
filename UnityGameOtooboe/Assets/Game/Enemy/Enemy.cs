

/** Game.Enemy
*/
namespace Game.Enemy
{
	/** Enemy
	*/
	public sealed class Enemy : System.IDisposable
	{
		/** インデックス。
		*/
		public int index;

		/** 位置。
		*/
		public int position;

		/** sprite
		*/
		public BlueBack.Gl.SpriteIndex sprite;
		public int sprite_x;

		/** width
		*/
		public int width;

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

		/** seflag
		*/
		public bool seflag;

		/** constructor
		*/
		public Enemy(int a_index,int a_position)
		{
			Game.OnMemory t_onmemory = Game.OnMemory.GetSingleton();

			this.index = a_index;
			this.position = a_position;
			UnityEngine.Color t_color = new UnityEngine.Color(0,0,0,0);
			this.sprite = Execute.Engine.GetSingleton().gl.spritelist[0].CreateSprite(false,(int)UnitySetting.MaterialIndex.Frame,(int)UnitySetting.TextureIndex.None,in t_color,0,0,0,0,in Execute.Engine.GetSingleton().gl_screenparam);
			this.mode = Game.Enemy.Enemy.Mode.In;

			#if(DEF_BLUEBACK_GL_DEBUGVIEW)
			this.sprite.SetDebugViewName("sprite_enemy_" + a_index.ToString("D2"));
			#endif

			this.width = 64;
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
			Game.OnMemory t_onmemory = Game.OnMemory.GetSingleton();

			this.mode = Game.Enemy.Enemy.Mode.In;
			this.sprite.spritelist.buffer[this.sprite.index].visible = false;
			this.result = Result.None;
			this.seflag = true;

			UnityEngine.Color t_color = new UnityEngine.Color(0,0,0,0);
			this.sprite_x = UnitySetting.Config.SCREEN_W / 2;

			if(Game.OnMemory.GetSingleton().param.phasetype == Param.PhaseType.View){
				switch(this.position){
				case -1:
					{
						t_color = new UnityEngine.Color(0,0,0,0);
					}break;
				case 1:
					{
						//色判別可能、位置判別可能。
						t_color = new UnityEngine.Color(1,0,0,1);
					}break;
				case 2:
					{
						//色判別可能、位置判別可能。
						t_color = new UnityEngine.Color(0,1,0,1);
					}break;
				default:
					{
						#if(UNITY_EDITOR)
						UnityEngine.Debug.Assert(false);
						#endif

						t_color = new UnityEngine.Color(0,1,0,1);
					}break;
				}
			}else{
				switch(this.position){
				case -1:
					{
						t_color = new UnityEngine.Color(0,0,0,0);
					}break;
				case 1:
					{
						if(t_onmemory.param.modeblack == 0){
							//色判別可能、位置判別可能。
							t_color = new UnityEngine.Color(1,0,0,1);
						}else if(t_onmemory.param.modeblack == 1){
							//色判別不可。
							t_color = new UnityEngine.Color(0.8f,0.8f,0.8f,1);
						}
					}break;
				case 2:
					{
						if(t_onmemory.param.modeblack == 0){
							//色判別可能、位置判別可能。
							t_color = new UnityEngine.Color(0,1,0,1);
						}else if(t_onmemory.param.modeblack == 1){
							//色判別不可。
							t_color = new UnityEngine.Color(0.8f,0.8f,0.8f,1);
						}
					}break;
				default:
					{
						#if(UNITY_EDITOR)
						UnityEngine.Debug.Assert(false);
						#endif

						t_color = new UnityEngine.Color(0,1,0,1);
					}break;
				}
			}

			this.sprite.spritelist.buffer[this.sprite.index].color = t_color;
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

				int t_space = 256;

				int t_w = this.width;
				int t_h = this.height;
				int t_x = this.sprite_x - t_w / 2;
				int t_y = (int)((t_onmemory.hud.bar_y - this.height / 2) + (this.index * (this.height + t_onmemory.param.space) + UnitySetting.Config.SCREEN_H * 0.5f - t_onmemory.param.gametime_sec * t_onmemory.param.movespeed));

				switch(this.mode){
				case Mode.In:
					{
						//表示待ち。

						if(t_y <= UnitySetting.Config.SCREEN_H + t_space){
							this.mode = Mode.View;
						}
					}break;
				case Mode.View:
					{
						//表示。

						if(this.position >= 0){
							this.sprite.spritelist.buffer[this.sprite.index].visible = true;
						}

						BlueBack.Gl.SpriteTool.SetXYWH(ref this.sprite.spritelist.buffer[this.sprite.index],t_x,t_y,t_w,t_h,in Execute.Engine.GetSingleton().gl_screenparam);

						//ＳＥ再生。
						if(this.seflag == true){
							if((t_y + t_h / 2) < t_onmemory.hud.bar_y){
								this.seflag = false;

								switch(this.position){
								case -1:
									{
										Execute.Engine.GetSingleton().audio_se.PlayOnce(7,0.5f);
									}break;
								case 1:
									{
										Execute.Engine.GetSingleton().audio_se.PlayOnce(1,1.0f);
									}break;
								case 2:
									{
										Execute.Engine.GetSingleton().audio_se.PlayOnce(2,1.0f);
									}break;
								default:
									{
										#if(UNITY_EDITOR)
										UnityEngine.Debug.Assert(false);
										#endif
									}break;
								}
							}
						}

						//範囲外チェック。
						if(t_y + this.height < -t_space){
							this.mode = Mode.Out;
							this.sprite.spritelist.buffer[this.sprite.index].visible = false;
							break;
						}

						//ヒットチェック。
						if(this.position >= 0){
							if((t_y <= t_onmemory.hud.bar_y)&&(t_onmemory.hud.bar_y <= t_y + t_h)){
								t_onmemory.hud.onover_enemy = true;
							}
						}
					}break;
				case Mode.Out:
					{
					}break;
				}
			}else if(t_onmemory.param.phasetype == Param.PhaseType.Play){

				int t_space = 256;

				int t_w = this.width;
				int t_h = this.height;
				int t_x = this.sprite_x - t_w / 2;
				int t_y = (int)((t_onmemory.hud.bar_y - this.height / 2) - (this.index * (this.height + t_onmemory.param.space) + UnitySetting.Config.SCREEN_H * 0.5f - t_onmemory.param.gametime_sec * t_onmemory.param.movespeed));

				switch(this.mode){
				case Mode.In:
					{
						//表示待ち。

						if(t_y + this.height > -t_space){
							this.mode = Mode.View;
						}
					}break;
				case Mode.View:
					{
						//表示。

						if(this.position >= 0){
							this.sprite.spritelist.buffer[this.sprite.index].visible = true;
						}

						BlueBack.Gl.SpriteTool.SetXYWH(ref this.sprite.spritelist.buffer[this.sprite.index],t_x,t_y,t_w,t_h,in Execute.Engine.GetSingleton().gl_screenparam);

						//範囲外チェック。
						if(t_y >= UnitySetting.Config.SCREEN_H + t_space){
							this.mode = Mode.Out;
							this.sprite.spritelist.buffer[this.sprite.index].visible = false;

							if(this.position < 0){
								this.result = Result.Success;
							}

							break;
						}

						//ＳＥ再生。
						if(this.seflag == true){
							if((t_y + t_h / 2) > t_onmemory.hud.bar_y){
								this.seflag = false;

								switch(this.position){
								case -1:
									{
										Execute.Engine.GetSingleton().audio_se.PlayOnce(7,0.5f);
									}break;
								case 1:
								case 2:
									{
									}break;
								default:
									{
										#if(UNITY_EDITOR)
										UnityEngine.Debug.Assert(false);
										#endif
									}break;
								}
							}
						}

						//ヒットチェック。
						if((this.result == Result.None)&&(Game.OnMemory.GetSingleton().param.life > 0)){
							if((t_y <= t_onmemory.hud.bar_y)&&(t_onmemory.hud.bar_y <= t_y + t_h)){
								if(this.position >= 0){
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
								}else{
									//ダミーはスルー。
								}
							}else if(t_y > t_onmemory.hud.bar_y){
								if(this.position >= 0){
									this.result = Result.TimeOut;
									this.sprite.spritelist.buffer[this.sprite.index].visible = false;

									#if(UNITY_EDITOR)
									UnityEngine.Debug.Log("timeout");
									#endif

									this.Damage();

									break;
								}else{
									//ダミーはスルー。
								}
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

