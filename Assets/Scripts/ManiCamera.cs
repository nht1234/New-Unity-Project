using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManiCamera : MonoBehaviour
{
    public Transform player; // 캐릭터를 받아오기 위해 변수를 만듦
    public float distance = 2.0f; // 카메라가 떨어진 거리를 설정하기 위한 변수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position; // 카메라의 현재 위치
        pos.z = player.transform.position.z - distance; // z값의 설정
        transform.position = pos; //설정한 값으로 카메라의 위치를 세팅하여 줍니다
    }
}
