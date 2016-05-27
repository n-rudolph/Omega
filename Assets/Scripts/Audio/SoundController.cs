using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {

    [SerializeField]
    private Dictionary<SoundEnum, AudioClip> soundEffects;
    [SerializeField]
    private Dictionary<SoundEnum, AudioClip> backgroundSounds;

    private AudioSource audioSource;
    
    // Use this for initialization
    public void Start () {
        audioSource = GetComponent<AudioSource>();
        soundEffects = new Dictionary<SoundEnum, AudioClip>();
        backgroundSounds = new Dictionary<SoundEnum, AudioClip>();
        AudioClip background = Resources.Load("Audio/Background", typeof(AudioClip)) as AudioClip;
		AudioClip shoot = Resources.Load("Audio/Shoot", typeof(AudioClip)) as AudioClip;
		AudioClip hit = Resources.Load("Audio/Hit", typeof(AudioClip)) as AudioClip;
		AudioClip powerUp = Resources.Load("Audio/PowerUp", typeof(AudioClip)) as AudioClip;
		AudioClip shield = Resources.Load("Audio/Shield", typeof(AudioClip)) as AudioClip;
		AudioClip gameOver = Resources.Load("Audio/GameOver", typeof(AudioClip)) as AudioClip;
		AudioClip victory = Resources.Load("Audio/Victory", typeof(AudioClip)) as AudioClip;
        
		soundEffects.Add(SoundEnum.SHOOT, shoot);
		soundEffects.Add(SoundEnum.HIT, hit);
		soundEffects.Add(SoundEnum.POWERUP, powerUp);
		soundEffects.Add(SoundEnum.SHIELD, shield);

		soundEffects.Add(SoundEnum.BACKGROUND, background);
		backgroundSounds.Add(SoundEnum.GAMEOVER, gameOver);
		backgroundSounds.Add(SoundEnum.VICTORY, victory);

		PlaySoundEffect(SoundEnum.BACKGROUND);
    }



    public void PlaySoundEffect(SoundEnum key)
    {
        AudioClip temp;
        if (soundEffects.TryGetValue(key, out temp)) {
            audioSource.PlayOneShot(temp, 1.0f);
        }
    }

    public void PlayBackgroundSound(SoundEnum key)
    {
        AudioClip temp;
        if (backgroundSounds.TryGetValue(key, out temp))
        {
            audioSource.PlayOneShot(temp, 1.0f);
        }
    }
}
