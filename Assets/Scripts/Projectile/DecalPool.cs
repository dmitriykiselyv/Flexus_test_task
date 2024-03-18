using UnityEngine;
using UnityEngine.Serialization;

namespace Projectile
{
    public class DecalPool : MonoBehaviour
    {
        [SerializeField] private float _decalOffset = 0.01f;
        [SerializeField] private float _decalRotationX = 90f; 
        
        private DecalPoolConfig _decalPoolConfig;
        private GenericPool<Decal> _decalPool;
        private GenericPool<ProjectileGenerator> _projectilePool;

        public void Init(DecalPoolConfig decalPoolConfig, GenericPool<ProjectileGenerator> projectilePool)
        {
            _decalPoolConfig = decalPoolConfig;
            _projectilePool = projectilePool;
            _decalPool = new GenericPool<Decal>(_decalPoolConfig.Prefab, _decalPoolConfig.InitialSize, transform);
            
            foreach (var projectile in _projectilePool.GetAllObj())
            {
                projectile.ProjectileMotion.OnCollisionDetected += HandleCollisionDetected;
            }
        }

        public void Cleanup()
        {
            foreach (var projectile in _projectilePool.GetAllObj())
            {
                projectile.ProjectileMotion.OnCollisionDetected -= HandleCollisionDetected;
            }
        }
        
        private void HandleCollisionDetected(RaycastHit hitInfo)
        {
            Decal decal = _decalPool.Get();
            decal.transform.position = hitInfo.point + hitInfo.normal * _decalOffset;
            Quaternion decalRotation = Quaternion.LookRotation(hitInfo.normal);
            decal.transform.rotation = decalRotation * Quaternion.Euler(_decalRotationX, 0f, 0f);
        }
    }
}
