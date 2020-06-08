using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private Material material;
    private float b = 0.0f;

    public float scrollSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
        BackGroundScroll();
    }

    private void BackGroundScroll()
    {
        //메테리얼의 메인 텍스쳐 오프셋은 벡터2로 만들어져있따.
        Vector2 offset = material.mainTextureOffset;
        //오프셋의 값을 보정해준다.
        offset.Set(0, offset.y + (scrollSpeed * Time.deltaTime));
        //다시 메테리얼의 오프셋에 담는다.
        material.mainTextureOffset = offset;
    }
}
