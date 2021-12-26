

/** Game.Audio
*/
namespace Game.Audio
{
	/** Se
	*/
	public sealed class Se : System.IDisposable
	{
		/** audio_se_gameobject
		*/
		private UnityEngine.GameObject se_gameobject;

		/** audiosource_list
		*/
		private UnityEngine.AudioSource[] audiosource_list;

		/** volume
		*/
		public float volume;

		/** constructor
		*/
		public Se(UnityEngine.AudioClip[] a_audioclip_list,float a_volume)
		{
			this.se_gameobject = new UnityEngine.GameObject("audiose_se");
			UnityEngine.GameObject.DontDestroyOnLoad(this.se_gameobject);

			this.audiosource_list = new UnityEngine.AudioSource[a_audioclip_list.Length];
			for(int ii=0;ii<this.audiosource_list.Length;ii++){
				this.audiosource_list[ii] = this.se_gameobject.AddComponent<UnityEngine.AudioSource>();
				this.audiosource_list[ii].clip = a_audioclip_list[ii];
			}

			this.volume = a_volume;
		}

		/** [IDisposable.Dispose]
		*/
		public void Dispose()
		{
			for(int ii=0;ii<this.audiosource_list.Length;ii++){
				if(this.audiosource_list[ii] != null){
					this.audiosource_list[ii].Stop();
					this.audiosource_list[ii] = null;
				}
			}
			this.audiosource_list = null;

			if(this.se_gameobject != null){
				UnityEngine.GameObject.Destroy(this.se_gameobject);
				this.se_gameobject = null;
			}
		}

		/** PlayOnce
		*/
		public void PlayOnce(int a_index,float a_volume)
		{
			this.audiosource_list[a_index].PlayOneShot(this.audiosource_list[a_index].clip,this.volume * a_volume);
		}
	}
}

