

/** Menu
*/
namespace Menu
{
	/** Result
	*/
	public sealed class Result : Menu_Base
	{
		/** eventcallback
		*/
		public EventCallBack_Base eventcallback;

		/** Code
		*/
		public enum Code
		{
			/** 次。
			*/
			Next,

			/** リトライ。
			*/
			Retry,

			/** タイトル。
			*/
			Title,
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

		/** code
		*/
		public Code code;

		/** time
		*/
		public float time;

		/** constructor
		*/
		public Result(EventCallBack_Base a_eventcallback)
		{
			//eventcallback
			this.eventcallback = a_eventcallback;

			//engine
			this.engine = Execute.Engine.GetSingleton();

			//lockflag
			this.lockflag = false;

			//time
			this.time = 0.0f;
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
			//time
			this.time = 0.0f;

			//lockflag
			this.lockflag = false;

			//message_text
			this.message_text = UnityEngine.GameObject.Find("Message_Text").GetComponent<UnityEngine.UI.Text>();
			this.message_text.enabled = true;
			this.message_text.font = Execute.Engine.GetSingleton().font;

			if(Game.OnMemory.GetSingleton().questplayer.result == Game.QuestPlayer.QuestResult.Success){
				if(Game.OnMemory.GetSingleton().questplayer_dataindex + 1 >= Game.OnMemory.GetSingleton().questplayer_filenamelist.Length){
					this.code = Code.Title;
					this.message_text.fontSize = 60;
					this.message_text.text = "THANK YOU FOR PLAYING";
				}else{
					this.code = Code.Next;
					this.message_text.fontSize = 120;
					this.message_text.text = "正解";
				}
			}else{
				Game.OnMemory.GetSingleton().param.life--;

				if(Game.OnMemory.GetSingleton().param.life > 0){
					this.code = Code.Retry;
					this.message_text.fontSize = 120;
					this.message_text.text = "不正解";
				}else{
					this.code = Code.Title;
					this.message_text.fontSize = 120;
					this.message_text.text = "不正解";
				}
			}
		}

		/** [Menu.Menu_Base]End
		*/
		public void End()
		{
			//message_text
			this.message_text.enabled = false;
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
				if(this.time <= 1.0f){
					this.time += UnityEngine.Time.deltaTime;
				}else{
					if(this.engine.mouse_fixedupdate.left.down == true){
						this.eventcallback.Call((int)this.code);
					}
				}
			}
		}
	}
}

