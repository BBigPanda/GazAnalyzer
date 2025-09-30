using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoConnectJoints : MonoBehaviour
{
    [SerializeField] private GameObject[] _joints;

    private void OnValidate()
    {
        for (int i = 0; i < _joints.Length; i++)
        {
            if (!_joints[i].GetComponent<HingeJoint>())
                _joints[i].AddComponent<HingeJoint>();
            
           
        }

        for (int i = _joints.Length-1; i > 0; i--)
        {
            _joints[i].GetComponent<HingeJoint>().connectedBody = _joints[i - 1].GetComponent<Rigidbody>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}