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
    public GameObject panel;    //prefab
    public Transform beatMapTransform;

    #region Initializing section
    public void Init()
    {
        int panelindex = 1;
        List<Dictionary<string, object>> data = CSVReader.Read("Airplane"); //data�� 2���� �迭�� ���·� �����
        for (var i = 0; i < data.Count; i++)    //csv���� �б�
        {
            if ((int)(data[i]["Speed"]) != 0)   //speed==0 �� ��Ʈ�� ������ �ǹ�
            {
                Debug.Log("Note: " + data[i]["Note"] + "Time: " + data[i]["Time"]);

                var obj = Instantiate(panel, new Vector3(0, 0, (int)data[i]["Time"] / 60), Quaternion.identity, beatMapTransform);
                obj.name = "panel" + panelindex;
                var child = obj.GetComponent<Transform>().Find("p");
                child.name = "p" + panelindex;
                panelindex++;
            }
        }
    }

    public void Bind()
    {
        
    }
    #endregion

}
