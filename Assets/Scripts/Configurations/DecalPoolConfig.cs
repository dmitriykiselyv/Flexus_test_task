using UnityEngine;

[CreateAssetMenu(fileName = "DecalPoolConfig", menuName = "ScriptableObjects/DecalPoolConfig", order = 0)]
public class DecalPoolConfig : ScriptableObject
{
    [SerializeField] private Decal _prefab;
    [SerializeField] private int _initialSize = 10;

    public Decal Prefab => _prefab;
    public int InitialSize => _initialSize;
}