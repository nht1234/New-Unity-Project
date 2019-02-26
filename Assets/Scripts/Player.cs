using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5; // 캐릭터 이동 속도
    public float jumpPower = 10;
    bool isjump = false;
    bool jumpStart = false;
    public GameManager gameManager;
    public bool isMain = false;
    public AudioClip jumpSound;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        // 게임 준비 상태 체크
        if (gameManager.isReady)
            return;
        //이동처리
        transform.Translate(0,0,speed * Time.deltaTime);
        //바닥 도착 체크
        if (transform.position.y < 0.001f && !jumpStart)
        {
            isjump = false;
            GetComponent<Animator>().SetBool("Jump", false);
        }

        jumpStart = true;
    }

    // 오브젝트가 충돌하면, 유니티에서 자동으로 호출하는 함수
    private void OnCollisionEnter(Collision collision)
    {
        // 만약, 충돌한 오브젝트의 태그가 Block이면
        if (collision.transform.tag == "Block")
        {
            //게임 오버 처리를 한다.
            SceneManager.LoadScene(0);
        }

    }
    // 트리거에 접촉했을때 자동 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        if (!isMain)
            return;

        gameManager.SpwanTile();
        gameManager.AddScore(); // 점수 증가 함수를 호출하는 곳

        //현재 바닥을 파괴한다.
        Destroy(other.transform.parent.gameObject, 5.0f);
    }

    public void Jump()
    {
        if(!isjump)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpPower, 0);
            isjump = true;
            jumpStart = true;

            GetComponent<Animator>().SetBool("Jump", true);

            AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
        }
    }
}
