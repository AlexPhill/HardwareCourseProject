using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            health -= 1;
        }
        if (other.tag == "bullet")
        {
            health -= 1;
        }
        if (other.tag == "End")
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
