using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour {

	private Queue<string> sentences;

	public Text NameText;
	public Text DialogueText;
	public Animator animator;
	void Start () {
		sentences = new Queue<string> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (dialogueActive && Input.GetKeyDown (KeyCode.X)) {
			dBox.SetActive (false);
			dialogueActive = false;
		
		}*/
	}
	public void StartDialogue(Dialogue dialogue)
	{
		animator.SetBool ("IsOpen", true);
		NameText.text = dialogue.name;
		Debug.Log ("Starting Conversation with " + dialogue.name);
		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) 
		{
			sentences.Enqueue (sentence);
		}
		DisplayNextSentence ();
	}
	public void DisplayNextSentence()
	{
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}
		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		DialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			DialogueText.text += letter;
			yield return null;
		}
	}
	public void EndDialogue ()
	{
		animator.SetBool ("IsOpen", false);
	}

}
