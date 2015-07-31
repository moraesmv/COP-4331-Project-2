using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SaveValuesToDb : MonoBehaviour 
{
	public InputField input;
	public string initials;
	public int level;

	
	public void SendToMongo () 
	{
		StartCoroutine(SendData());
	}

	IEnumerator SendData()
	{
		int time = PlayerPrefs.GetInt("PlayerTime");
		int score = PlayerPrefs.GetInt("PlayerScore");
		level = PlayerPrefs.GetInt("Level");


		string url = GetUrl(level);
		url +="?";
		url += "initials=" + initials;
		url += "&";
		url += "score=" + score.ToString();
		url += "&";
		url += "leveltime=" + time.ToString();

		//WWWForm form = new WWWForm();
		//form.AddField("initials", "mmm");
		//form.AddField("score", "999");
		//form.AddField("leveltime", "23");

		//string json_string = @"{'initials':'arb', 'score':5000, 'leveltime': 342}";

		// Upload to a cgi script
		//WWW ww = new WWW(url,)
		WWW w = new WWW(url);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) {
			Debug.Log(w.error);
		}
		else {
			Debug.Log("Finished Uploading");
		}
		Debug.Log("" + time + ", " + score + ", "+ level + ", "+ initials);
			
	}

	public void GetInitials()
	{
		input = InputField.FindObjectOfType<InputField>();
		initials = input.text;
	}

	public string GetUrl(int lv)
	{
		if (lv == 1)
		{
			return  "copstealth.herokuapp.com/api/add/1";
		}
		else if (lv == 2)
		{
			return  "copstealth.herokuapp.com/api/add/2";
		}
		else if (lv == 3)
		{
			return  "copstealth.herokuapp.com/api/add/3";
		}
		else if (lv == 4)
		{
			return  "copstealth.herokuapp.com/api/add/4";
		}
		else if (lv == 5)
		{
			return  "copstealth.herokuapp.com/api/add/5";
		}
		return "copstealth.herokuapp.com/api/add/1";
	}

}
	