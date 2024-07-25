using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
		int level = PlayerPrefs.GetInt("Level", 1);
		//print(level);
		for(int i = 0; i < buttons.Length; i++)
		{
			buttons[i].interactable = level >= i + 1;
		}
    }
	
	public void ResetLevels()
	{
		PlayerPrefs.SetInt("Level", 1);
		Start();
	}
}
