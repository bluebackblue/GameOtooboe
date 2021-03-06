

/** Execute
*/
namespace Execute
{
	/** エンジン関連。
	*/
	public sealed class Engine
	{
		/** [singleton]s_instance
		*/
		private static Engine s_instance = null;

		/** [singleton]作成。
		*/
		public static Engine CreateSingleton()
		{
			#if(UNITY_EDITOR)
			UnityEngine.Debug.Assert(s_instance == null);
			#endif

			s_instance = new Engine();
			return s_instance;
		}

		/** [singleton]取得。
		*/
		public static Engine GetSingleton()
		{
			return s_instance;
		}

		/** [singleton]削除。
		*/
		public static void DeleteSingleton()
		{
			s_instance.Dispose();
			s_instance = null;
		}

		/** font
		*/
		public UnityEngine.Font font;

		/** append_list
		*/
		public System.Collections.Generic.List<AppEnd_Bases> append_list;

		/** シーン管理。
		*/
		public BlueBack.Scene.Scene scene;
		public BlueBack.Scene.Scene_Base[] scene_list;

		/** gl
		*/
		public BlueBack.Gl.Gl gl;
		public BlueBack.Gl.ScreenParam gl_screenparam;

		/** mouse_fixedupdate
		*/
		public BlueBack.Mouse.Mouse mouse_fixedupdate;

		/** audio_se
		*/
		public UnityEngine.AudioListener audio_listener;
		public Game.Audio.Se audio_se;

		/** fade
		*/
		public Game.Fade.Fade fade;

		/** [singleton]constructor
		*/
		private Engine()
		{
			//append_list
			this.append_list = null;

			//scene
			this.scene = null;
			this.scene_list = null;

			//gl
			this.gl = null;

			//mouse_fixedupdate
			this.mouse_fixedupdate = null;

			//audio
			this.audio_se = null;
			this.audio_listener = null;

			//fade
			this.fade = null;
		}

		/** [singleton]破棄。
		*/
		private void Dispose()
		{
			foreach(AppEnd_Bases t_append in this.append_list){
				t_append.OnAppEnd();
			}
			this.append_list = null;

			if(this.scene != null){
				this.scene.Dispose();
				this.scene = null;
			}

			if(this.scene_list != null){
				foreach(BlueBack.Scene.Scene_Base t_scene in this.scene_list){
					//TODO:t_scene.Dispose();
				}
				this.scene_list = null;
			}

			if(this.gl != null){
				this.gl.Dispose();
				this.gl = null;
			}

			if(this.mouse_fixedupdate != null){
				this.mouse_fixedupdate.Dispose();
				this.mouse_fixedupdate = null;
			}

			if(this.audio_se != null){
				this.audio_se.Dispose();
				this.audio_se = null;
			}

			if(this.fade != null){
				this.fade.Dispose();
				this.fade = null;
			}
		}
	}
}

