using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class BackpackSlot : XRSocketInteractor
{
    private GameObject _inSocket = null;
    private Vector3 _inSocketScale = Vector3.zero;
    private XRSocketInteractor _socket = null;

    // Start is called before the first frame update
    void Start()
    {
        _socket = GetComponent<XRSocketInteractor>();
    }


    protected override void OnSelectEnter(XRBaseInteractable interactable)
    {
        base.OnSelectEnter(interactable);
        _inSocketScale = _inSocket.transform.localScale;
        if (_inSocket.tag != "Player")
            _inSocket.transform.localScale = gameObject.transform.localScale;
            
    }

    protected override void OnSelectExit(XRBaseInteractable interactable)
    {
        base.OnSelectExit(interactable);
        _inSocket.transform.localScale = _inSocketScale;
        _inSocketScale = Vector3.zero;
    }

    private void OnTriggerStay(Collider other)
    {
        _inSocket = other.gameObject;
    }


}
