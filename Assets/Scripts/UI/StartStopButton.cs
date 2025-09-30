using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class StartStopButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        CraneController.Instance.Running.Subscribe(MachineRunningState);
    }

    private void MachineRunningState(bool isRunning)
    {
        _button.image.color = isRunning ? Color.green : Color.red;
        _text.text = isRunning ? "Stop" : "Start";
    }
}