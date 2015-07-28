using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SaveValuesToDb : MonoBehaviour 
{
	public InputField input;
	public string initials;
	public int level;

	
	public void SendToMongo () 
	{
		int time = PlayerPrefs.GetInt("PlayerTime");
		int score = PlayerPrefs.GetInt("PlayerScore");
		level = PlayerPrefs.GetInt("Level");


		string url = GetUrl(level);




//		var jsonString = "{ Initials:" + initials + ", Score:" + score + ", LevelTime:" + time + "}";
//		
//		var encoding = new System.Text.UTF8Encoding();
//		var postHeader = new Hashtable();
//		
//		postHeader.Add("Content-Type", "text/json");
//
//		print("jsonString: " + jsonString);
//		
//		WWW www = new WWW(url, encoding.GetBytes(jsonString), postHeader);
//		


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
			return  "copstealth.herokuapp.com/api/1";
		}
		else if (lv == 2)
		{
			return  "copstealth.herokuapp.com/api/2";
		}
		else if (lv == 3)
		{
			return  "copstealth.herokuapp.com/api/3";
		}
	}

}
	