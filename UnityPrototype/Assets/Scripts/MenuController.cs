using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] string Scene1;
    [SerializeField] string Scene2;
    [SerializeField] string Scene3;
    public bool Scene1Shot;
    public bool Scene2Shot;
    public bool Scene3Shot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Scene1Shot) 
        {
            StartCoroutine(scene1());
        }
        if (Scene2Shot) 
        {
        
            StartCoroutine (scene2());
        }
        if (Scene3Shot) 
        {

            StartCoroutine(scene3());
        }

    }
    public IEnumerator scene1()
    {
        Scene1Shot = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(Scene1);
    }
    public IEnumerator scene2()
    {
        Scene2Shot = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(Scene2);
    }
    public IEnumerator scene3()
    {
        Scene3Shot = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(Scene3);
    }
}
