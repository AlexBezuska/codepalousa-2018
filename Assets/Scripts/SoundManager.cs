using UnityEngine;

public class SoundManager {

	private static readonly SoundManager instance = new SoundManager();
	private AudioSource audioSource;

	private SoundManager() {
		var gameObject = new GameObject("SoundManager");
		Object.DontDestroyOnLoad(gameObject);
		audioSource = gameObject.AddComponent<AudioSource>();
	}

	public static SoundManager Instance {
		get {
			return instance;
		}
	}

	public void Play(AudioClip[] sounds, float volume = 1f) {
		if (sounds == null || sounds.Length == 0) {
			return;
		}
		int random = Random.Range(0, sounds.Length);
		audioSource.PlayOneShot(sounds[random], volume);
	}
}
