using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeOfView : MonoBehaviour
{
    private bool _isTargetInView;
    [SerializeField] private Transform _target;

    public bool IsTargetInView
    {
        get => _isTargetInView;
        set => _isTargetInView = value;
    }

    void Awake()
    {
        
    }

   
    void Update()
    {
        
    }
}