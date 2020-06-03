using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerMove : MonoBehaviour
{
    //플레이어 이동
    public float _speed = 5.0f;
    public Vector2 margin;      //뷰 포트 좌표는 0,0~1.0사이의 값

 

    

    // Start is called before the first frame update
    void Start()
    {
        margin = new Vector2(0.1f, 0.05f);
       
    }

    // Update is called once per frame
    void Update()
    {
       
       Move();
        
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //방법 1
        //transform.Translate((h * _speed * Time.deltaTime),(v*_speed*Time.deltaTime),0);

        //방법2
       // Vector3 dir = Vector3.right * h + Vector3.up * v+Vector3.zero;
    
        //방법3
        Vector3 dir = new Vector3(h, v, 0);
        transform.Translate(dir * _speed * Time.deltaTime);


        //위치 = 현재위치 + (방향 * 시간)
        //transform.position += dir * _speed * Time.deltaTime;


        //플레이어가 화면 밖으로 이동 못하게 하기
        MoveInScreen();
    }

    private void MoveInScreen()
    {
        //방법은 크게 3가지
        //첫번째 
        //화면 밖의 공간에 큐브 4개 만들어서 배치
        //리지드 바디 충돌체로 이동 못하게 막기

        //두번째
        //플레이어 포지션으로 이동처리
        //캐스팅
        //아래와 같이 transform.position의 값을 vector3에 담아서 계산 하고 다시 대입시키는 과정을 캐스팅 
        //Vector3 position = transform.position;
        //position.x = Mathf.Clamp(position.x, -2.5f, 2.5f);
        //position.y = Mathf.Clamp(position.y, -3.5f, 3.5f);
        //transform.position = position;

        //세번째
        //메인카메라의 뷰포트를 가져와서 처리한다
        //스크린 좌표 : 왼쪽 하단 (0,0), 우측 상단 (maxX,mayY)
        //뷰포트 좌표 : 왼쪽 하단 (0,0), 우측 상단 (1.0f,1.0f);
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp(position.x, -0.0f+margin.x, 1.0f-margin.x);
        position.y = Mathf.Clamp(position.y, -0.0f+margin.y, 1.0f-margin.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);
    }
}
