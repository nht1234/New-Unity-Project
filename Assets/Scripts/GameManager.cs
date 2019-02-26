using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Vector3 spwanTilePos; // 새로운 타일을 생성할 위치
    public GameObject tilePrefab; // 생성할 타일 프리팹
    public Text scoreText; // 컴포넌트를 받아오기 위한 변수
    public Text timerText;// 경과시간
    public GameObject readyImage; // 프리팹과 받는 방법이 똑같기에 게임 오브젝트를 씀
    public GameObject player1Button;
    public GameObject player2Button;
    public Player player1;
    public Player player2;
    public AudioClip scoreSound;

    int score = 0; // 점수
    float timer = 0; //경과 시간저장 변수
    public bool isReady = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isReady = false;
                readyImage.SetActive(false);
                player1Button.SetActive(true);
                player2Button.SetActive(true);
            }
        }
        else
        {
            UpdateTimer();// 코드를 간결하게 함
            TestForKeyboard();
        }
    }
    //새로운 타일을 생성하는 함수
    public void SpwanTile()
    {
        Instantiate(tilePrefab, spwanTilePos, Quaternion.identity);
    }

    //점수 증가를 처리하는 함수
    public void AddScore()
    {
        ++score; // 증가 연산자를 이용하여 변수를 증가, 감소함
        scoreText.text = "SCORE : " + score.ToString();
        // 텍스트 컴포넌트를 변경하기 위한 변수, Tostring 으로 문자열과 같이씀  

        AudioSource.PlayClipAtPoint(scoreSound, Camera.main.transform.position);
    }

    // 클래스내부에 사용하기에 public을 안씀
    //시간을 누적시켜 누적된 값을 텍스트에 출력하는 기능을 수행하는 함수
    void UpdateTimer()
    {
        // 전체적인 경과시간
        timer += Time.deltaTime;
        timerText.text = "TIMER : " + timer.ToString("0.0"); // 0.0은 소수점 이하 한자리만 표시
    }

    void TestForKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player1.Jump();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player2.Jump();
        }
    }
}
