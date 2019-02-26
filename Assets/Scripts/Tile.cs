using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Transform[] blockSpwan; // 블록 생성위치
    public Transform tileSpwanPoint; // 다음 타일 생성위치
    public GameObject fencePrefab; 

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < blockSpwan.Length; ++i)
        {
            if (Random.Range(0, 2) == 0)
                continue;

            Vector3 fencePos = blockSpwan[i].position;
            GameObject newFence = Instantiate<GameObject>(fencePrefab, fencePos, Quaternion.identity);
            newFence.transform.parent = transform; 
        }
        // 게임 매니저에 다음 생성 위치
        GameManager gameManager = 
            GameObject.Find("GameManager").GetComponent<GameManager>();
            // 프리팹에서는 public 변수로 씬에 있는 프로젝트를 받을 수 없어서 생성할 때 직접 찾아서, 세팅해 줘야 한다.
        gameManager.spwanTilePos = tileSpwanPoint.position;
        // 현재 생성된 타일에 설정된 타일을 다음 생성 위치에 즉, gameManager에 세팅하여 줍니다. 

    //    Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
