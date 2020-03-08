using UnityEngine;
using Utils;

namespace Thunder.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        public float damage = .21f;
        public float range = 100;
        public int[] shootLayers;
        int _shootMask;
        public float delay = .3f;
        public float showLineDelay = .05f;
        float _lastAttack;
        public LineRenderer gunLine;
        public Transform from;
        Ray _shootRay;
        RaycastHit _hit;
        public AudioSource shootSound;

        void Awake()
        {
            shootLayers.ForEach((i, i1) => _shootMask += 1 << i);
        }

        void Update()
        {
            if (Input.GetButton("Fire1")) Shoot();
            if (Time.time > _lastAttack + showLineDelay) gunLine.enabled = false;
        }

        void Shoot()
        {
            if (Time.time < _lastAttack + delay) return;
            _lastAttack = Time.time;
            var pos = from.position;
            shootSound.Play();

            gunLine.enabled = true;
            gunLine.SetPosition(0, pos);

            _shootRay.origin = pos;
            _shootRay.direction = from.forward;

            
            if (Physics.Raycast(_shootRay, out _hit, range, _shootMask))
            {
                Health h = _hit.collider.GetComponent<Health>();
                gunLine.SetPosition(1, _hit.point);
                if (h == null) return;
                h.Value -= damage;
            }
            else
            {
                gunLine.SetPosition(1, _shootRay.origin + _shootRay.direction * range);
            }
        }
    }
}