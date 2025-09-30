using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TakeButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Color _colorActive;
    [SerializeField] private Color _colorInactive;

    private IDisposable _disposable;

    void Start()
    {
        _disposable = CraneController.Instance.Take.Subscribe(isTake =>
        {
            _button.image.color = isTake ? _colorActive : _colorInactive;
            _text.text = isTake ? "Drop" : "Take";
        });
    }

    private void OnDisable()
    {
        _disposable?.Dispose();
    }
}