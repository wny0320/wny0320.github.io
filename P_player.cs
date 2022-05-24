using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class P_player : MonoBehaviour
{
    Vector3 pSize = new Vector3(1f, 1f, 0f);
    Vector3 pPosit = new Vector3(0f, 0f, 0f);
    float mainLong=1;
    Rigidbody2D rigid;
    Vector3 collpo = new Vector3(0f, 0f, 0f);
    float collSize=1f;
    string dir = null;
    enum direction
    {
        leftup=1, leftdown=2, rightup=3, rightdown=4
    }
    enum arrow
    {
        LeftArrow, RightArrow, UpArrow, DownArrow,
    }
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        playerMove();
    }

    void playerMove()
    {
/*        Direct();
        switch (dir)
        {
            case "leftup":
                if(pP)
                {

                }
                break;

            case "leftdown":


        }*/
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if()
            {
                pPosit += new Vector3(-mainLong / 2, 0, 0);
                pSize = pSize + new Vector3(mainLong, 0, 0);
            }
            else if(pSize.x<=1.2)
            {
                
            }
            else
            {
                pPosit += new Vector3(-mainLong / 2, 0, 0);
                pSize = pSize + new Vector3(-mainLong, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pPosit += new Vector3(mainLong / 2, 0, 0);
            pSize = pSize + new Vector3(mainLong, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pPosit += new Vector3(0, mainLong / 2, 0);
            pSize = pSize + new Vector3(0, mainLong, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pPosit += new Vector3(0, -mainLong / 2, 0);
            pSize = pSize + new Vector3(0, mainLong, 0);
        }
        transform.localScale = pSize;
        rigid.MovePosition(pPosit);
    }
    /*void pMoveLeft()
    {
        pSize = pSize + new Vector3(mainLong, 0, 0);
        pPosit += new Vector3(-mainLong/2, 0, 0);
    }
    void pMoveRight()
    {
        pSize = pSize + new Vector3(mainLong, 0, 0);
        pPosit += new Vector3(mainLong/2, 0, 0);
    }

    void pMoveUp()
    {
        pSize = pSize + new Vector3(0, mainLong, 0);
        pPosit += new Vector3(0, mainLong/2, 0);
    }

    void pMoveDown()
    {
        pSize = pSize + new Vector3(0, mainLong, 0);
        pPosit += new Vector3(0, -mainLong/2, 0);
    }*/
    //������ �Լ�ȭ
    void OnCollisionEnter2D(Collision2D collision)
    {
        collpo = gameObject.transform.position;
    }
    void Direct()
    {
        if (pPosit.x + pSize.x / 2 /*�÷��̾��� ������ �κ� */< collpo.x - collSize / 2 /*�浹 ������Ʈ�� ���� �κ�*/)
        {
            //��ü�� ���ʿ� �÷��̾ ��ġ
            if (pPosit.y - pSize.y / 2 /*�÷��̾��� �Ʒ� �κ�*/ > collpo.y + collSize / 2/*�浹 ������Ʈ�� ���� �κ�*/)
            {
                //��ü�� ���ʿ� �÷��̾ ��ġ
                dir = "leftup";
            }
            else
            {
                dir = "leftdown";
            }
        }
        else if (pPosit.y - pSize.y / 2 /*�÷��̾��� �Ʒ� �κ�*/ > collpo.y + collSize / 2/*�浹 ������Ʈ�� ���� �κ�*/)
        {
            dir = "rightup";
        }
        else
        {
            dir = "rightdown";
        }
    }
}
