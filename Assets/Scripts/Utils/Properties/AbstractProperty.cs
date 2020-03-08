using System;
using UnityEngine;

namespace Utils.Properties
{
    public abstract class AbstractProperty<T> : MonoBehaviour
    {
        [SerializeField] T _value;

        public T initValue;

        public virtual T Value
        {
            get => _value;
            set
            {
                var was = _value;
                _value = value;
                ChangeEvent?.Invoke();
                ChangeDiffEvent?.Invoke(was, value);
            }
        }

        public event Action ChangeEvent;
        public event Action<T, T> ChangeDiffEvent;

        void Awake()
        {
            Value = initValue;
        }
    }
}