

/** Execute
*/
namespace Execute
{
	/** GlExecute
	*/
	public sealed class GlExecute
	{
		/** Boot
		*/
		public System.Collections.IEnumerator Boot()
		{
			BlueBack.Gl.InitParam t_initparam = BlueBack.Gl.InitParam.CreateDefault();
			{
				t_initparam.spritelist_max = 1;
				t_initparam.texture_max = 64;
				t_initparam.material_max = 2;
				t_initparam.sprite_max = 2;
				t_initparam.width = UnitySetting.Config.SCREEN_W;
				t_initparam.height = UnitySetting.Config.SCREEN_H;
			}
			Engine.GetSingleton().gl = new BlueBack.Gl.Gl(in t_initparam);
			BlueBack.Gl.Gl t_gl = Engine.GetSingleton().gl;

			t_gl.materialexecutelist.list[(int)UnitySetting.MaterialIndex.Opaque] = new BlueBack.Gl.MaterialExecute_SImple(t_gl,UnityEngine.Resources.Load<UnityEngine.Material>("Gl/opaque"));
			t_gl.materialexecutelist.list[(int)UnitySetting.MaterialIndex.Transparent] = new BlueBack.Gl.MaterialExecute_SImple(t_gl,UnityEngine.Resources.Load<UnityEngine.Material>("Gl/transparent"));

			t_gl.texturelist.list[(int)UnitySetting.TextureIndex.None] = null;
			t_gl.texturelist.list[(int)UnitySetting.TextureIndex.StartButton] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("Title/startbutton");

			yield break;
		}
	}
}

