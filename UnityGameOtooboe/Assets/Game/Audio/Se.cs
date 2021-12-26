

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
		public int volume_index;
		public float[] volume_list;

		/** execute
		*/
		public Execute.AudioExecute execute;

		/** constructor
		*/
		public Se(UnityEngine.AudioClip[] a_audioclip_list,float a_volume,Execute.AudioExecute a_execute)
		{
			//execute
			this.execute = a_execute;

			this.se_gameobject = new UnityEngine.GameObject("se");
			UnityEngine.GameObject.DontDestroyOnLoad(this.se_gameobject);

			this.audiosource_list = new UnityEngine.AudioSource[a_audioclip_list.Length];
			for(int ii=0;ii<this.audiosource_list.Length;ii++){
				this.audiosource_list[ii] = this.se_gameobject.AddComponent<UnityEngine.AudioSource>();
				this.audiosource_list[ii].clip = a_audioclip_list[ii];
			}

			//volume
			this.volume = a_volume;

			//volume_index
			this.volume_index = 0;

			//volume_list
			this.volume_list = new float[]{
				0.0f,
				0.1f,
				0.2f,
				0.5f,
				1.0f,
			};
		}

		/** SetVolumeIndex
		*/
		public void SetVolumeIndex(int a_volume_index)
		{
			this.volume_index = UnityEngine.Mathf.Clamp(a_volume_index,0,this.volume_list.Length - 1);
			this.volume = this.volume_list[this.volume_index];
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

