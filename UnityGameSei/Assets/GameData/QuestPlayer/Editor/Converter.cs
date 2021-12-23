

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

			ConvertAll(t_sheetlist_jsonitem);
		}

		/** QuestXls_Item
		*/
		public struct QuestXls_Item
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

			/** value
			*/
			public int value;
		}

		/** ConvertAll
		*/
		private static void ConvertAll(BlueBack.JsonItem.JsonItem a_sheetlist_jsonitem)
		{
			//TODO:フォルダ削除。
			{

			}

			foreach(string t_sheetname in a_sheetlist_jsonitem.GetAssociativeKeyList()){
				Convert(a_sheetlist_jsonitem,t_sheetname);
			}
		}

		/** Convert
		*/
		private static void Convert(BlueBack.JsonItem.JsonItem a_sheetlist_jsonitem,string a_sheetname)
		{
			System.Collections.Generic.List<QuestXls_Item> t_sheet = BlueBack.JsonItem.Convert.JsonItemToObject<System.Collections.Generic.List<QuestXls_Item>>(a_sheetlist_jsonitem.GetItem(a_sheetname));

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
							t_questitem.index = t_sheet[ii].index;
							t_questitem.value = t_sheet[ii].value;
							t_questitem.questtype = System.Enum.Parse<GameData.QuestPlayer.QuestType>(t_sheet[ii].param);
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

