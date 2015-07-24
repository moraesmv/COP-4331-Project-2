using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyChangeableText : MonoBehaviour {
	public Text instruction;
	
	void Start()
	{
		instruction = GetComponent<Text>();
	}
	
	public void ChangeMyText(string NewText)
	{
		instruction.text=NewText;
	}
	
}