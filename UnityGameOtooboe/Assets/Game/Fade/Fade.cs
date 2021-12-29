

/** Game.Fade
*/
namespace Game.Fade
{
	/** Fade
	*/
	public sealed class Fade : System.IDisposable
	{
		/** Mode
		*/
		public enum Mode
		{
			Out,
			In,
			FadeIn,
			FadeOut,
		}

		/** mode
		*/
		public Mode mode;

		/** Item
		*/
		public struct Item
		{
			public BlueBack.Gl.SpriteIndex sprite;
			public float time;
		}

		/** sprite
		*/
		public Item[] list;


		/** fade_gameobject
		*/
		public UnityEngine.GameObject fade_gameobject;
		public Fade_MonoBehaviour fade_monobehaviour;

		/** time
		*/
		public float time;

		/** constructor
		*/
		public Fade()
		{
			//fade_gameobject
			this.fade_gameobject = new UnityEngine.GameObject("fade");
			UnityEngine.GameObject.DontDestroyOnLoad(this.fade_gameobject);
			this.fade_monobehaviour = this.fade_gameobject.AddComponent<Fade_MonoBehaviour>();
			this.fade_monobehaviour.fade = this;
			this.fade_monobehaviour.visible = false;

			//mode
			this.mode = Mode.In;

			//sprite
			this.list = new Item[21 * 12];
			for(int ii = 0;ii < this.list.Length;ii++){
				this.list[ii].sprite = Execute.Engine.GetSingleton().gl.spritelist[2].CreateSprite(false,(int)UnitySetting.MaterialIndex.Transparent,(int)UnitySetting.TextureIndex.None,UnityEngine.Color.black,0,0,0,0,in Execute.Engine.GetSingleton().gl_screenparam);
			}
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
			if(this.fade_gameobject != null){
				UnityEngine.GameObject.Destroy(this.fade_gameobject);
				this.fade_gameobject = null;
			}
		}

		/** SetVisible

			return == true : Š®—¹B

		*/
		public bool SetVisible(bool a_flag)
		{
			this.fade_monobehaviour.visible = a_flag;

			if(a_flag == true){
				if(this.mode == Mode.Out){
					return true;
				}
			}else{
				if(this.mode == Mode.In){
					return true;
				}
			}

			return false;
		}

		/** UnityUpdate
		*/
		public void UnityUpdate()
		{
			switch(this.mode){
			case Mode.Out:
				{
					if(this.fade_monobehaviour.visible == false){
						this.time = 1.0f;
						this.mode = Mode.FadeIn;

						for(int ii = 0;ii < this.list.Length;ii++){
							this.list[ii].time = UnityEngine.Random.value;
						}
					}
				}break;
			case Mode.In:
				{
					if(this.fade_monobehaviour.visible == true){
						this.time = 0.0f;
						this.mode = Mode.FadeOut;

						for(int ii = 0;ii < this.list.Length;ii++){
							float t_color_value = UnityEngine.Random.value * 0.1f;
							this.list[ii].sprite.spritelist.buffer[this.list[ii].sprite.index].color = new UnityEngine.Color(t_color_value,t_color_value,t_color_value,1.0f);
							this.list[ii].sprite.spritelist.buffer[this.list[ii].sprite.index].visible = false;
							this.list[ii].time = (1.0f / (21 * 12)) * ii;

							int t_x = (ii % 21) * 64;
							int t_y  = (ii / 21) * 64;
							int t_w = 64;
							int t_h = 64;
							BlueBack.Gl.SpriteTool.SetXYWH(ref this.list[ii].sprite.spritelist.buffer[this.list[ii].sprite.index],t_x,t_y,t_w,t_h,in Execute.Engine.GetSingleton().gl_screenparam);
						}
					}
				}break;
			case Mode.FadeIn:
				{
					this.time -= UnityEngine.Mathf.Clamp01(UnityEngine.Time.deltaTime * 9.0f);

					for(int ii = 0;ii < this.list.Length;ii++){
						if(this.list[ii].time <= this.time){
							this.list[ii].sprite.spritelist.buffer[this.list[ii].sprite.index].visible = true;
						}else{
							this.list[ii].sprite.spritelist.buffer[this.list[ii].sprite.index].visible = false;
						}
					}
					
					if(this.time <= 0.0f){
						for(int ii = 0;ii < this.list.Length;ii++){
							this.list[ii].sprite.spritelist.buffer[this.list[ii].sprite.index].visible = false;
						}
						this.mode = Mode.In;
					}
				}
				break;
			case Mode.FadeOut:
				{
					this.time += UnityEngine.Mathf.Clamp01(UnityEngine.Time.deltaTime * 9.0f);

					for(int ii = 0;ii < this.list.Length;ii++){
						if(this.list[ii].time <= this.time){
							this.list[ii].sprite.spritelist.buffer[this.list[ii].sprite.index].visible = true;
						}else{
							this.list[ii].sprite.spritelist.buffer[this.list[ii].sprite.index].visible = false;
						}
					}

					if(this.time >= 1.0f) {
						this.mode = Mode.Out;
					}
				}break;
			}
		}
	}
}

