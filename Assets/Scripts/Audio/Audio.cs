using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    [field: SerializeField] public AudioSource Volume { get; private set; }
    [field: SerializeField] public AudioSource Sound { get; private set; }
    [field: SerializeField] public AudioSource UIButton { get; private set; }
    

    [SerializeField] public AudioClip[] clip; 
    [SerializeField] private AudioClip m_clip;
    [SerializeField] public AudioClip hit_player;
    public static Audio Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
    public void Play()
    {
        Audio.Instance.UIButton.PlayOneShot(m_clip);
    }
}
