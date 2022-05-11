using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{

    public AudioSource audioSource;
    static int index;
    private GameObject Beatsmap; //= GameObject.Find("Beatsmap"); 
    public void SetBeforeRun()
    {
        Beatsmap = GameObject.Find("Beatsmap");
        //5������ �ǳ� �� ��(�ǳ� 5���� ���� ����)
        for (index = 5; index < Beatsmap.transform.childCount; index++) 
        {
            Beatsmap.transform.GetChild(index).gameObject.SetActive(false);
        }
        index = 5;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
          audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //�ǳ� 1���� ���� ���� �ǳ��� Ű��
        Beatsmap = GameObject.Find("Beatsmap");
        Beatsmap.transform.GetChild(index-5).gameObject.SetActive(false);
        if (index < Beatsmap.transform.childCount)  //�ε��� �ʰ� ����
        {
            Beatsmap.transform.GetChild(index++).gameObject.SetActive(true);
        }
    }
}