using System;
using UnityEngine;

namespace Physics
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float bounceForce = 100;
        private new Rigidbody2D rigidbody2D;
        private new Transform transform;
        private Vector2 prevPos;
        

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            transform = base.transform;
        }

        private void LateUpdate()
        {
            prevPos = transform.position;
        }

        public void Shoot(Vector2 direction, float force)
        {
            rigidbody2D.AddForce(direction * force);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals("Mirror"))
            {
                var currrentDir = rigidbody2D.velocity; //((Vector2)transform.position - prevPos).normalized;
                var normal = new Vector2(0, 1);
                var mirroredDir = currrentDir - 2 * Vector2.Dot(currrentDir, normal) * normal;
                Debug.Log($"current velocity: {currrentDir}");
                Debug.Log($"Force vector: {mirroredDir}");

                //rigidbody2D.AddForce(normal * bounceForce);
                rigidbody2D.velocity = mirroredDir;
            }
        }
    }
}