using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    public GameManager manager;
    bool isJump;
    Rigidbody rigid;
    public List<Vector3> points = new List<Vector3>();
    private int currentLocation = 0;
    bool hasKeyDown = false;

    public float moveSpeed;    //�̵��ӵ�(z��)
    private float rotateSpeed = 300.0f;  //ȸ���ӵ�

    private void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        GameObject panel;
        Transform panelTransform;
        Vector3 panelPosition;

        // �ʱ� ���� ��ġ
        points.Add(this.gameObject.transform.position);

        // ������ �г��� ���� ����Ʈ�� �߰�, i <= panel
        for (int i = 1; i <= 27; i++)
        {
            panel = GameObject.Find("p" + i.ToString());
            panelTransform = panel.transform;
            panelPosition = panelTransform.position;
            panelPosition.y = 0;
            points.Add(panelPosition);
        }
    }
    // JŰ �Է� �� ��� (�ӽ�)
    private void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.J)) currentLocation++;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && hasKeyDown == false)
        {
            hasKeyDown = true;
        }
        if (hasKeyDown == true)
        {
            checkInput();
            // Debug.Log("Moving to: " + points[currentLocation].ToString());
            transform.position = Vector3.MoveTowards(transform.position, points[currentLocation], Time.deltaTime * 3);
        }
        // ������ �г� ��ġ Ȯ���ϱ�
        if(Input.GetKeyDown(KeyCode.B)){
            Debug.Log("Current list number is: " + currentLocation);
        }

        //������Ʈ ȸ��(x��)
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;

        if (collision.gameObject.tag == "Item")
        {
            itemCount++;
            manager.GetItem(itemCount);
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Way Point")
        {
            currentLocation++;
        }
        
        if (other.tag == "Finish")
        {
            if (itemCount == manager.totalItemCount)
            {
                //Game Clear!
                if (manager.stage == 1)
                    SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(manager.stage + 1);
            }
            else
            {
                //Restart..
                SceneManager.LoadScene(manager.stage);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "wp")
        {
            Debug.Log("You are Leaving at: " + currentLocation);
        }
        
    }
}
