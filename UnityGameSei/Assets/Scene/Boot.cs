

/** @brief �u�[�g�B
*/


/** Scene
*/
namespace Scene
{
	/** Boot
	*/
	public sealed class Boot : BlueBack.Scene.Scene_Base
	{
		/** endflag
		*/
		public bool endflag;

		/** [BlueBack.Scene.Scene_Base]�V�[�����B
		*/
		public string GetSceneName()
		{
			return null;
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
			Boot_MonoBehaviour.s_monobehaviour.StartCoroutine(this.CoroutineMain());
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
		}

		/** CoroutineMain
		*/
		private System.Collections.IEnumerator CoroutineMain()
		{
			Execute.Engine t_engine = Execute.Engine.GetSingleton();
			UnityEngine.MonoBehaviour t_monobehaviour = Boot_MonoBehaviour.s_monobehaviour;

			//�풓�B
			Game.OnMemory.CreateSingleton();

			//�f�k�B
			t_monobehaviour.StartCoroutine(new Execute.GlExecute().Boot());

			//�}�E�X�B
			t_monobehaviour.StartCoroutine(new Execute.MouseExecute().Boot());

			//�V�[���B
			t_engine.scene_list = new BlueBack.Scene.Scene_Base[(int)UnitySetting.SceneIndex.Max];
			t_engine.scene_list[(int)UnitySetting.SceneIndex.Title] = new Scene.Title();
			t_engine.scene_list[(int)UnitySetting.SceneIndex.InGame] = new Scene.InGame();

			//�^�C�g���ցB
			t_engine.scene.SetNextScene(t_engine.scene_list[(int)UnitySetting.SceneIndex.Title]);

			this.endflag = true;
			yield break;
		}
	}
}

