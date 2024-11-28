using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Button : MonoBehaviour
{
    [SerializeField] MenuController menuController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        menuController.Scene2Shot = true;
    }
}
