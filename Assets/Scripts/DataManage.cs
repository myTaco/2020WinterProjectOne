﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO; // 파일 관련 처리를 위함


public class DataManage : MonoBehaviour
{
    public List<ToDo> toDoList = new List<ToDo>();


    private void Awake()
    {
        //toDoList.Add(new ToDo("양파 사오기", false));
        //toDoList.Add(new ToDo("감자 사오기", false));
        //toDoList.Add(new ToDo("달팽이 밥주기", true));

        //SaveDataToJson();


        LoadDataFromJson();
    }

    void SaveDataToJson()
    {
        // 파일 경로
        string path = Path.Combine(Application.dataPath, "/MyUnityProjects/20WinterProjectOne/Assets/GameData/ToDoData.json"); 

        string jsonData = "{\"todolist\":[";
        for (int i = 0; i < toDoList.Count; ++i)
        {
            jsonData += "{\"content\":\"" + toDoList[i].content + "\",\"completion\":\"" + toDoList[i].completion + "\"}";
            if(i!=toDoList.Count-1)
            {
                jsonData += ",";
            }
        }
        jsonData += "]}";

        File.WriteAllText(path, jsonData); // 파일 저장
    }

    void LoadDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "/MyUnityProjects/20WinterProjectOne/Assets/GameData/ToDoData.json");
        string jsonString = File.ReadAllText(path);

        // json 파일의 todolist 부분 제거
        jsonString = jsonString.Replace("{\"todolist\":[", "");
        jsonString = jsonString.Replace("]}", "");

        // { 를 기준으로 나눔
        string[] array = jsonString.Split('{');

        for (int i = 1; i < array.Length; ++i) // 0번째 요소는 공백임
        {
            // 배열 요소를 정돈함
            array[i] = "{" + array[i];
            if(array[i][array[i].Length-1]==',')
            {
                array[i] = array[i].Substring(0, array[i].Length - 1);            
            }
            
            // ToDo 객체로 만들어서 리스트에 추가
            toDoList.Add(JsonUtility.FromJson<ToDo>(array[i]));
        }      
    }
}


// ToDo 정보를 저장할 컨테이너용 클래스
[System.Serializable] // Serializable 속성 선언
public class ToDo
{
    public string content;
    public bool completion;

    public ToDo(string content, bool completion)
    {
        this.content = content;
        this.completion = completion;
    }


    public void show()
    {
        Debug.Log(content);
        Debug.Log(completion);
    }
}