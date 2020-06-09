using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject _bulletFactory; //총알 프리팹
    public GameObject _bulletPoint; // 총알 발사 위치

    //레이저를 발사하기 위한 라인 렌더러 가 필요하다 
    //선은 최소 두개 의 점이 필요하다 (시작점 끝점)
    LineRenderer lr;
    Ray ray;
    RaycastHit hitInfo;
    float currentTime;
    float deleteTime = 0.5f;
    public float rayDistance = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        //라인 렌더러 가져오기
        lr = GetComponent<LineRenderer>();
        hitInfo = new RaycastHit();
        
        //중요 
        //게임 오브젝트는 활성화 비활성화 = > SetActive()
        //컴포넌트는 enabled 속성 사용

        
    }

    // Update is called once per frame
    void Update()
    {
       // BulletFire();
       // FireRay();
    }

    private void BulletFire()
    {
       
         if (Input.GetButtonDown("Fire1"))
         {
            //총알공장(총알프리팹_에서 총알을 무한대로 찍어낸다.
            //Instantiate(함수)로 프리팹 파일을 게임오브젝트로 담
            //Instantiate(_bulletFactory, _bulletPoint.transform.position, _bulletPoint.transform.rotation);
            GameObject bullet = Instantiate(_bulletFactory);
            bullet.transform.position = _bulletPoint.transform.position;

         }
       
    }

    public void FireRay()
    {
        ray.origin = transform.position;
        ray.direction = transform.up;
        if (Input.GetButtonDown("Fire1"))

        {

            
            //라인 렌더러 활성화
            lr.enabled = true;
            //라인 시작점, 끝점
            Vector3 pos = transform.position;
            lr.SetPosition(0, pos);
            lr.SetPosition(1, transform.position + Vector3.up * 10);

            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, rayDistance))
            {
                if (hitInfo.collider.name!="top")
                {

                    lr.SetPosition(1, hitInfo.point);
                    Destroy(hitInfo.collider.gameObject);

                }
                else
                {
                    lr.SetPosition(1, transform.position + Vector3.up * 10);
                }
            }
            
        }
    if(lr.enabled==true)
        {
            currentTime += Time.deltaTime;
            if (currentTime > deleteTime)
            {
                currentTime = 0.0f;
                lr.enabled = false;
            }
                
        }
    }
    public void OnFireButton()
    {
        GameObject bullet = Instantiate(_bulletFactory);
        bullet.transform.position = _bulletPoint.transform.position;
    }
}
