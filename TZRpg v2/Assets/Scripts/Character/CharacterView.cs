using UnityEngine;

namespace Character
{
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [field: SerializeField] public CharacterType Type { get; private set; }
    }
}