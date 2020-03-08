using UnityEngine;
using Utils.GameObject;
using Utils.Properties.Vector;

namespace Thunder.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyVector2Movement : Modifier<Rigidbody>
    {
        public Vector2Property control;
        public int floorLayer;
        int floorMask;
        public float speed = 1;

        protected override void Awake()
        {
            base.Awake();
            floorMask = 1 << floorLayer;
        }

        void FixedUpdate()
        {
            Turn();
            Move();
        }

        void Turn()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit floorHit;
            if (Physics.Raycast(camRay, out floorHit, 100, floorMask))
            {
                Vector3 playerToMouse = floorHit.point - transform.position;
                playerToMouse.y = 0;
                target.MoveRotation(Quaternion.LookRotation(playerToMouse));
            }
        }

        void Move()
        {
            var move = new Vector3(control.Value.x, 0 , control.Value.y);
            target.MovePosition(target.position + Time.deltaTime * speed * move);
        }
    }
}