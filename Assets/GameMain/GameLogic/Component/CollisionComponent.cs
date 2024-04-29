using UnityEngine;
using UnityEngine.Serialization;

namespace Wcng
{
    public class CollisionComponent : CoreComponent
    {
        public Transform footTransform;
        public float groundCheckDistance;
        public bool RayGroundCheck(LayerMask layerMask)
            =>Physics2D.Raycast(footTransform.position, Vector2.down, groundCheckDistance / 2, 1<<layerMask);
    }
}
