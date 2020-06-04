using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyManager : MonoBehaviour
{

    //에너미 매니저의 역활
    //에너미들을 공장에서 찍어 낸다(에너미 프리팹)
    //에너미 스폰 타임
    //에너미 스폰 위치
    

    //에너미 공장
    public GameObject enemyFactory;
    //스폰위치
    public GameObject[] spawnPoint;
    //스폰타임 (몇초에 한번씩)
    float spawnTime=1.0f;
    //누적 타임
    float curTime=0.0f;

        
    // Start is called before the first frame update
    void Update()
    {
        //에너미 생성
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        //몇초에 한번씩 이벤트 발동
        //시간 누적타임으로 계산한다.
        //게임에서 정말 자주 사용함

        curTime += Time.deltaTime;
        if(curTime>spawnTime)
        {

            //누적된 현재시간을 0초로 초기화 
            curTime = 0.0f;
            //스폰 타임을 랜덤으로 
            spawnTime = Random.Range(0.5f, 2.0f);
            int idx = Random.Range(0, spawnPoint.Length);

            //에너미 생성
            Instantiate(enemyFactory, spawnPoint[idx].transform.position, spawnPoint[idx].transform.rotation);


        }
    }


}
