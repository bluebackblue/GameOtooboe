

/** Game.QuestPlayer
*/
namespace Game.QuestPlayer
{
	/** クエスト管理。
	*/
	public interface QuestExecute_Base<ITEM>
	{
		/** [Game.QuestPlayer.QuestExecute_Base<ITEM>]更新。
		*/
		void UnityFixedUpdate(Game.QuestPlayer.QuestPlayer<ITEM> a_questplayer,ref ITEM a_item,int a_index,bool a_first);

		/** [Game.QuestPlayer.QuestExecute_Base<ITEM>]ロード。
		*/
		public ITEM[] Load(int a_dataindex);

		/** [Game.QuestPlayer.QuestExecute_Base<ITEM>]アンロード。
		*/
		public void UnLoad();
	}
}

