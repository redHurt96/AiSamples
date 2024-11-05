using System.Linq;
using UnityEngine;

namespace _Project.Logic.Common.Characters
{
    public class TeamColor : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private ColorConfig[] _config;
        [SerializeField] private Renderer _renderer;

        private void Start() => 
            _renderer.material.color = _config
                .First(x => x.Team == _character.Team)
                .Color;
    }
}