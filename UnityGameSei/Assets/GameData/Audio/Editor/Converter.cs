

/** GameData.Audio.Editor
*/
namespace GameData.Audio.Editor
{
	/** Converter
	*/
	public static class Converter
	{
		/** MenuItem_Converter_Audio_Se
		*/
		[UnityEditor.MenuItem("Converter/Audio/Se")]
		private static void MenuItem_Converter_Audio_Se()
		{
			System.Collections.Generic.List<UnityEngine.AudioClip> t_audioclip_list = new System.Collections.Generic.List<UnityEngine.AudioClip>();

			System.Collections.Generic.List<string> t_filename_list = BlueBack.AssetLib.Editor.FindFileWithAssetsPath.FindAll("GameData/Audio/Editor/SoundEffectLab","^.*$","^.*\\.mp3$");
			foreach(string t_filename in t_filename_list){
				UnityEngine.AudioClip t_audioclip = BlueBack.AssetLib.Editor.LoadAssetWithAssetsPath.Load<UnityEngine.AudioClip>(t_filename);
				if(t_audioclip != null){
					UnityEngine.Debug.Log(t_audioclip.name);
					t_audioclip_list.Add(t_audioclip);
				}
			}

			UnityEngine.GameObject t_prefab_temp = new UnityEngine.GameObject("temp");
			{
				GameData.Audio.SeData_MonoBehaviour t_sedata_monobehaviour = t_prefab_temp.AddComponent<GameData.Audio.SeData_MonoBehaviour>();
				t_sedata_monobehaviour.audioclip_list = t_audioclip_list.ToArray();
			}
			BlueBack.AssetLib.Editor.SavePrefabWithAssetsPath.TrySaveAs(t_prefab_temp,"" + "GameData/Audio/Resources/Audio/Se.prefab");
			UnityEngine.GameObject.DestroyImmediate(t_prefab_temp);

			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
	}
}

