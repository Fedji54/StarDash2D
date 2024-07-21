using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace WinterUniverse
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] private AudioSource _ambientSource;
        [SerializeField] private AudioSource _SFXSource;
        [SerializeField] private List<SoundParam> _params = new();

        public AudioSource AmbientSource => _ambientSource;

        public void PlaySound(SoundType type)
        {
            foreach (SoundParam param in _params)
            {
                if (param.Type == type)
                {
                    _SFXSource.outputAudioMixerGroup = param.MixerGroup;
                    _SFXSource.pitch = param.Pitch;
                    _SFXSource.PlayOneShot(param.Clip);
                    break;
                }
            }
        }
    }

    public enum SoundType
    {
        StartGame,
        PickUp,
        Hit,
        Death,
        GameOver
    }

    [System.Serializable]
    public class SoundParam
    {
        [SerializeField] private SoundType _type;
        [SerializeField] private AudioMixerGroup _mixerGroup;
        [SerializeField] private float _minPitch = 0.5f;
        [SerializeField] private float _maxnPitch = 1.5f;
        [SerializeField] private List<AudioClip> _clips = new();

        public SoundType Type => _type;
        public AudioMixerGroup MixerGroup => _mixerGroup;
        public float Pitch => Random.Range(_minPitch, _maxnPitch);
        public AudioClip Clip => _clips[Random.Range(0, _clips.Count)];
    }
}