

/** Game.QuestPlayer
*/
namespace Game.QuestPlayer
{
	/** �N�G�X�g�Ǘ��B
	*/
	public interface QuestExecute_Base<ITEM>
	{
		/** �X�V�B
		*/
		void UnityFixedUpdate(Game.QuestPlayer.QuestPlayer<ITEM> a_questplayer,ref ITEM a_item,int a_index,bool a_first);

		/** ���[�h�B
		*/
		public ITEM[] Load(int a_dataindex);
	}
}

