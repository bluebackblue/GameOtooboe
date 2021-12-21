

/** Scene
*/
namespace Scene
{
	/** �^�C�g���B
	*/
	public sealed class Title : BlueBack.Scene.Scene_Base , Menu.EventCallBack_Base
	{
		/** menu
		*/
		private Menu.Menu_Base menu;

		/** endflag
		*/
		private bool endflag;

		/** constructor

			�풓�f�[�^�������B

		*/
		public Title()
		{
			this.menu = new Menu.Title(this);
		}

		/** [BlueBack.Scene.Scene_Base]�V�[�����B
		*/
		public string GetSceneName()
		{
			return "Title";
		}

		/** [BlueBack.Scene.Scene_Base]�O�V�[���B�I���B����B
		*/
		public void BeforeSceneEndFirst()
		{
		}

		/** [BlueBack.Scene.Scene_Base]�O�V�[���B�I���B
		*/
		public void BeforeSceneEnd()
		{
		}

		/** [BlueBack.Scene.Scene_Base]�O�V�[���B�I���B���X�g�B
		*/
		public void BeforeSceneEndLast()
		{
		}

		/** [BlueBack.Scene.Scene_Base]�J�����g�V�[���B�J�n�B����B
		*/
		public void CurrentSceneStartFirst()
		{
			this.endflag = false;
			this.menu.Start();
		}

		/** [BlueBack.Scene.Scene_Base]�J�����g�V�[���B�J�n�B

			a_is_sceneloadend	: �V�[���̓ǂݍ��݂������������ǂ����B 
			return == true		: CurrentSceneRunning�ւ̑J�ڂ����B

		*/
		public bool CurrentSceneStart(bool a_is_sceneloadend)
		{
			return true;
		}

		/** [BlueBack.Scene.Scene_Base]�J�����g�V�[���B���s�B

			return == true : CurrentSceneEndFirst�ւ̑J�ڂ����B

		*/
		public bool CurrentSceneRunning()
		{
			return this.endflag;
		}

		/** [BlueBack.Scene.Scene_Base]�J�����g�V�[���B�I���B����B
		*/
		public void CurrentSceneEndFirst()
		{
		}

		/** [BlueBack.Scene.Scene_Base]�J�����g�V�[���B�I���B

			return == true : �V�[���J�ڂ����B

		*/
		public bool CurrentSceneEnd()
		{
			this.menu.End();
			return true;
		}

		/** [BlueBack.Scene.Scene_Base]�X�V�B
		*/
		public void UnityUpdate()
		{
		}

		/** [BlueBack.Scene.Scene_Base]�X�V�B
		*/
		public void UnityLateUpdate()
		{
		}

		/** [BlueBack.Scene.Scene_Base]�X�V�B
		*/
		public void UnityFixedUpdate()
		{
			this.menu.UnityFixedUpdate();
		}

		/** [Menu.EventCallBack_Base]Call

			a_code : ���낢��B

		*/
		public void Call(int a_code)
		{
			this.endflag = true;
			this.menu.Lock();
			Execute.Engine.GetSingleton().scene.SetNextScene(Execute.Engine.GetSingleton().scene_list[(int)UnitySetting.SceneIndex.InGame]);
		}
	}
}

