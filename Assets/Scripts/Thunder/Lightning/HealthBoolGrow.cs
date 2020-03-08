using UnityEngine;
using Utils.Properties.Bool;

namespace Thunder.Lightning
{
    public class HealthBoolGrow : MonoBehaviour
    {
        public Health health;
        public BoolProperty prop;
        public float multiplier = 1.1f;
        
        void Awake()
        {
            prop.ChangeEvent += OnChange;
        }

        void OnDestroy()
        {
            prop.ChangeEvent -= OnChange;
        }

        void OnChange()
        {
            health.range.y *= multiplier;
        }
    }
}