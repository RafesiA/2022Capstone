using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    ����: https://m.blog.naver.com/yoohee2018/220700239540
    ��������: object�� prefab���� ����, ����/���ڿ����� ���� ����ȭ, x�� 1/2/3�� Lane ����ȭ, �����߰�
 */
public class CSVConverter : MonoBehaviour
{
    public GameObject obj;
    public void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("Airplane"); //data�� 2���� �迭�� ���·� �����

        for (var i = 0; i < data.Count; i++)    //csv���� �б�
        {
            if ((int)(data[i]["Speed"]) != 0)   //speed==0 �� ��Ʈ�� ������ �ǹ�
            {
                Debug.Log("Note: " + data[i]["Note"] + "Time: " + data[i]["Time"]);
                newObject("Note"+i, 0,0, (int)(data[i]["Time"])/60);
            }
        }
    }

    public void newObject(string objName, int x, int y, int z)
    {
        GameObject Block = Instantiate (obj, new Vector3(x, y, z), Quaternion.identity) as GameObject;
    }
}
