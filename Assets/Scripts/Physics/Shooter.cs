using UnityEngine;

namespace Physics
{
    public class Shooter : MonoBehaviour
    {
        [Header("Default Settings")] [SerializeField]
        private Vector2 startDirection = Vector2.right;
        private float startLength = 1f;
        
        [Header("Projectile Settings")] [SerializeField]
        private Projectile projectilePrefab;
        [SerializeField] private float velocityMultiplier = 5;
        [SerializeField] private float minSpeed = 5;
        [SerializeField] private Transform projectileParent;

        [Header("Internal References")] [SerializeField]
        private Transform arrowTransform;

        [SerializeField] private Transform arrowBody;
        [SerializeField] private Transform arrowHead;

        [SerializeField] private float maxArrowLength = 5f;

        private new Transform transform;
        private Vector2 currentDirection;
        private float currentLength;
        private Projectile currentProjectile;

        private void Awake()
        {
            transform = base.transform;
            currentDirection = startDirection;
            currentLength = startLength;
        }

        private void Start()
        {
            SetArrowRotation(currentDirection);
            SetArrowLength(currentLength);
            SetArrowVisible(true);
        }

        public void Click(Vector2 mousePosWorld)
        {
            currentDirection = mousePosWorld - (Vector2) transform.position;
            currentLength = new Vector2(currentDirection.x, currentDirection.y).magnitude;
            currentLength = Mathf.Min(currentLength, maxArrowLength);
            SetArrowRotation(currentDirection);
            SetArrowLength(currentLength);
        }

        public void Reset()
        {
            if(currentProjectile != null)
                Destroy(currentProjectile.gameObject);
        }

        public void Shoot()
        {
            Reset();
            currentProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, projectileParent);
            Debug.Log("currentDir: "+ currentDirection + "velocity: "+ minSpeed + velocityMultiplier * currentLength);
            currentProjectile.Shoot(currentDirection.normalized, minSpeed + velocityMultiplier * currentLength);
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