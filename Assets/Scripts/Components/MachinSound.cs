using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MachinSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private IDisposable _runningDisposable;
    void Start()
    {
        _runningDisposable = CraneController.Instance.Running.Subscribe(MachineRunningState);
    }

    private void MachineRunningState(bool isRunning)
    {
       audioSource.enabled = isRunning;
    }
    private void OnDestroy()
    {
        _runningDisposable?.Dispose();
    }
}
