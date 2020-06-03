using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{

    //플레이어를 따라 다닌다.
    //플레이어의 위치를 알아야 한다.
    //플레이어의 좌표
    public GameObject _player;
    //이동 속도
    public float _speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {

        //플레이어의 방향 구하기
        //방향은 플레이어-자신

        Vector3 dir = _player.transform.position - transform.position;
        dir.Normalize();
        transform.Translate(dir * _speed * Time.deltaTime);
    }
}
