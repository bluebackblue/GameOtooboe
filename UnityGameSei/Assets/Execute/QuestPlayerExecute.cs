

/** Execute
*/
namespace Execute
{
	/** QuestPlayerExecute
	*/
	public sealed class QuestPlayerExecute : Game.QuestPlayer.QuestExecute_Base<GameData.QuestPlayer.QuestItem>
	{
		/** debug
		*/
		#if(UNITY_EDITOR)
		private UnityEngine.UI.Text debug_text;
		#endif

		/** message
		*/
		private UnityEngine.UI.Text message_text;
		private UnityEngine.RectTransform message_recttransform;

		/** countdown
		*/
		private UnityEngine.UI.Text countdown_text;
		private UnityEngine.RectTransform countdown_recttransform;

		/** temp_sec
		*/
		public float temp_sec;

		/** onmemory
		*/
		private Game.OnMemory onmemory;

		/** constructor
		*/
		public QuestPlayerExecute()
		{
			this.onmemory = Game.OnMemory.GetSingleton();
		}

		/** Boot
		*/
		public System.Collections.IEnumerator Boot()
		{
			this.onmemory.questplayer = new Game.QuestPlayer.QuestPlayer<GameData.QuestPlayer.QuestItem>(this);
			yield break;
		}

		/** [Game.QuestPlayer.QuestExecute_Base<ITEM>]ロード。
		*/
		public GameData.QuestPlayer.QuestItem[] Load(int a_dataindex)
		{
			//debug_text
			#if(UNITY_EDITOR)
			this.debug_text = UnityEngine.GameObject.Find("Debug_Text").GetComponent<UnityEngine.UI.Text>();
			#endif

			//message
			this.message_text = UnityEngine.GameObject.Find("Message_Text").GetComponent<UnityEngine.UI.Text>();
			this.message_recttransform = this.message_text.gameObject.GetComponent<UnityEngine.RectTransform>();
			this.message_text.gameObject.SetActive(false);

			//countdown
			this.countdown_text = UnityEngine.GameObject.Find("CountDown_Text").GetComponent<UnityEngine.UI.Text>();
			this.countdown_recttransform = this.countdown_text.gameObject.GetComponent<UnityEngine.RectTransform>();
			this.countdown_text.gameObject.SetActive(false);

			string t_path = "QuestPlayer/Quest_" + a_dataindex.ToString("D2");
			#if(UNITY_EDITOR)
			UnityEngine.Debug.Log(t_path);
			#endif

			GameData.QuestPlayer.QuestData_MonoBehaviour t_data_monobehaviour = UnityEngine.Resources.Load<GameData.QuestPlayer.QuestData_MonoBehaviour>(t_path);

			//解析。
			GameData.QuestPlayer.QuestItem[] t_list = t_data_monobehaviour.list;
			{
				//enemy_waittime
				this.onmemory.enemy_waittime = 30;

				//enemy_list
				this.onmemory.enemy_list.Clear();
				for(int ii=0;ii<t_list.Length;ii++){
					switch(t_list[ii].command){
					case GameData.QuestPlayer.CommandType.Data:
						{
							this.onmemory.enemy_list.Add(new Game.Enemy.Enemy(ii,this.onmemory.enemy_list.Count,t_list[ii].value_int));
						}break;
					}
				}
			}

			//phasetype
			this.onmemory.param.phasetype = Game.Param.PhaseType.None;

			//gametime
			this.onmemory.param.gametime = 0;

			//speed
			this.onmemory.param.movespeed = 5.0f;



			return t_list;
		}


		/** [Game.QuestPlayer.QuestExecute_Base<ITEM>]アンロード。
		*/
		public void UnLoad()
		{
			foreach(Game.Enemy.Enemy t_enemly in this.onmemory.enemy_list){
				t_enemly.Dispose();
			}
		}

