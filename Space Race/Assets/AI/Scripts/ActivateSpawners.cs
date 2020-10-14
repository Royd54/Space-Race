using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpawners : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawners;
    [SerializeField] private AudioClip _chosenSong;

    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject spawner in _spawners)
        {
            spawner.SetActive(true);
        }
        PlayChosenSong();
    }

    private void PlayChosenSong()
    {
        if (!AudioManager.Instance.MusicIsPlaying())
        {
            AudioManager.Instance.PlayMusicWithFade(_chosenSong);
        }
    }
}
