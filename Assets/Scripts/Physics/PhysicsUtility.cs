using UnityEngine;

namespace Physics
{
    public static class PhysicsUtility
    {
        public static float DegreeFromDirection(Vector3 direction)
        {
            direction = direction.normalized;
            var dot = Vector2.Dot(direction, Vector2.up);
            var det = direction.x;
            return -180 / Mathf.PI * Mathf.Atan2(det, dot);
        }
    }
}