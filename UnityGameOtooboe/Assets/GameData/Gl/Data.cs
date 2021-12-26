

/** GameData.Gl
*/
namespace GameData.Gl
{
	/** データ管理。
	*/
	public static class Data
	{
		/** PATH
		*/
		private const string PATH = "Gl";

		/** s_list
		*/
		public static DataItem[] s_list  = new DataItem[]{
			new DataItem(){
				path = PATH,
				name = "opaque",
				type = typeof(UnityEngine.Material),
			},
			new DataItem(){
				path = PATH,
				name = "transparent",
				type = typeof(UnityEngine.Material),
			}
		};
	}
}

