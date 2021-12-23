

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
			Success = 0,
		}

		/** engine
		*/
		public Execute.Engine engine;

		/** lockflag
		*/
		public bool lockflag;

		/** sprite_startbutton
		*/
		public BlueBack.Gl.SpriteIndex sprite_startbutton;

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

			//sprite_startbutton
			{
				int t_w = 256;
				int t_h = 256;
				int t_x = (UnitySetting.Config.SCREEN_W - t_w) / 2;
				int t_y = (UnitySetting.Config.SCREEN_H - t_h) / 2;
				this.sprite_startbutton = this.engine.gl.spritelist[0].CreateSprite(false,(int)UnitySetting.MaterialIndex.Opaque,(int)UnitySetting.TextureIndex.Title_StartButton,new UnityEngine.Color(1,1,1,1),t_x,t_y,t_w,t_h,UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H);
				#if(DEF_BLUEBACK_GL_DEBUGVIEW)
				this.sprite_startbutton.SetDebugName("title_startbutton");
				#endif
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
			this.sprite_startbutton.spritelist.buffer[this.sprite_startbutton.index].visible = true;
			this.lockflag = false;
		}

		/** [Menu.Menu_Base]End
		*/
		public void End()
		{
			this.sprite_startbutton.spritelist.buffer[this.sprite_startbutton.index].visible = false;
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
				if(this.engine.mouse_fixedupdate.left.down == true){				
					this.eventcallback.Call((int)Code.Success);
				}
			}
		}
	}
}

