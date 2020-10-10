using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    [SerializeField] private KeyCardType _keyCardType;

    public enum KeyCardType
    {
        Red,
        Blue,
        Brown
    }

    public KeyCardType GetKeyCardType()
    {
        return _keyCardType;
    }
}
