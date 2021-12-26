

/** Game.Fade
*/
namespace Game.Fade
{
	/** Fade
	*/
	public sealed class Fade_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** fade
		*/
		public Fade fade;

		/** visible
		*/
		public bool visible;

		/** Awake
		*/
		public void Awake()
		{
			this.visible = false;
		}

		/** Update
		*/
		public void Update()
		{
			this.fade.UnityUpdate();
		}
	}
}
