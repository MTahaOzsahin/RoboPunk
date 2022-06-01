using Kajujam.Concrates.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kajujam.Concrates.Observers
{
    public class SoundObserver : MonoBehaviour
    {
        public static SoundObserver Instance { get; private set; }

        AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            PlayerController.OnBulletFire += PlaySoundOneShot;
            PlayerController.OnPlayerDead += PlaySoundOneShot;
            EnemyController.OnEnemyDeadSound += PlaySoundOneShot;
        }
        private void OnDisable()
        {
            PlayerController.OnBulletFire -= PlaySoundOneShot;
            PlayerController.OnPlayerDead -= PlaySoundOneShot;
            EnemyController.OnEnemyDeadSound -= PlaySoundOneShot;
        }
        void PlaySoundOneShot(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
