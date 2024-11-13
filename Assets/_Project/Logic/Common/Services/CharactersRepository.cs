using System.Collections.Generic;
using _Project.Common.Characters.Model;
using UnityEngine;
using UnityEngine.Assertions;

namespace _Project.Common.Services
{
    public class CharactersRepository
    {
        
        private readonly List<Character> _characters = new();

        public bool HasEnemy(Character forCharacter)
        {
            foreach (Character character in _characters)
            {
                if (character.Team != forCharacter.Team)
                    return true;
            }

            return false;
        }

        public Character GetClosestEnemy(Character forCharacter)
        {
            float closestSqrDistance = float.MaxValue;
            Character closestEnemy = null;

            foreach (Character character in _characters)
            {
                float sqrDistance = Vector3.SqrMagnitude(forCharacter.Position - character.Position);

                if (sqrDistance < closestSqrDistance && character.Team != forCharacter.Team)
                {
                    closestSqrDistance = sqrDistance;
                    closestEnemy = character;
                }
            }

            Assert.IsNotNull(closestEnemy);
            
            return closestEnemy;
        }

        public void Register(Character character) => 
            _characters.Add(character);

        public void Unregister(Character character) => 
            _characters.Remove(character);
    }
}