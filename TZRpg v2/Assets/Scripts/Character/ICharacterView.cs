using System;
using UnityEngine;

namespace Character
{
    public interface ICharacterView
    {
        GameObject gameObject { get; }
        CharacterType Type { get; }
    }
}