using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayBeforeRestart = 2.0f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delayBeforeRestart);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
