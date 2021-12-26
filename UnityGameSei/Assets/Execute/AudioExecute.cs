

/** Execute
*/
namespace Execute
{
	/** AudioExecute
	*/
	public sealed class AudioExecute
	{
		/** Boot
		*/
		public System.Collections.IEnumerator Boot()
		{
			UnityEngine.GameObject t_audiolistener_gameobject = new UnityEngine.GameObject("audiolistener");
			Execute.Engine.GetSingleton().audio_listener = t_audiolistener_gameobject.AddComponent<UnityEngine.AudioListener>();
			UnityEngine.GameObject.DontDestroyOnLoad(t_audiolistener_gameobject);

			GameData.Audio.SeData_MonoBehaviour t_sedata_monobehaviour = UnityEngine.Resources.Load<GameData.Audio.SeData_MonoBehaviour>("Audio/Se");

			Execute.Engine.GetSingleton().audio_se = new Game.Audio.Se(t_sedata_monobehaviour.audioclip_list,0.0f);

			SetSeVolume(1);

			yield break;
		}

		/** SetSeVolume
		*/
		public static void SetSeVolume(int a_volume)
		{
			int t_volume = UnityEngine.Mathf.Clamp(a_volume,0,4);

			Execute.Engine.GetSingleton().audio_se_volume = t_volume;
			switch(t_volume){
			case 0:
				{
					Execute.Engine.GetSingleton().audio_se.volume = 0.0f;
				}break;
			case 1:
				{
					Execute.Engine.GetSingleton().audio_se.volume = 0.2f;
				}break;
			case 2:
				{
					Execute.Engine.GetSingleton().audio_se.volume = 0.4f;
				}break;
			case 3:
				{
					Execute.Engine.GetSingleton().audio_se.volume = 0.7f;
				}break;
			case 4:
				{
					Execute.Engine.GetSingleton().audio_se.volume = 1.0f;
				}break;
			default:
				{
					#if(UNITY_EDITOR)
					UnityEngine.Debug.Assert(false);
					#endif
				}break;
			}
		}
	}
}

