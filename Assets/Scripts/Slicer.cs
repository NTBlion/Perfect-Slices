using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BzKovSoft.ObjectSlicer;
using BzKovSoft.ObjectSlicerSamples;

public class Slicer : MonoBehaviour
{
    [SerializeField] private GameObject _blade;
    [SerializeField] private float _duration;
    [SerializeField] private float _offsetY;

    private BzKnife _knife;
    private bool _isSliced = false;

    private void Start()
    {
        _knife = _blade.GetComponentInChildren<BzKnife>();
    }


    private void Update()
    {
        if (Input.GetMouseButton(0) && _isSliced == false)
        {
            _isSliced = true;
            StartCoroutine(DelayBeforeSlice());
        }
    }

    private IEnumerator DelayBeforeSlice()
    {
        _knife.BeginNewSlice();
        _blade.transform.DOMoveY(_blade.transform.position.y - _offsetY, _duration / 2f).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(_duration);
        _isSliced = false;
    }

}
