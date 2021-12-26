

/** GameData.QuestPlayer.Editor
*/
namespace GameData.QuestPlayer.Editor
{
	/** Converter
	*/
	public static class Converter
	{
		/** MenuItem_Converter_Quest
		*/
		[UnityEditor.MenuItem("Converter/Quest")]
		private static void MenuItem_Converter_Quest()
		{
			byte[] t_binary = BlueBack.AssetLib.Editor.LoadBinaryWithAssetsPath.Load("GameData/QuestPlayer/Editor/Raw/convert.xls");
			BlueBack.Excel.Excel t_excel = new BlueBack.Excel.Excel(new BlueBack.Excel.EDR.Engine());
			t_excel.ReadOpen(t_binary);
			BlueBack.JsonItem.JsonItem t_sheetlist_jsonitem = BlueBack.Excel.ConvertToJson.ConvertToJson.Convert(t_excel,BlueBack.Excel.ConvertToJson.ConvertParam.CreateDefault());
			t_excel.Close();

			//TODO:フォルダ削除。
			{

			}

			ConvertQuest(t_sheetlist_jsonitem);

			ConvertList(t_sheetlist_jsonitem);
		}

		/** QuestXls_QuestItem
		*/
		public struct QuestXls_QuestItem
		{
			/** command
			*/
			public string command;

			/** param
			*/
			public string param;

			/** index
			*/
			public int index;

			/** value_int
			*/
			public int value_int;

			/** value_float
			*/
			public float value_float;

			/** value_string
			*/
			public string value_string;
		}

		/** QuestXls_ListItem
		*/
		public struct QuestXls_ListItem
		{
			/** command
			*/
			public string command;

			/** param
			*/
			public string param;
		}

		/** ConvertList
		*/
		private static void ConvertList(BlueBack.JsonItem.JsonItem a_sheetlist_jsonitem)
		{
			System.Collections.Generic.List<QuestXls_ListItem> t_sheet = BlueBack.JsonItem.Convert.JsonItemToObject<System.Collections.Generic.List<QuestXls_ListItem>>(a_sheetlist_jsonitem.GetItem("list"));

			string t_filename = null;
			System.Collections.Generic.List<string> t_filename_list = new System.Collections.Generic.List<string>();

			for(int ii=0;ii<t_sheet.Count;ii++){
				switch(t_sheet[ii].command){
				case "<filename>":
					{
						t_filename = t_sheet[ii].param;
					}break;
				case "<item>":
					{
						t_filename_list.Add(t_sheet[ii].param);
					}break;
				}
			}

			UnityEngine.GameObject t_prefab_temp = new UnityEngine.GameObject("temp");
			{
				GameData.QuestPlayer.QuestList_MonoBehaviour t_questlist_monobehaviour = t_prefab_temp.AddComponent<GameData.QuestPlayer.QuestList_MonoBehaviour>();
				t_questlist_monobehaviour.list = t_filename_list.ToArray();
			}
			BlueBack.AssetLib.Editor.SavePrefabWithAssetsPath.TrySaveAs(t_prefab_temp,"" + "GameData/QuestPlayer/Resources/QuestPlayer/" + t_filename);
			UnityEngine.GameObject.DestroyImmediate(t_prefab_temp);

			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}

		/** ConvertQuest
		*/
		private static void ConvertQuest(BlueBack.JsonItem.JsonItem a_sheetlist_jsonitem)
		{
			foreach(string t_sheetname in a_sheetlist_jsonitem.GetAssociativeKeyList()){
				if(t_sheetname.StartsWith("quest_") == true){
					ConvertQuest_Sheet(a_sheetlist_jsonitem,t_sheetname);
				}
			}
		}

		/** ConvertQuest_Sheet
		*/
		private static void ConvertQuest_Sheet(BlueBack.JsonItem.JsonItem a_sheetlist_jsonitem,string a_sheetname)
		{
			System.Collections.Generic.List<QuestXls_QuestItem> t_sheet = BlueBack.JsonItem.Convert.JsonItemToObject<System.Collections.Generic.List<QuestXls_QuestItem>>(a_sheetlist_jsonitem.GetItem(a_sheetname));

			string t_filename = null;
			System.Collections.Generic.List<GameData.QuestPlayer.QuestItem> t_data_list = new System.Collections.Generic.List<QuestItem>();

			for(int ii=0;ii<t_sheet.Count;ii++){
				switch(t_sheet[ii].command){
				case "<filename>":
					{
						t_filename = t_sheet[ii].param;
					}break;
				case "<item>":
					{
						QuestItem t_questitem;
						{
							t_questitem.value_int = t_sheet[ii].value_int;
							t_questitem.value_float = t_sheet[ii].value_float;
							t_questitem.value_string = t_sheet[ii].value_string;
							t_questitem.command = System.Enum.Parse<GameData.QuestPlayer.CommandType>(t_sheet[ii].param);
						}
						t_data_list.Add(t_questitem);
					}break;
				}
			}

			UnityEngine.GameObject t_prefab_temp = new UnityEngine.GameObject("temp");
			{
				GameData.QuestPlayer.QuestData_MonoBehaviour t_questdata_monobehaviour = t_prefab_temp.AddComponent<GameData.QuestPlayer.QuestData_MonoBehaviour>();
				t_questdata_monobehaviour.list = t_data_list.ToArray();
			}
			BlueBack.AssetLib.Editor.SavePrefabWithAssetsPath.TrySaveAs(t_prefab_temp,"" + "GameData/QuestPlayer/Resources/QuestPlayer/" + t_filename);
			UnityEngine.GameObject.DestroyImmediate(t_prefab_temp);

			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
	}
}

