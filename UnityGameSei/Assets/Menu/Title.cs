

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

			this.message_text = UnityEngine.GameObject.Find("Text_Message").GetComponent<UnityEngine.UI.Text>();
			this.message_text.text = "Click";
			this.message_text.enabled = true;
		}

		/** [Menu.Menu_Base]End
		*/
		public void End()
		{
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
				if(new UnityEngine.Vector2(this.engine.mouse_fixedupdate.cursor.pos.x - 0.5f,this.engine.mouse_fixedupdate.cursor.pos.y - 0.5f).magnitude <= 0.1f){
					this.message_text.color = new UnityEngine.Color(1.0f,0.0f,0.0f,1.0f);
					if(this.engine.mouse_fixedupdate.left.down == true){
						this.eventcallback.Call((int)Code.InGame);
					}
				}else{
					this.message_text.color = new UnityEngine.Color(1.0f,1.0f,1.0f,1.0f);
				}
			}
		}
	}
}

