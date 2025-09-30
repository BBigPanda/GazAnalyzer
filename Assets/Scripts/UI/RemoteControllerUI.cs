using System.Collections;
using TMPro;
using UnityEngine;

public class RemoteControllerUI : MonoBehaviour
{
    [SerializeField] private CustomButton _startStopButton;
    [SerializeField] private CustomButton _upButton;
    [SerializeField] private CustomButton _downButton;
    [SerializeField] private CustomButton _leftButton;
    [SerializeField] private CustomButton _rightButton;
    [SerializeField] private CustomButton _forwardButton;
    [SerializeField] private CustomButton _backwardButton;
    [SerializeField] private CustomButton _takeButton;
    [SerializeField] private TMP_Text _textCounting;


    void Start()
    {
        _upButton.Pressed += value => { CraneController.Instance.Up.Value = value; };
        _downButton.Pressed += value => { CraneController.Instance.Down.Value = value; };

        _leftButton.Pressed += value => { CraneController.Instance.Left.Value = value; };
        _rightButton.Pressed += value => { CraneController.Instance.Right.Value = value; };

        _forwardButton.Pressed += value => { CraneController.Instance.Forward.Value = value; };
        _backwardButton.Pressed += value => { CraneController.Instance.Backward.Value = value; };
        _takeButton.Pressed += value =>
        {
            if (value)
            {
                CraneController.Instance.Take.Value = !CraneController.Instance.Take.Value;
            }
        };
        _startStopButton.Pressed += value =>
        {
            if (value)
            {
                StartCoroutine(StartStopCounting());
            }
            else
            {
                _textCounting.enabled = false;
                StopAllCoroutines();
            }
        };
    }

    private void StartStopMachine()
    {
        CraneController.Instance.Running.Value = !CraneController.Instance.Running.Value;
    }

    private IEnumerator StartStopCounting()
    {
        _textCounting.enabled = true;
        var wait = new WaitForSeconds(1);
        for (int i = 3; i >= 1; i--)
        {
            _textCounting.text = i.ToString();
                yield return wait;
        }

        _textCounting.enabled = false;
        StartStopMachine();
    }
}