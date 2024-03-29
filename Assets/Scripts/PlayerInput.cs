﻿using Photon.Pun;
using UnityEngine;

// 플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지
// 감지된 입력값을 다른 컴포넌트들이 사용할 수 있도록 제공
public class PlayerInput : MonoBehaviourPun
{
    public string verticalAxisName = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름
    public string horizonAxisName = "Horizontal"; // 좌우 회전을 위한 입력축 이름
    public string fireButtonName = "Fire1"; // 발사를 위한 입력 버튼 이름
    public string reloadButtonName = "Reload"; // 재장전을 위한 입력 버튼 이름

    // 값 할당은 내부에서만 가능
    public Vector3 moveInput { get; private set; } // 감지된 움직임 입력값
    //public float offset { get; private set; } // 달리기를 감지하는 입력값
    public bool fire { get; private set; } // 감지된 발사 입력값
    public bool reload { get; private set; } // 감지된 재장전 입력값

    // 매프레임 사용자 입력을 감지
    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        // 게임오버 상태에서는 사용자 입력을 감지하지 않는다
        if (GameManager.instance != null
            && GameManager.instance.isGameover)
        {
            fire = false;
            reload = false;
            return;
        }
        //벡터의 덧셈을 응용
        // move에 관한 입력 감지
        moveInput = new Vector3(
            (Input.GetAxis(horizonAxisName) + Input.GetAxis(verticalAxisName)), 0, (-Input.GetAxis(horizonAxisName) + Input.GetAxis(verticalAxisName)));
        //shift키를 누르면 달릴 수 있게 하기
        //offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

        // fire에 관한 입력 감지
        fire = Input.GetButton(fireButtonName);
        // reload에 관한 입력 감지
        reload = Input.GetButtonDown(reloadButtonName);
    }
}