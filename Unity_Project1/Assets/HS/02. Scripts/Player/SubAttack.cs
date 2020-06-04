using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttack : MonoBehaviour
{

    //아이템 먹어서 보조비행기가 생길도록 해야한다
    //보조 비행기는 일정시간마다 자동으로 총알 발사 한다.

    public GameObject[] _clone;
   
    //불릿가져오기
    public GameObject _bulletFactory;

    public float _fireTime = 3.0f;
    float currentTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _clone.Length; i++)
        {
            _clone[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < _clone.Length; i++)
            {
                _clone[i].SetActive(true);
            }
        }

        for (int i = 0; i < _clone.Length; i++)
        {
                 if (_clone[i].activeSelf)
        {
            BulletMake();
        }
        }
    }

    private void BulletMake()
    {
            
                currentTime += Time.deltaTime;
                if (currentTime > _fireTime)
                {
                    Instantiate(_bulletFactory, _clone[0].transform.position, _clone[0].transform.rotation);
                    Instantiate(_bulletFactory, _clone[1].transform.position, _clone[1].transform.rotation);
                currentTime = 0.0f;
                }
            }
        
    
}
