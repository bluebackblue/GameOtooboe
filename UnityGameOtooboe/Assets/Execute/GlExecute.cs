

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
			Engine.GetSingleton().gl_screenparam = BlueBack.Gl.ScreenTool.CreateScreenParamWidthStretch(UnitySetting.Config.SCREEN_W,UnitySetting.Config.SCREEN_H,UnityEngine.Screen.width,UnityEngine.Screen.height);

			BlueBack.Gl.InitParam t_initparam = BlueBack.Gl.InitParam.CreateDefault();
			{
				t_initparam.spritelist_max = 3;
				t_initparam.texture_max = 64;
				t_initparam.material_max = 8;
				t_initparam.sprite_max = 256;
			}
			Engine.GetSingleton().gl = new BlueBack.Gl.Gl(in t_initparam);
			BlueBack.Gl.Gl t_gl = Engine.GetSingleton().gl;

			//materialexecutelist
			t_gl.materialexecutelist.list[(int)UnitySetting.MaterialIndex.Opaque] = new BlueBack.Gl.MaterialExecute_SImple(t_gl,UnityEngine.Resources.Load<UnityEngine.Material>("Gl/opaque"));
			t_gl.materialexecutelist.list[(int)UnitySetting.MaterialIndex.Transparent] = new BlueBack.Gl.MaterialExecute_SImple(t_gl,UnityEngine.Resources.Load<UnityEngine.Material>("Gl/transparent"));
			t_gl.materialexecutelist.list[(int)UnitySetting.MaterialIndex.Additive] = new BlueBack.Gl.MaterialExecute_SImple(t_gl,UnityEngine.Resources.Load<UnityEngine.Material>("Gl/additive"));
			t_gl.materialexecutelist.list[(int)UnitySetting.MaterialIndex.Frame] = new BlueBack.Gl.MaterialExecute_SImple(t_gl,UnityEngine.Resources.Load<UnityEngine.Material>("Gl/frame"));

			//texturelist
			t_gl.texturelist.list[(int)UnitySetting.TextureIndex.None] = UnityEngine.Texture2D.whiteTexture;
			t_gl.texturelist.list[(int)UnitySetting.TextureIndex.Title_StartButton] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("Title/startbutton");
			t_gl.texturelist.list[(int)UnitySetting.TextureIndex.InGame_Icon_Sei] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("InGame/sei");
			t_gl.texturelist.list[(int)UnitySetting.TextureIndex.InGame_Icon_Hu] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("InGame/hu");

			//TODO:
			UnityEngine.GameObject.Find("gl").GetComponent<UnityEngine.Camera>().depth = 1.0f;
			UnityEngine.GameObject.Find("gl").GetComponent<UnityEngine.Camera>().clearFlags = UnityEngine.CameraClearFlags.Nothing;

			yield break;
		}
	}
}

