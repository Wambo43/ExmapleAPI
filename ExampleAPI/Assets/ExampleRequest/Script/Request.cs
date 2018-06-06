using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Request : MonoBehaviour {
    //private string mURL = "http://api.steampowered.com/ISteamNews/GetNewsForApp/V0002/?appid=440&count=3&maxlenth=300&format=json";
    private string mURL = "http://localhost:49915/api/Default";
    //private string mURL = "http://10.90.11.80/api/Default";


    private User person;

    private void Awake()
    {
        person = GetComponent<User>();
    }



    void Start () {
        StartCoroutine(GetText());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static User.Wrapper<T> CreateFromJSON<T>(string jsonString)
    {
        jsonString = "{\"Items\":" + jsonString + "}";
        return JsonUtility.FromJson<User.Wrapper<T>>(jsonString);
    }


    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(mURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text.ToString());
            string jsonString = www.downloadHandler.text.ToString();
            // Or retrieve results as binary data
            User.Wrapper<User.Person> a;
            if (www.downloadHandler.isDone)
            {
                a = CreateFromJSON<User.Person>(jsonString);
            }
            Debug.Log(jsonString);

        }
    }
}
