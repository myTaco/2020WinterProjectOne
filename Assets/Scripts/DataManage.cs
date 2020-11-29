using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO; // 파일 관련 처리를 위함
using UnityEngine.UI; // 유니티 UI를 사용하기 위함

public class DataManage : MonoBehaviour
{
    ToDo[] toDoData;
    public string jsonString;

    private void Awake()
    {
        toDoData = new ToDo[2];

        toDoData[0].content = "양파 사오기";
        toDoData[0].month = "11";
        toDoData[0].month = "25";

        toDoData[1].content = "감자 사오기";
        toDoData[1].month = "11";
        toDoData[1].month = "26";

        SaveDataToJson();
    }

    void SaveDataToJson()
    {
        // ToJson()은 json 문자열로 변형하고 싶은 오브젝트를 넣어주면 json 형태로 포맷팅된 문자열을 리턴함
        string jsonData = JsonUtility.ToJson(toDoData, true);

        string path = Path.Combine(Application.dataPath, "/MyUnityProjects/20WinterProjectOne/Assets/GameData/ToDoData.json"); // 파일 경로

        File.WriteAllText(path, jsonData); // 파일 저장
    }

    void LoadDataFromJson()
    {     
        string path = Path.Combine(Application.dataPath, "/MyUnityProjects/20WinterProjectOne/Assets/GameData/ToDoData.json"); 
        string jsonString = File.ReadAllText(path);
    }

    void StringToArray()
    {

    }
}


// ToDo 정보를 저장할 컨테이너용 클래스
public class ToDo
{
    public string content;
    public string month;
    public string day;
}