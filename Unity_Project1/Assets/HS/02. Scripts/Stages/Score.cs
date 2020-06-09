using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text highScore;
    public Text currentScore;
    public int _currentScore;
    public  int _highScore;

    public static Score instance = null;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        _highScore=PlayerPrefs.GetInt("high");
        highScore.text = _highScore.ToString();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore()
    {
        _currentScore++;
        if (_highScore <= _currentScore)
        {
            _highScore = _currentScore;
        }
        highScore.text = _highScore.ToString();
        currentScore.text = _currentScore.ToString();

        PlayerPrefs.SetInt("high", _highScore);
    }

    
}
