using System;
using DG.Tweening;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class MovementData
    {
        public float MoveDuration;
        public Vector3 MoveDirection;
        public Ease MoveEase;
        public MoveLimitsData MoveLimits;
    }
}