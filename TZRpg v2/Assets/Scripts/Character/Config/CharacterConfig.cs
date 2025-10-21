using System;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Config
{
    [CreateAssetMenu(menuName = "Configs/CharacterConfig", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeReference] private CharacterView[] _characters;

        public int CharactersCount => _characters.Length;
        public CharacterView[] Views => _characters;

        private void OnValidate()
        {
            if (_characters == null) return;
            
            HashSet<CharacterType> types = new HashSet<CharacterType>();
            foreach (ICharacterView character in _characters)
            {
                if (!types.Add(character.Type))
                    Debug.Log($"Prefabs with type {character.Type} already exist");
            }
        }

        public ICharacterView GetCharacterBy(CharacterType type)
        {
            foreach (CharacterView view in _characters)
            {
                if (view.Type == type)
                    return view;
            }

            throw new ArgumentException($"Character with type {type} does not exist");
        }
    }
}