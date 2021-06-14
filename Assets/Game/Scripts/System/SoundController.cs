using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam.System
{

    public class SoundController : Singleton<SoundController>
    {
        [SerializeField] AudioClip[] chainSounds;
        [SerializeField] AudioSource chainSound;
        [SerializeField] AudioSource coinSound;

        public void PlayChainSound()
        {
            if (!chainSound.isPlaying)
                // chainSound.Play();
                chainSound.PlayOneShot(chainSounds[Random.Range(0,chainSounds.Length)]);

        }

        public void PlayCoinSound()
        {
            coinSound.Play();
        }
    }
}
