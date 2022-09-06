using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int NumberOfCoins;
    Text Scoretext;

    // Start is called before the first frame update
    void Start()
    {
        Scoretext = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void CountCoins(int score)
    {
        NumberOfCoins ++;
        Scoretext.text =NumberOfCoins.ToString();
        Debug.Log(NumberOfCoins);
    }
}
