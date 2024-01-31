using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Blink : MonoBehaviour
{
	Text flashingText;

	// Use this for initialization
	void Start()
	{
		flashingText = GetComponent<Text>();
		StartCoroutine(BlinkText());
	}

	public IEnumerator BlinkText()
	{
		while (true)
		{
			flashingText.text = "";
			yield return new WaitForSeconds(0.5f);
			flashingText.text = "START";
			yield return new WaitForSeconds(0.5f);
		}
	}
}