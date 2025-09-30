using System;
using System.Collections;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;


    private IEnumerator Start()
    {
        _audioSource.enabled = false;
        yield return new WaitForSeconds(1);
        _audioSource.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
