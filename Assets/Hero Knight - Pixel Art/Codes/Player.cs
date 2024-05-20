using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
   
    
    //Awake? 시작할때 한번만 시작되는 주기
    //위에서 선언. Awake에서 반드시 초기화할 것.
    void Awake()
    {
      rigid = GetComponent<Rigidbody2D>();
      spriter = GetComponent<SpriteRenderer>();
      anim = GetComponent<Animator>();
    }

//Update? 프레임마다 재생되는 로직 작성
// 해당 로직은 인풋
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        
    }

    //FixedUpdate? 물리 연산 프레임마다 호출되는 생명주기 함수
    void FixedUpdate()
    {
        // //1.힘을 준다
        // rigid.AddForce(inputVec);

        // //2.속도제어
        // rigid.velocity = inputVec;

        //3.위치 이동
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed",inputVec.magnitude);

        if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
