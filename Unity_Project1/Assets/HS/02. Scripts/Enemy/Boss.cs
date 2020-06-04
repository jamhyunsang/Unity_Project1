using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    //총알 담을 변수
    public GameObject bullet;
    //총알 스피드
    public float bulletSpeed = 10.0f;
    //총알 발사 시간
    float fireTime =1.0f;

    public float fireTime1=1.5f;
    public int bulletMax = 10;
    float curTime1;
    //현재 시간
    float curTime;

    public GameObject target;

    //총알 발사할 포인트를 가져옴
    public GameObject bulletPiont;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Fire1();

        
    }
    void Fire()
    {
        if (target != null)
        {
            curTime += Time.deltaTime;
            if (curTime >= fireTime)
            {
                curTime = 0.0f;
                Vector3 dir = target.transform.position - bulletPiont.transform.position;
                dir.Normalize();
                bulletPiont.transform.up = dir;
                Instantiate(bullet, bulletPiont.transform.position, bulletPiont.transform.rotation);
            }
        }
    }
    void Fire1()
    {
        if (target != null)
        {
            curTime1 += Time.deltaTime;
            if (curTime1 >= fireTime1)
            {
                curTime1 = 0.0f;
                for (int i = 0; i < bulletMax; i++)
                {
                    float angle = 360 / bulletMax;
                    bulletPiont.transform.eulerAngles = new Vector3(0, 0, i * angle);
                    Instantiate(bullet, bulletPiont.transform.position, bulletPiont.transform.rotation);
                }
            }
        }
    }
}
