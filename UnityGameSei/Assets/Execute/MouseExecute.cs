

/** Execute
*/
namespace Execute
{
	/** MouseExecute
	*/
	public sealed class MouseExecute
	{
		/** Boot
		*/
		public System.Collections.IEnumerator Boot()
		{
			BlueBack.Mouse.InitParam t_initparam = BlueBack.Mouse.InitParam.CreateDefault();
			{
				//t_initparam.rapid_time_max_first;
				//t_initparam.rapid_time_max;
			}

			BlueBack.Mouse.UIM.InitParam t_engine_initparam = BlueBack.Mouse.UIM.InitParam.CreateDefault();
			{
				t_engine_initparam.button_l = 0;
				t_engine_initparam.button_r = 1;
				t_engine_initparam.button_c = 2;
			}

			BlueBack.Mouse.UIM.Engine t_engine = new BlueBack.Mouse.UIM.Engine(in t_engine_initparam);
			Engine.GetSingleton().mouse_fixedupdate = new BlueBack.Mouse.Mouse(BlueBack.Mouse.Mode.FixedUpdate,in t_initparam,t_engine);

			yield break;
		}
	}
}

