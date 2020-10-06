using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeshHidder : MonoBehaviour
{
    private MeshRenderer[] _meshes;

    private void Awake()
    {
        _meshes = GetComponentsInChildren<MeshRenderer>();
    }

    public void Show()
    {
        foreach (var mesh in _meshes)
        {
            mesh.enabled = true;
        }
    }

    public void Hide()
    {
        foreach (var mesh in _meshes)
        {
            mesh.enabled = false;
        }
    }
}
