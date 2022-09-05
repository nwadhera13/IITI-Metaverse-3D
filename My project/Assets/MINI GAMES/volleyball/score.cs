using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text playerascore;
    public Text playerbscore;
    static public int ascore = 0;
    static public int bscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerascore.text = ascore.ToString();
        playerbscore.text = bscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerascore.text = ascore.ToString();
        playerbscore.text = bscore.ToString();
    }
}
