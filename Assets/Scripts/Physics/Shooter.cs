using System;
using UnityEngine;

namespace Physics
{
    public class Shooter : MonoBehaviour
    {
        [Header("Projectile Settings")] [SerializeField]
        private Projectile projectilePrefab;

        [SerializeField] private float shootForce;

        [Header("External References")] [SerializeField]
        private Camera cam;

        [SerializeField] private Transform projectileParent;

        [Header("Internal References")] [SerializeField]
        private Transform arrowTransform;

        [SerializeField] private Transform arrowBody;
        [SerializeField] private Transform arrowHead;

        private new Transform transform;
        private Vector2 currentDirection = Vector3.right;
        private float currentLength = 1f;

        private void Awake()
        {
            transform = base.transform;
        }

        private void Start()
        {
            SetArrowRotation(currentDirection);
            SetArrowLength(currentLength);
            SetArrowVisible(true);
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                GetDirectionLength(out currentDirection, out currentLength);
                SetArrowRotation(currentDirection);
                SetArrowLength(currentLength);
            }
            if (Input.GetMouseButton(1))
            {
                Shoot(currentDirection, shootForce * currentLength);
            }
        }

        private void GetDirectionLength(out Vector2 direction, out float length)
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePos - transform.position;
            length = new Vector2(direction.x, direction.y).magnitude;
        }

        private void Shoot(Vector2 direction, float force)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation, projectileParent);
            projectile.Shoot(direction, force);
        }

        private void SetArrowVisible(bool visible)
        {
            arrowTransform.gameObject.SetActive(visible);
        }

        private void SetArrowRotation(Vector3 direction)
        {
            var degree = PhysicsUtility.DegreeFromDirection(direction);
            transform.eulerAngles = new Vector3(0, 0, degree);
        }

        private void SetArrowLength(float length)
        {
            var scale = arrowTransform.localScale;
            arrowBody.localScale = new Vector3(scale.x, length, scale.z);
            var pos = arrowHead.localPosition;
            arrowHead.localPosition = new Vector3(pos.x, length, pos.z);
        }
    }
}