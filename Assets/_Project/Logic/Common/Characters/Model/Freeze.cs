using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Common.Characters.Model
{
    public class Freeze : MonoBehaviour
    {
        [SerializeField] private float _freezeTime;
        [SerializeField, Range(0f, 1f)] private float _freezeChance;

        public void TryFreeze(Character target)
        {
            if (_freezeChance < Random.value)
                target.Freeze(_freezeTime);
        }
    }
}