using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(fileName = "CannonConfig", menuName = "ScriptableObjects/CannonConfig", order = 1)]
    public class CannonConfig : ScriptableObject
    {
        [SerializeField] private float _standRotationMultiplier = 20f;
        [SerializeField] private float _barrelRotationMultiplier = 10f;
        [SerializeField] private float _barrelElevationMax = 0;
        [SerializeField] private float _barrelElevationMin = -90f;

        public float StandRotationMultiplier => _standRotationMultiplier;
        public float BarrelRotationMultiplier => _barrelRotationMultiplier;
        public float BarrelElevationMax => _barrelElevationMax;
        public float BarrelElevationMin => _barrelElevationMin;
    }
}