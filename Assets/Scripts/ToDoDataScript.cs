using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO; // 파일 관련 처리를 위함
using UnityEngine.UI; // 유니티 UI를 사용하기 위함

public class ToDoDataScript : MonoBehaviour
{
    public ToDo toDoData;
    public Text toDoText;
    public string jsonString; // 테스트용@@@@@@@@@@@@

    private void Awake() // 게임시작하면 Json 데이터를 가져와 화면에 뿌려줌
    {
        LoadToDoDataFromJson();
        //toDoText.text = "내용 : " + toDoData.content + ", " + toDoData.month + "월 " + toDoData.day + "일";
        toDoText.text = jsonString; // 테스트용@@@@@@@@@@@@
    }

    [ContextMenu("To Json Data")] // 컴포넌트에 뒤따라오는 함수를 실행하는 메뉴 버튼을 만들어줌.
    void SaveToDoDataToJson()
    {
        // ToJson()은 json 문자열로 변형하고 싶은 오브젝트를 넣어주면 json 형태로 포맷팅된 문자열을 리턴함
        string jsonData = JsonUtility.ToJson(toDoData, true);

        string path = Path.Combine(Application.dataPath, "/MyUnityProjects/20WinterProjectOne/Assets/GameData/ToDoData.json"); // 파일 경로

        File.WriteAllText(path, jsonData); // 파일 저장
    }

    [ContextMenu("From Json Data")]
    void LoadToDoDataFromJson()
    {     
        string path = Path.Combine(Application.dataPath, "/MyUnityProjects/20WinterProjectOne/Assets/GameData/ToDoData.json"); 

        string jsonData = File.ReadAllText(path); // 파일 읽기

        // FromJson()은 json 데이터를 오브젝트로 Deserialization 역직렬화 함
        // 오브젝트로 복구시키려는 대상을 제네릭으로 명시함
        toDoData =  JsonUtility.FromJson<ToDo>(jsonData);

        jsonString = jsonData; // 테스트용@@@@@@@@@@@@
    }
}


// ToDo 정보를 저장할 컨테이너용 클래스
[System.Serializable] // Serializable 속성 선언
public class ToDo
{
    public string content;
    public string month;
    public string day;
}