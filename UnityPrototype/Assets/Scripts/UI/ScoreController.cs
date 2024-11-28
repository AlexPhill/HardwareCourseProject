using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreController : MonoBehaviour
{
    //[SerializeField] float score;
    public TextMeshProUGUI textmeshPro;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        //textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.SetText("SCORE:");
    }

    // Update is called once per frame
    void Update()
    {
        textmeshPro.SetText("SCORE:" + score.ToString());
    }

    public void IncreaseScore(int s)
    {
        score += s;
    }
}
