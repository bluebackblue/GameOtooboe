

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

		/** all_clear
		*/
		public bool all_clear;

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
			//lockflag
			this.lockflag = false;

			//message_text
			this.message_text = UnityEngine.GameObject.Find("Message_Text").GetComponent<UnityEngine.UI.Text>();
			this.message_text.enabled = true;

			//TODO:GameData.QuestPlayer.Dataから次が存在するかチェック。
			if(Game.OnMemory.GetSingleton().questplayer_dataindex >= 2){
				this.all_clear = true;
			}else{
				this.all_clear = false;
			}

			if(this.all_clear == true){
				this.message_text.fontSize = 60;
				this.message_text.text = "THANK YOU FOR PLAYING";
			}else{
				this.message_text.fontSize = 120;
				this.message_text.text = "正解";
			}
		}

		/** [Menu.Menu_Base]End
		*/
		public void End()
		{
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
				if(this.engine.mouse_fixedupdate.left.down == true){
					if(this.all_clear == true){
						this.eventcallback.Call((int)Code.Title);
					}else{
						this.eventcallback.Call((int)Code.Next);
					}
				}
			}
		}
	}
}

