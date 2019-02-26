using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int count = transform.childCount;
        int index = Random.Range(0, count); // 0에서 count까지의 숫자를 랜덤으로 함
        transform.GetChild(index).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
