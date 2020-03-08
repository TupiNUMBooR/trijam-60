using UnityEngine;
using Utils.GameObject;

namespace Utils.Properties.Bool
{
    [RequireComponent(typeof(BoolProperty))]
    public class BoolFromButton : Modifier<BoolProperty>
    {
        public string key;

        void Update()
        {
            if (Input.GetButtonDown(key)) target.Value = !target.Value;
        }
    }
}