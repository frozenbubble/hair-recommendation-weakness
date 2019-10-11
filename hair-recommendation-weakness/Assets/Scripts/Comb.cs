using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Comb : MonoBehaviour
{
    [SerializeField]
    private float _combAngle = 30f;

    [SerializeField]
    private float _movementSpeed = 0.5f;

    [SerializeField]
    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_target is null)
        {
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _movementSpeed * Time.deltaTime);
        transform.LookAt(_target);
    }

    private void OnTriggerEnter(Collider other)
    {
        var parent = other.transform.parent;
        var hair = parent.GetComponent<Hair>();

        if (hair is null)
        {
            return;
        }

        hair.transform.rotation = Quaternion.identity;
        hair.transform.Rotate(hair.transform.position + transform.right, _combAngle);
    }
}
