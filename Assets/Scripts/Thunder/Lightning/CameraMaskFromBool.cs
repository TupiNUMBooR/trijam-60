using UnityEngine;
using Utils.GameObject;
using Utils.Properties.Bool;

namespace Thunder.Lightning
{
    public class CameraMaskFromBool : Modifier<Camera>
    {
        public int dayLayer;
        public int nightLayer;
        int _defaultCameraMask;
        public BoolProperty prop;

        
        protected override void Awake()
        {
            base.Awake();
            _defaultCameraMask = target.cullingMask;
            prop.ChangeEvent += OnChange;
            OnChange();
        }

        void OnDestroy()
        {
            prop.ChangeEvent -= OnChange;
        }

        void OnChange()
        {
            target.cullingMask = _defaultCameraMask - (1 << (prop.Value ? nightLayer : dayLayer));
        }
    }
}