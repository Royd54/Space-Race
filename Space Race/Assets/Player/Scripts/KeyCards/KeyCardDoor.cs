using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardDoor : MonoBehaviour
{
    [SerializeField] private KeyCard.KeyCardType _keyCardType;
    [SerializeField] private GameObject _doorPart;
    [SerializeField] private GameObject _endPos;
    [SerializeField] private float _openSpeed;
    [SerializeField] private bool _doorIsOpened = false;

    public KeyCard.KeyCardType GetKeyCardType()
    {
        return _keyCardType;
    }

    private void Update()
    {
        if (_doorIsOpened) OpenDoor();
    }

    private void OpenDoor()
    {
        _doorPart.transform.position = Vector3.Lerp(_doorPart.transform.position, _endPos.transform.position, _openSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        KeyCard keyCard = other.GetComponent<KeyCard>();
        if (keyCard != null)
        {
            if (keyCard.GetKeyCardType() == GetKeyCardType())
            {
                _doorIsOpened = true;
            }
        }
    }
}
