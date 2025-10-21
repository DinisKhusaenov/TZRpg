using Character;
using Character.Config;
using UnityEngine;

namespace Services.Character
{
    public class RandomCharacterAcquisitionService : ICharacterAcquisitionService
    {
        private readonly CharacterConfig _characterConfig;

        public RandomCharacterAcquisitionService(CharacterConfig characterConfig)
        {
            _characterConfig = characterConfig;
        }

        public CharacterView GetView()
        {
            int randomId = Random.Range(0, _characterConfig.CharactersCount);
            return _characterConfig.Views[randomId];
        }
    }
}