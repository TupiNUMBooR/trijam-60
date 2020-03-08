using System;
using UnityEngine;
using Utils.GameObject;

namespace Utils.Properties.Float
{
    [RequireComponent(typeof(FloatProperty))]
    public class FloatWithPlayerPrefs : Modifier<FloatProperty>
    {
        public string key;

        float Value
        {
            get => PlayerPrefs.HasKey(key) ? PlayerPrefs.GetFloat(key) : target.initValue;
            set
            {
                if (Math.Abs(value - target.initValue) < float.Epsilon)
                    PlayerPrefs.DeleteKey(key);
                else
                    PlayerPrefs.SetFloat(key, value);
            }
        }

        protected override void Awake()
        {
            base.Awake();
            target.Value = Value;
            target.ChangeEvent += OnChange;
        }

        void OnDestroy()
        {
            target.ChangeEvent -= OnChange;
        }

        void OnChange()
        {
            Value = target.Value;
        }
    }
}