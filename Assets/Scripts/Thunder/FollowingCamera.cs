using UnityEngine;
using Utils.GameObject;

namespace Thunder
{
    public class FollowingCamera : Modifier<Camera>
    {
        public Transform followed;
        Vector3 _initPosition;

        protected override void Awake()
        {
            base.Awake();
            _initPosition = transform.position - followed.position;
        }

        void Update()
        {
            var p = _initPosition + followed.position;
            transform.position = Vector3.Lerp(transform.position, p, .25f);
        }
    }
}