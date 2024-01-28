using UnityEngine;
using FMODUnity;
using System.Threading.Tasks;
using FMOD.Studio;
using FMOD;
using System.Collections.Generic;

public class AudioSystem : Singleton<AudioSystem>
{
	private List<EventInstance> instances = new List<EventInstance>();

	protected override void Awake()
	{
		base.Awake();
	}

	public void PlayOneShot(string sfx) => RuntimeManager.PlayOneShot(sfx);
	public void PlayOneShot(string sfx, Vector3 pos) => RuntimeManager.PlayOneShot(sfx, pos);

	public async void PlayOneShotDelayed(string sfx, float delay = 0f)
	{
		await Task.Delay((int)(delay * 1000));
		RuntimeManager.PlayOneShot(sfx);
	}

	public EventInstance CreateInstance(string sfx)
	{
		var instance = RuntimeManager.CreateInstance(sfx);
		instances.Add(instance);
		return instance;
	}

	private void CleanUp()
	{
		foreach (var instance in instances)
		{
			instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			instance.release();
		}
	}

	private void OnDestroy()
	{
		CleanUp();
	}
}
