

/** Game.QuestPlayer
*/
namespace Game.QuestPlayer
{
	/** クエスト管理。
	*/
	public sealed class QuestPlayer<ITEM> : System.IDisposable
	{
		/** list
		*/
		public ITEM[] list;

		/** index
		*/
		public int index;

		/** first
		*/
		public bool first;
		public bool first_next;

		/** execute
		*/
		public QuestExecute_Base<ITEM> execute;

		/** result
		*/
		public QuestResult result;

		/** constructor
		*/
		public QuestPlayer(QuestExecute_Base<ITEM> a_execute)
		{
			this.execute = a_execute;
			this.result = QuestResult.None;
		}

		/** [System.IDisposable]破棄。
		*/
		public void Dispose()
		{
		}

		/** Load
		*/
		public void Load(int a_dataindex)
		{
			this.list = this.execute.Load(a_dataindex);
			this.index = 0;
			this.first = true;
			this.result = QuestResult.Do;
		}

		/** UnLoad
		*/
		public void UnLoad()
		{
			this.execute.UnLoad();
			this.list = null;
		}

		/** SetNextIndex
		*/
		public void SetNextIndex(int a_index)
		{
			this.index = a_index;
			this.first = true;
			this.first_next = true;
		}

		/** SetResult
		*/
		public void SetResult(QuestResult a_result)
		{
			this.result = a_result;
		}

		/** 更新。
		*/
		public void UnityFixedUpdate()
		{
			if(this.list != null){
				if(this.index < this.list.Length){
					this.first_next = false;
					this.execute.UnityFixedUpdate(this,ref this.list[this.index],this.index,this.first);
					this.first = this.first_next;
				}
			}
		}
	}
}

