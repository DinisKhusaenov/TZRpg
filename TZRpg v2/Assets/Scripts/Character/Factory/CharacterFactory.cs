using Character.Config;
using UnityEngine;

namespace Character.Factory
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly CharacterConfig _config;

        public CharacterFactory(CharacterConfig config)
        {
            _config = config;
        }

        public ICharacterView CreateCharacter(CharacterType type, Vector3 position)
        {
            return Object.Instantiate(_config.GetCharacterBy(type).gameObject, position, Quaternion.identity).GetComponent<ICharacterView>();
        }
    }
}