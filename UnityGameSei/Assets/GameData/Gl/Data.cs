

/** GameData.Gl
*/
namespace GameData.Gl
{
	/** �f�[�^�Ǘ��B
	*/
	public static class Data
	{
		/** PATH
		*/
		private const string PATH = "Gl";

		/** s_list
		*/
		public static Item[] s_list  = new Item[]{
			new Item(){
				path = PATH,
				name = "opaque",
				type = typeof(UnityEngine.Material),
			},
			new Item(){
				path = PATH,
				name = "transparent",
				type = typeof(UnityEngine.Material),
			}
		};
	}
}
