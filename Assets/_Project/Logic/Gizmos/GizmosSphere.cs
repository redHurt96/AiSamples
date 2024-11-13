using UnityEngine;

namespace _Project.Gizmos
{
    public class GizmosSphere : MonoBehaviour
    {
        [SerializeField] private Color _color;
        [SerializeField] private float _radius;
        
        private void OnDrawGizmos()
        {
            UnityEngine.Gizmos.color = _color;
            UnityEngine.Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}
