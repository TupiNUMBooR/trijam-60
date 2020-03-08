using UnityEngine;
using UnityEngine.UI;
using Utils.GameObject;
using Utils.Properties.Float;

namespace Utils.Properties.UI
{
    [ExecuteInEditMode]
    public class TextFromFloat : Modifier<Text>
    {
        public FloatProperty floatProperty;
        public string format = "{0}";

        void Start()
        {
            floatProperty.ChangeEvent += OnChange;
            OnChange();
        }

        void OnDestroy()
        {
            floatProperty.ChangeEvent -= OnChange;
        }

        void OnChange()
        {
            target.text = string.Format(format, floatProperty.Value);
        }
    }
}