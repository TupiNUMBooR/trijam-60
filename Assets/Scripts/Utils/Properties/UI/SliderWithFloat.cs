using UnityEngine;
using UnityEngine.UI;
using Utils.GameObject;
using Utils.Properties.Float;

namespace Utils.Properties.UI
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Slider))]
    public class SliderWithFloat : Modifier<Slider>
    {
        public FloatProperty property;
        public bool control;

        protected override void Awake()
        {
            base.Awake();
            if (control) target.onValueChanged.AddListener(OnSlider);
            property.ChangeEvent += OnProperty;
            OnProperty();
        }

        void OnDestroy()
        {
            target.onValueChanged.RemoveListener(OnSlider);
            property.ChangeEvent -= OnProperty;
        }

        void OnSlider(float v)
        {
            if (!control) return;
            property.Value = v;
        }

        void OnProperty()
        {
            target.value = property.Value;
        }
    }
}