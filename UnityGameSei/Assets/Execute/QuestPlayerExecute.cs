

/** Execute
*/
namespace Execute
{
	/** QuestPlayerExecute
	*/
	public sealed class QuestPlayerExecute : Game.QuestPlayer.QuestExecute_Base<GameData.QuestPlayer.QuestItem>
	{
		/** text_debug
		*/
		#if(UNITY_EDITOR)
		private UnityEngine.UI.Text text_debug;
		#endif

		/** waitsec
		*/
		public float waitsec;

		/** Boot
		*/
		public System.Collections.IEnumerator Boot()
		{
			Game.OnMemory t_onmemory = Game.OnMemory.GetSingleton();
			t_onmemory.questplayer = new Game.QuestPlayer.QuestPlayer<GameData.QuestPlayer.QuestItem>(this);

			yield break;
		}

		/** ロード。
		*/
		public GameData.QuestPlayer.QuestItem[] Load(int a_dataindex)
		{
			#if(UNITY_EDITOR)
			{
				this.text_debug = UnityEngine.GameObject.Find("Text_Debug").GetComponent<UnityEngine.UI.Text>();
			}
			#endif

			GameData.QuestPlayer.QuestData_MonoBehaviour t_data_monobehaviour = UnityEngine.Resources.Load<GameData.QuestPlayer.QuestData_MonoBehaviour>("QuestPlayer/Quest_" + a_dataindex.ToString("D2"));
			return t_data_monobehaviour.list;
		}

		/** 更新。
		*/
		public void UnityFixedUpdate(Game.QuestPlayer.QuestPlayer<GameData.QuestPlayer.QuestItem> a_questplayer,ref GameData.QuestPlayer.QuestItem a_item,int a_index,bool a_first)
		{
			switch(a_item.questtype){
			case GameData.QuestPlayer.QuestType.Data:
				{
					#if(UNITY_EDITOR)
					this.text_debug.text = a_index.ToString() + " : " + a_item.questtype.ToString();
					#endif
				}break;
			case GameData.QuestPlayer.QuestType.PlayMode_Start:
				{
					#if(UNITY_EDITOR)
					this.text_debug.text = a_index.ToString() + " : " + a_item.questtype.ToString();
					#endif
				}break;
			case GameData.QuestPlayer.QuestType.ViewMode_Start:
				{
					#if(UNITY_EDITOR)
					this.text_debug.text = a_index.ToString() + " : " + a_item.questtype.ToString();
					#endif
				}break;
			case GameData.QuestPlayer.QuestType.WaitSec:
				{
					if(a_first == true){
						this.waitsec = 0.0f;
					}else{
						this.waitsec += UnityEngine.Time.fixedDeltaTime;
					}

					#if(UNITY_EDITOR)
					this.text_debug.text = a_index.ToString() + " : " + a_item.questtype.ToString() + " : " + this.waitsec.ToString();
					#endif

					if(this.waitsec >= a_item.value){
						a_questplayer.SetNextIndex(a_index + 1);
					}
				}break;
			default:
				{
					#if(UNITY_EDITOR)
					this.text_debug.text = a_index.ToString() + " : " + a_item.questtype.ToString();
					#endif
				}break;
			}
		}
	}
}

