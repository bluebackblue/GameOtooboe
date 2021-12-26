

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

			Execute.Engine.GetSingleton().audio_se = new Game.Audio.Se(t_sedata_monobehaviour.audioclip_list,0.0f,this);

			Execute.Engine.GetSingleton().audio_se.SetVolumeIndex(1);

			yield break;
		}
	}
}

