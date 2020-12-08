using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 유니티 UI를 사용하기 위함


public class UIManage : MonoBehaviour
{
    List<ToDo> toDoList;

    public Button button1;
    public Button button2;
    public Button button3;


    // Start is called before the first frame update
    void Start()
    {
        toDoList = GameObject.Find("DataManager").GetComponent<DataManage>().toDoList;

         
        button1.GetComponentInChildren<Text>().text = toDoList[0].content;
        if(toDoList[0].completion)
        {
            button1.GetComponent<Image>().color = Color.red;
        }

        button2.GetComponentInChildren<Text>().text = toDoList[1].content;
        if (toDoList[1].completion)
        {
            button2.GetComponent<Image>().color = Color.red;
        }

        button3.GetComponentInChildren<Text>().text = toDoList[2].content;
        if (toDoList[2].completion)
        {
            button3.GetComponent<Image>().color = Color.red;
        }

    }

}
