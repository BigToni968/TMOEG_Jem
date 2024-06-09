using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Audio : MonoBehaviour
{
    [field: SerializeField] public AudioSource Volume { get; private set; }
    [field: SerializeField] public AudioSource Sound { get; private set; }
    [field: SerializeField] public AudioSource UIButton { get; private set; }
    [SerializeField] public AudioClip[] FirstAttack; 
    [SerializeField] public AudioClip[] SecondaryAttack; 
    [SerializeField] public AudioClip[] ThertyAttack; 
    [SerializeField] public AudioClip[] FourthAttack; 
    [SerializeField] public AudioClip[] FiveAttack; 
    [SerializeField] public AudioClip[] health_Player; 
    [SerializeField] private AudioClip buuttonClip;
    [SerializeField] public AudioClip[] hit_player;
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
        Audio.Instance.UIButton.PlayOneShot(buuttonClip);
    }
}
