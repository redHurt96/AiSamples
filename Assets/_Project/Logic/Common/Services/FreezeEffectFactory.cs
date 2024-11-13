using _Project.Common.Characters.Model;
using _Project.Common.Vfx.Freeze;

namespace _Project.Common.Services
{
    public class FreezeEffectFactory
    {
        public void Create(Character character, FreezeEffect freezeEffect) => 
            character.GetComponentInChildren<FreezeVfx>()
                .Construct(freezeEffect);
    }
}