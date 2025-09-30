using System;
using DG.Tweening;
using ScriptableObjects;
using UniRx;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    [SerializeField] private MoveConfig moveConfig;
    [SerializeField] private AudioSource audioSource;

    private CompositeDisposable _compositeDisposable;
    private IDisposable _runningDisposable;

    void Start()
    {
        _runningDisposable = CraneController.Instance.Running.Subscribe(MachineRunningState);
    }

    private void MachineRunningState(bool isRunning)
    {
        if (isRunning)
        {
            Subscribes();
        }
        else
        {
            _compositeDisposable?.Dispose();
        }
    }

    private void Subscribes()
    {
        _compositeDisposable = new CompositeDisposable();
        if (moveConfig.MovementData.MoveDirection.z != 0)
        {
            CraneController.Instance.Forward.Subscribe(MoveIncrement).AddTo(_compositeDisposable);
            CraneController.Instance.Backward.Subscribe(MoveDecrement).AddTo(_compositeDisposable);
        }

        if (moveConfig.MovementData.MoveDirection.x != 0)
        {
            CraneController.Instance.Left.Subscribe(MoveIncrement).AddTo(_compositeDisposable);
            CraneController.Instance.Right.Subscribe(MoveDecrement).AddTo(_compositeDisposable);
        }

        if (moveConfig.MovementData.MoveDirection.y != 0)
        {
            CraneController.Instance.Up.Subscribe(MoveIncrement).AddTo(_compositeDisposable);
            CraneController.Instance.Down.Subscribe(MoveDecrement).AddTo(_compositeDisposable);
        }
    }


    private void MoveIncrement(bool isActive)
    {
        Vector3 movePos = moveConfig.MovementData.MoveDirection * moveConfig.MovementData.MoveLimits.MaxPos;
        Move(isActive, movePos);
    }

    private void MoveDecrement(bool isActive)
    {
        Vector3 movePos = moveConfig.MovementData.MoveDirection * moveConfig.MovementData.MoveLimits.MinPos;
        Move(isActive, movePos);
    }

    private void Move(bool isActive, Vector3 movePos)
    {
        audioSource.Stop();
        transform.DOKill();
        if (!isActive)
            return;
        audioSource.Play();
        float distance = Vector3.Distance(movePos, transform.localPosition);
        Vector3 result = RemoveAxis(transform.localPosition, moveConfig.MovementData.MoveDirection);
        movePos += result;
        transform.DOLocalMove(movePos, moveConfig.MovementData.MoveDuration * distance)
            .SetEase(moveConfig.MovementData.MoveEase);
    }

    private Vector3 RemoveAxis(Vector3 vector, Vector3 axis)
    {
        return vector - Vector3.Dot(vector, axis) * axis;
    }

    private void OnDestroy()
    {
        _compositeDisposable?.Dispose();
        _runningDisposable?.Dispose();
    }
}