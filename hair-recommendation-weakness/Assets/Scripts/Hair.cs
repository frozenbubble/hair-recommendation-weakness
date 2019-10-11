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
        var currentPos = _hairBody.transform.localPosition;
        
        while (_hairBody.transform.localScale.y > height)
        {
            _hairBody.transform.localScale -= Vector3.up;
            _hairBody.transform.localPosition = new Vector3(currentPos.x, currentPos.y - 1, currentPos.z);
        }
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
            yield return new WaitForSeconds(_tickInterval);
            var currentPos = _hairBody.transform.localPosition;

            _hairBody.transform.localScale += Vector3.up;
            _hairBody.transform.localPosition = new Vector3(currentPos.x, currentPos.y + 1, currentPos.z);
        }
    }
}
