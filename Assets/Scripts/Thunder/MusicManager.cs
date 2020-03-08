using UnityEngine;
using Utils.GameObject;
using Utils.Properties.Bool;

namespace Thunder
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : Modifier<AudioSource>
    {
        public BoolProperty switcher;
        public AudioClip music1;
        public AudioClip music2;
        bool _active;

        protected override void Awake()
        {
            base.Awake();
            switcher.ChangeEvent += OnChange;
            UpdateMusic();
        }

        void OnDestroy()
        {
            switcher.ChangeEvent -= OnChange;
        }

        void OnChange()
        {
            if (_active == switcher.Value) return;
            UpdateMusic();
        }

        void UpdateMusic()
        {
            _active = switcher.Value;
            var t = target.time;
            target.clip = _active ? music1 : music2;
            target.time = t;
            target.Play();
        }
    }
}