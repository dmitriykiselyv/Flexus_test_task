using UnityEngine;
using UnityEngine.UI;

namespace Cannon
{
    public class TrajectoryRenderer : MonoBehaviour
    {
        [SerializeField] private Slider _powerSlider;
        [SerializeField] private Transform _launchPoint;
        [SerializeField] private int _resolution = 15;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _gravityFactor = 0.5f; 

        private void LateUpdate()
        {
            RenderTrajectory();
        }
    
        private void RenderTrajectory()
        {
            Vector3[] points = new Vector3[_resolution];
            float launchSpeed = _powerSlider.value;

            for (int i = 0; i < _resolution; i++)
            {
                float t = (float)i / (_resolution - 1);
                points[i] = CalculateTrajectoryPoint(t, launchSpeed, _launchPoint.forward);
            }

            _lineRenderer.positionCount = _resolution;
            _lineRenderer.SetPositions(points);
        }

        private Vector3 CalculateTrajectoryPoint(float t, float launchSpeed, Vector3 direction)
        {
            float gravityY = Mathf.Abs(Constants.Constants.PHYSICS_GRAVITY_Y);
            Vector3 velocity = launchSpeed * direction;
            Vector3 gravityVector = Vector3.up * gravityY;
            Vector3 position = _launchPoint.position + (velocity * t) + (-gravityVector * (_gravityFactor * t * t));

            return position;
        }
    }
}
