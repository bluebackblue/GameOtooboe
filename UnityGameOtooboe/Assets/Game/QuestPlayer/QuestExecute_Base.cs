

/** Game.QuestPlayer
*/
namespace Game.QuestPlayer
{
	/** �N�G�X�g�Ǘ��B
	*/
	public interface QuestExecute_Base<ITEM>
	{
		/** [Game.QuestPlayer.QuestExecute_Base<ITEM>]�X�V�B
		*/
		void UnityFixedUpdate(Game.QuestPlayer.QuestPlayer<ITEM> a_questplayer,ref ITEM a_item,int a_index,bool a_first);

		/** [Game.QuestPlayer.QuestExecute_Base<ITEM>]���[�h�B
		*/
		public ITEM[] Load(int a_dataindex);

		/** [Game.QuestPlayer.QuestExecute_Base<ITEM>]�A�����[�h�B
		*/
		public void UnLoad();
	}
}

