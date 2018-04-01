using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetScores : MonoBehaviour {

	const string URL = "http://example.com";
	const string ACCESS_TOKEN = "very_secret_token";

	public Button _button;

	void Start() {
		_button.onClick.AddListener(wrapper);
	}

	void wrapper() {
		Debug.Log("CLICK");
		StartCoroutine(fetch());
	}
	
	IEnumerator fetch() {
		Debug.Log("Fetch");
		Dictionary<string, string> headers = new Dictionary<string,string>();
		headers.Add("authorization", ACCESS_TOKEN);
        WWW www = new WWW(URL, null, headers);

        yield return www;

		string data = JsonHelper.FixJson(www.text);

		Score[] scores = JsonHelper.FromJson<Score>(data);
		Debug.Log(scores[0]._id);
		Debug.Log(scores[0].createdAt);
		Debug.Log(scores[0].secret);
		Debug.Log(scores[0].name);
		Debug.Log(scores[0].score);
	}


}