		/** [Game.QuestPlayer.QuestExecute_Base<ITEM>]更新。
		*/
		public void UnityFixedUpdate(Game.QuestPlayer.QuestPlayer<GameData.QuestPlayer.QuestItem> a_questplayer,ref GameData.QuestPlayer.QuestItem a_item,int a_index,bool a_first)
		{
			#if(UNITY_EDITOR)
			string t_debugtext_prefix = a_index.ToString() + " : " + a_item.command.ToString();
			#endif

			switch(a_item.command){
			case GameData.QuestPlayer.CommandType.Data:
				{
					#if(UNITY_EDITOR)
					this.debug_text.text = t_debugtext_prefix;
					#endif
				}break;
			case GameData.QuestPlayer.CommandType.ViewMode:
				{
					//観覧モード。

					#if(UNITY_EDITOR)
					this.debug_text.text = t_debugtext_prefix + " : " + this.onmemory.param.gametime.ToString();
					#endif

					if(a_first == true){
						this.onmemory.param.phasetype = Game.Param.PhaseType.View;
						this.onmemory.param.gametime = 0;

						foreach(Game.Enemy.Enemy t_enemy in this.onmemory.enemy_list){
							t_enemy.Reset();
						}
					}else{
						this.onmemory.param.gametime++;

						//終了待ち。
						bool t_fix = true;
						foreach(Game.Enemy.Enemy t_enemy in this.onmemory.enemy_list){
							if(t_enemy.mode != Game.Enemy.Enemy.Mode.Out){
								t_fix = false;
							}
						}
						if(t_fix == true){
							a_questplayer.SetNextIndex(a_index + 1);
							return;
						}
					}
				}break;
			case GameData.QuestPlayer.CommandType.PlayMode:
				{
					//プレイモード。

					#if(UNITY_EDITOR)
					this.debug_text.text = t_debugtext_prefix + " : " + this.onmemory.param.gametime.ToString();
					#endif

					if(a_first == true){
						this.onmemory.param.phasetype = Game.Param.PhaseType.Play;
						this.onmemory.param.gametime = 0;

						foreach(Game.Enemy.Enemy t_enemy in this.onmemory.enemy_list){
							t_enemy.Reset();
						}
					}else{
						this.onmemory.param.gametime++;

						//終了待ち。
						bool t_fix = true;
						foreach(Game.Enemy.Enemy t_enemy in this.onmemory.enemy_list){
							if(t_enemy.mode != Game.Enemy.Enemy.Mode.Out){
								t_fix = false;
							}
						}
						if(t_fix == true){
							a_questplayer.SetNextIndex(a_index + 1);
							return;
						}
					}
				}break;
			case GameData.QuestPlayer.CommandType.WaitSec:
				{
					if(a_first == true){
						this.temp_sec = 0.0f;
					}else{
						this.temp_sec += UnityEngine.Time.fixedDeltaTime;
					}

					#if(UNITY_EDITOR)
					this.debug_text.text = a_index.ToString() + " : " + a_item.command.ToString() + " : " + this.temp_sec.ToString();
					#endif

					if(this.temp_sec >= a_item.value_int){
						a_questplayer.SetNextIndex(a_index + 1);
						return;
					}
				}break;
			case GameData.QuestPlayer.CommandType.CountDown:
				{
					if(a_first == true){
						this.temp_sec = a_item.value_int - 0.001f;
						this.countdown_text.text = a_item.value_string;
						this.countdown_text.gameObject.SetActive(true);
					}else{
						this.temp_sec = UnityEngine.Mathf.Max(0,this.temp_sec - UnityEngine.Time.fixedDeltaTime);

					}
					
					#if(UNITY_EDITOR)
					this.debug_text.text = a_index.ToString() + " : " + a_item.command.ToString() + " : " + this.temp_sec.ToString();
					#endif

					//TODO:ここに直書き。

					int t_x = UnitySetting.Config.SCREEN_W / 2;
					int t_y = UnitySetting.Config.SCREEN_H / 2;
					this.countdown_recttransform.localPosition = new UnityEngine.Vector3(t_x - UnitySetting.Config.SCREEN_W / 2,UnitySetting.Config.SCREEN_H / 2 - t_y,0);

					this.countdown_text.text = (1 + (int)this.temp_sec).ToString();

					if(this.temp_sec <= 0.0f){
						this.countdown_text.gameObject.SetActive(false);
						a_questplayer.SetNextIndex(a_index + 1);
						return;
					}
				}break;
			case GameData.QuestPlayer.CommandType.Message:
				{
					if(a_first == true){
						this.temp_sec = 0.0f;
						this.message_text.text = a_item.value_string;
						this.message_text.gameObject.SetActive(true);
					}else{
						this.temp_sec += UnityEngine.Time.fixedDeltaTime;
					}
					
					#if(UNITY_EDITOR)
					this.debug_text.text = a_index.ToString() + " : " + a_item.command.ToString() + " : " + this.temp_sec.ToString();
					#endif

					//TODO:ここに直書き。

					int t_x_offset = 222;
					int t_x;
					int t_y = (int)(UnitySetting.Config.SCREEN_H * 0.6f);

					float t_section_max = 2.0f;
					float t_section = t_section_max / 5;

					if(this.temp_sec <= t_section * 1){
						//0
						float t_time = UnityEngine.Mathf.Clamp01(this.temp_sec / (t_section * 1));
						t_x = (int)UnityEngine.Mathf.Lerp(UnitySetting.Config.SCREEN_W + t_x_offset,UnitySetting.Config.SCREEN_W / 2,t_time * t_time);
					}else if(this.temp_sec <= t_section * 4){
						//1 2 3
						t_x = UnitySetting.Config.SCREEN_W / 2;
					}else{
						//4
						float t_time = UnityEngine.Mathf.Clamp01((this.temp_sec - (t_section * 4)) / t_section);
						t_x = (int)UnityEngine.Mathf.Lerp(UnitySetting.Config.SCREEN_W / 2,0 - t_x_offset,t_time * t_time);
					}
					
					this.message_recttransform.localPosition = new UnityEngine.Vector3(t_x - UnitySetting.Config.SCREEN_W / 2,UnitySetting.Config.SCREEN_H / 2 - t_y,0);
					if(this.temp_sec >= t_section_max){
						this.message_text.gameObject.SetActive(false);
						a_questplayer.SetNextIndex(a_index + 1);
						return;
					}
				}break;
			case GameData.QuestPlayer.CommandType.Result:
				{
					//リザルトへ。

					#if(UNITY_EDITOR)
					this.debug_text.text = t_debugtext_prefix + " : " + this.onmemory.param.gametime.ToString();
					#endif

					//TODO:失敗した場合。
					a_questplayer.SetResult(Game.QuestPlayer.QuestResult.Success);
				}break;
			default:
				{
					#if(UNITY_EDITOR)
					this.debug_text.text = t_debugtext_prefix;
					#endif
				}break;
			}
		}
	}
}

