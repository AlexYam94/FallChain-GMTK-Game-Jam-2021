using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : Singleton<SceneFader> {

	[SerializeField]
	private GameObject fadePanel;

	[SerializeField]
	private Animator fadeAnim;

	public void LoadLevel(string level){
		StartCoroutine (FadeInOur(level,0));
	}
	
	public void LoadLevel(int index){
		StartCoroutine (FadeInOur("", index));
	}

	IEnumerator FadeInOur(string level, int index){
		fadePanel.SetActive (true);
		fadeAnim.Play ("FadeIn");
		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds (1f));
		if(!level.Equals(""))
			SceneManager.LoadScene (level);
		else
			SceneManager.LoadScene(index);
		fadeAnim.Play ("FadeOut");
		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds (1f));
		fadePanel.SetActive (false);
	}

}
