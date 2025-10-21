using UnityEngine;

namespace Character.Factory
{
    public interface ICharacterFactory
    {
        ICharacterView CreateCharacter(CharacterType type, Vector3 position);
    }
}