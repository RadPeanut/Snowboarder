using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayBeforeRestart = 2.0f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    PlayerController playerController;
    DustTrail dustTrail;

    bool effectsEnabled = true;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        dustTrail = FindObjectOfType<DustTrail>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground") {
            playerController.DisableControls();
            dustTrail.DisableEffects();
            if (effectsEnabled)
            {
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                crashEffect.Play();
                effectsEnabled = false;
                Invoke("ReloadScene", delayBeforeRestart);
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
