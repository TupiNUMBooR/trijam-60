using UnityEngine;
using Utils.Properties.Vector;

namespace Thunder.Player
{
    public class RigidbodyVector2Movement : MonoBehaviour
    {
        public Vector2Property control;
        public int floorLayer;
        int floorMask;
        public float speed = 1;
        public Rigidbody rb;

        void Awake()
        {
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
                rb.MoveRotation(Quaternion.LookRotation(playerToMouse));
            }
        }

        void Move()
        {
            var move = new Vector3(control.Value.x, 0 , control.Value.y);
            rb.MovePosition(rb.position + Time.deltaTime * speed * move);
        }
    }
}