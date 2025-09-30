using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "MoveConfig", menuName = "ScriptableObjects/MoveConfig", order = 0)]
    public class MoveConfig : ScriptableObject
    {
        [SerializeField] private MovementData _movementData;
        public MovementData MovementData => _movementData;
    }
}