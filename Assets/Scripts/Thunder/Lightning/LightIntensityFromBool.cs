using UnityEngine;
using Utils.GameObject;
using Utils.Properties.Bool;

namespace Thunder.Lightning
{
    public class LightIntensityFromBool : Modifier<Light>
    {
        public float trueIntensity = 0.7f;
        public float falseIntensity = 0.1f;
        public BoolProperty prop;

        
        protected override void Awake()
        {
            base.Awake();
            prop.ChangeEvent += OnChange;
            OnChange();
        }

        void OnDestroy()
        {
            prop.ChangeEvent -= OnChange;
        }

        void OnChange()
        {
            target.intensity = prop.Value ? trueIntensity : falseIntensity;
        }
    }
}