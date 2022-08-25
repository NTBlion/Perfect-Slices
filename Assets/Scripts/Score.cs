using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour

{
    private int _Score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Food _food))
        {
            _Score += 50;
            Debug.Log("Score:" + _Score);
        }
    }
}
