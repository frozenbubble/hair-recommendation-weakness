using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour
{
    [SerializeField]
    private GameObject _hairBody;

    [SerializeField]
    private float _maxSize = 100f;

    [SerializeField]
    private float _maxAngle = 30f;

    [SerializeField]
    private float _tickInterval = 10f;

    public void Trim(int height)
    {
        var currentScale = _hairBody.transform.localScale;
        var currentPos = _hairBody.transform.localPosition;
        var newScale = new Vector3(currentScale.x, height, currentScale.z);
        var newPos = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        _hairBody.transform.localScale = newScale;
        //_hairBody.transform.localPosition = 
    }

    void Start()
    {
        transform.Rotate(transform.right, Random.Range(-_maxAngle, _maxAngle));
        transform.Rotate(transform.forward, Random.Range(-_maxAngle, _maxAngle));
        StartCoroutine(GrowHair());
    }

    void Update()
    {
        
    }

    private IEnumerator GrowHair()
    {
        while (true)
        {
            if (true)
            {
                yield return new WaitForSeconds(_tickInterval);
                var currentPos = _hairBody.transform.localPosition;

                _hairBody.transform.localScale += Vector3.up;
                _hairBody.transform.localPosition = new Vector3(currentPos.x, currentPos.y + 1, currentPos.z);
            }
        }
    }
}
