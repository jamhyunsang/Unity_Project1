using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject _bulletFactory; //총알 프리팹
    public GameObject _bulletPoint; // 총알 발사 위치


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletFire();
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
}
