using Projectile;
using UnityEngine;
using UnityEngine.Serialization;

namespace Configurations
{
    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "ScriptableObjects/ProjectileConfig", order = 1)]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private ProjectileGenerator _prefab;
        [SerializeField] private int _initialSize;
        [SerializeField] private float _meshSize = .2f;
        [SerializeField] private float _elongation = 1f;
        [SerializeField] private float _randomFactor = 0.2f;
        [SerializeField] private Material _projectileMaterial;

        public float MeshSize => _meshSize;
        public float Elongation => _elongation;
        public float RandomFactor => _randomFactor;
        public Material ProjectileMaterial => _projectileMaterial;
        public ProjectileGenerator Prefab => _prefab;
        public int InitialSize => _initialSize;
    }
}