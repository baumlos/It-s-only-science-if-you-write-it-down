using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Physics
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        
        [SerializeField] float maxSpeed;
        //[SerializeField] private float bounceForce = 100;
        private new Rigidbody2D rigidbody2D;
        private new Transform transform;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            transform = base.transform;
        }

        public void Shoot(Vector2 direction, float force)
        {
            rigidbody2D.AddForce(direction * force);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals("Mirror"))
            {
                var currentDir = rigidbody2D.velocity;
                var normal = (Vector2) other.GetComponent<Transform>().up;

                var mirroredDir = currentDir - 2 * Vector2.Dot(currentDir, normal) * normal;
                rigidbody2D.velocity = mirroredDir;
            }
            else if (other.tag.Equals("MirrorEdge"))
            {
                var currentDir = rigidbody2D.velocity;
                var edgeCollider = other.GetComponent<EdgeCollider2D>();
                var edge = (edgeCollider.adjacentEndPoint - edgeCollider.adjacentStartPoint).normalized;

                var mirroredDir = 2 * Vector2.Dot(currentDir, edge) * edge - currentDir;
                rigidbody2D.velocity = mirroredDir;
            }
        }

        void Update()
        {
            var velo = rigidbody2D.velocity;
            if (velo.magnitude > maxSpeed)
                rigidbody2D.velocity /= (velo.magnitude / maxSpeed);
            Debug.Log("Current velocity: "+ rigidbody2D.velocity.magnitude);
        }
    }
}