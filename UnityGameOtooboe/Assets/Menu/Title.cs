

/** Menu
*/
namespace Menu
{
	/** Title
	*/
	public sealed class Title : Menu_Base
	{
		/** eventcallback
		*/
		public EventCallBack_Base eventcallback;

		/** Code
		*/
		public enum Code
		{
			InGame,
		}

		/** engine
		*/
		public Execute.Engine engine;

		/** lockflag
		*/
		public bool lockflag;

		/** message_text
		*/
		public UnityEngine.UI.Text message_text;

		/** time
		*/
		public float time;
		public int time_count;

		/** volume_sprite
		*/
		public BlueBack.Gl.SpriteIndex[] volume_sprite;

		/** constructor
		*/
		public Title(EventCallBack_Base a_eventcallback)
		{
			//eventcallback
			this.eventcallback = a_eventcallback;

			//engine
			this.engine = Execute.Engine.GetSingleton();

			//lockflag
			this.lockflag = false;

			//time
			this.time = 0.0f;
			this.time_count = 0;

			//volume
			{
				this.volume_sprite = new BlueBack.Gl.SpriteIndex[5];
				for(int ii=0;ii<this.volume_sprite.Length;ii++){
					int t_w = 30;
					int t_h = 40;
					int t_x = 16 + ii * (t_w + 16);
					int t_y = UnitySetting.Config.SCREEN_H - t_h - 16;

					UnityEngine.Color t_color;
					if(ii == 0){
						t_color = new UnityEngine.Color(1.0f,0.3f,0.3f,1.0f);
					}else{
						t_color = new UnityEngine.Color(0.3f,0.3f,1.0f,1.0f);
					}

					this.volume_sprite[ii] = Execute.Engine.GetSingleton().gl.spritelist[0].CreateSprite(false,(int)UnitySetting.MaterialIndex.Frame,(int)UnitySetting.TextureIndex.None,t_color,t_x,t_y,t_w,t_h,in Execute.Engine.GetSingleton().gl_screenparam);
				}
			}

		}

		/** [Menu.Menu_Base]破棄。
		*/
		public void Dispose()
		{
		}

		/** [Menu.Menu_Base]Start
		*/
		public void Start()
		{
			this.lockflag = false;

			this.message_text = UnityEngine.GameObject.Find("Message_Text").GetComponent<UnityEngine.UI.Text>();
			this.message_text.text = "Click";
			this.message_text.enabled = true;
			this.message_text.font = Execute.Engine.GetSingleton().font;
		}

		/** [Menu.Menu_Base]End
		*/
		public void End()
		{
			for(int ii=0;ii<this.volume_sprite.Length;ii++){
				this.volume_sprite[ii].spritelist.buffer[this.volume_sprite[ii].index].visible = false;
			}
		}

		/** [Menu.Menu_Base]Lock
		*/
		public void Lock()
		{
			this.lockflag = true;
		}

		/** [Menu.Menu_Base]更新。
		*/
		public void UnityUpdate()
		{
			if(this.lockflag == false){
				if(UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.UpArrow) == true){
					Execute.Engine.GetSingleton().audio_se.SetVolumeIndex(Execute.Engine.GetSingleton().audio_se.volume_index + 1);
				}else if(UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.DownArrow) == true){
					Execute.Engine.GetSingleton().audio_se.SetVolumeIndex(Execute.Engine.GetSingleton().audio_se.volume_index - 1);
				}
			}

			for(int ii=0;ii<this.volume_sprite.Length;ii++){
				if(ii <= Execute.Engine.GetSingleton().audio_se.volume_index){
					this.volume_sprite[ii].spritelist.buffer[this.volume_sprite[ii].index].visible = true;
				}else{
					this.volume_sprite[ii].spritelist.buffer[this.volume_sprite[ii].index].visible = false;
				}
			}
		}

		/** [Menu.Menu_Base]更新。
		*/
		public void UnityLateUpdate()
		{
		}

		/** [Menu.Menu_Base]更新。
		*/
		public void UnityFixedUpdate()
		{
			if(this.lockflag == false){
				if(new UnityEngine.Vector2(this.engine.mouse_fixedupdate.cursor.pos.x - 0.5f,this.engine.mouse_fixedupdate.cursor.pos.y - 0.5f).magnitude <= 0.1f){
					this.message_text.color = new UnityEngine.Color(1.0f,0.0f,0.0f,1.0f);
					if(this.engine.mouse_fixedupdate.left.down == true){
						Execute.Engine.GetSingleton().audio_se.PlayOnce(1,1.0f);
						this.eventcallback.Call((int)Code.InGame);
					}
				}else{
					this.message_text.color = new UnityEngine.Color(1.0f,1.0f,1.0f,1.0f);
				}

				this.time += UnityEngine.Time.fixedDeltaTime;
				if(this.time >= 0.6f){
					this.time -= 0.6f;
					this.time_count = (this.time_count + 1) % 4;

					if(Scene.Boot_MonoBehaviour.s_isfocus == true){
						if(this.time_count == 1){
							Execute.Engine.GetSingleton().audio_se.PlayOnce(1,1.0f);
						}else{
							Execute.Engine.GetSingleton().audio_se.PlayOnce(2,1.0f);
						}
					}
				}
			}
		}
	}
}

