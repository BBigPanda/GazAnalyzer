using System;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class Take : MonoBehaviour
{
    [SerializeField] private Rigidbody _craneJoint;
    private IDisposable _disposable;

    private CharacterJoint triggerdJoint;
    private GameObject triggerdObject;

    void Start()
    {
        CraneController.Instance.Take.Subscribe(TakeObject);
    }

    private void TakeObject(bool isTake)
    {
        if (triggerdObject && isTake)
        {
            triggerdJoint = triggerdObject.AddComponent<CharacterJoint>();
            
            Vector3 newAnchor = triggerdObject.transform.InverseTransformPoint(transform.position);
            triggerdJoint.connectedBody = _craneJoint;
            triggerdJoint.autoConfigureConnectedAnchor = true;
            triggerdJoint.anchor = newAnchor;
            
        }else if (triggerdObject && !isTake)
        {
           Destroy(triggerdJoint); 
           triggerdObject = null;
        }
        else
        {
            CraneController.Instance.Take.Value = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Takeable")&& !triggerdObject)
            triggerdObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Takeable") && !triggerdJoint)
        {
            triggerdObject = null;
        }
    }

    private void OnDestroy()
    {
        _disposable?.Dispose();
    }
}