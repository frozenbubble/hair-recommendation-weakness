using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    private Tool _selectedTool;

    [SerializeField]
    private List<Tool> _tools;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_tools == null || _tools.Count == 0)
        {
            Debug.LogError("Incorrect tool setup");

            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(_selectedTool);
            _selectedTool = GameObject.Instantiate(_tools[0]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

        }
    }
}
