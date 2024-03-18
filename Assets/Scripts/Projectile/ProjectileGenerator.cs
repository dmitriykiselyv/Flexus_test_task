using System;
using Configurations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Projectile
{
    public class ProjectileGenerator : MonoBehaviour
    {
        [SerializeField] private ProjectileConfig _config;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private ProjectileMotion _projectileMotion;
        [SerializeField] private GameObject _decalPrefab;

        public ProjectileMotion ProjectileMotion => _projectileMotion;
        private GenericPool<ProjectileGenerator> _projectilePool;

        private void Awake()
        {
            GenerateMesh();
            
            _projectileMotion.ProjectileDestroyed += ReturnToPool;
        }
        
        private void OnDestroy()
        {
            _projectileMotion.ProjectileDestroyed -= ReturnToPool;
        }

        public void Init(Vector3 initialVelocity, GenericPool<ProjectileGenerator> projectilePool)
        {
            _projectilePool ??= projectilePool;
            _projectileMotion.Init(initialVelocity);
        }
        
        private void ReturnToPool()
        {
            _projectilePool.Return(this);
        }
    
        private void GenerateMesh()
        {
            Mesh mesh = new Mesh();
            _meshFilter.mesh = mesh;

            Vector3[] vertices = {
                new Vector3(-1, -1, 1),
                new Vector3(1, -1, 1),
                new Vector3(1, 1, 1),
                new Vector3(-1, 1, 1),
                new Vector3(-1, -1, -1),
                new Vector3(1, -1, -1),
                new Vector3(1, 1, -1),
                new Vector3(-1, 1, -1),
            };
            
            int[] triangles = {
                0, 2, 1, 
                0, 3, 2,
                2, 3, 6,
                3, 7, 6,
                0, 1, 5,
                0, 5, 4,
                1, 2, 6,
                1, 6, 5,
                0, 4, 7,
                0, 7, 3,
                4, 5, 6,
                4, 6, 7
            };

            ModifyMesh(ref vertices);
        
            Vector2[] uv = new Vector2[vertices.Length];
            for (int i = 0; i < uv.Length; i++)
            {
                uv[i] = new Vector2(vertices[i].x, vertices[i].y);
            }
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uv;

            mesh.RecalculateNormals();

            Material materialInstance = Instantiate(_config.ProjectileMaterial);
            materialInstance.color = new Color(Random.value, Random.value, Random.value);
            _meshRenderer.material = materialInstance;
        
            var meshCollider = gameObject.AddComponent<MeshCollider>();
            meshCollider.sharedMesh = mesh;
            meshCollider.convex = true;
            meshCollider.isTrigger = true;
        }
        
        private void ModifyMesh(ref Vector3[] vertices)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] *= _config.MeshSize;
                var randomModification = new Vector3(
                    (Random.value - 0.5f) * _config.RandomFactor,
                    (Random.value - 0.5f) * _config.RandomFactor * _config.Elongation,
                    (Random.value - 0.5f) * _config.RandomFactor
                );
                vertices[i] += randomModification;
                vertices[i] = new Vector3(
                    vertices[i].x,
                    vertices[i].y * _config.Elongation,
                    vertices[i].z
                );
            }
        }
    }
}