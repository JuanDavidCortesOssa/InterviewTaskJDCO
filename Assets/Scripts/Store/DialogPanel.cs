using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private SalesMan _salesMan;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    private List<string> _sentences;

    private Dialogue currentDialogue;

    private void Start()
    {
        _sentences = new List<string>();
        nameText.text = "";
        dialogueText.text = "";
        if (_salesMan != null) _salesMan.InitDialogue += StartDialogue;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        nameText.text = currentDialogue.name;

        _sentences.Clear();

        foreach (string s in currentDialogue.sentences) _sentences.Add(s);

        DisplaySentence();
    }

    private void DisplaySentence()
    {
        string s = _sentences[Random.Range(0, _sentences.Count - 1)];

        StopAllCoroutines();
        StartCoroutine(Type(s));
    }

    private IEnumerator Type(string s, bool goodbye = false)
    {
        dialogueText.text = "";
        foreach (char l in s)
        {
            scrollRect.verticalNormalizedPosition = 0;
            dialogueText.text += l;
            yield return new WaitForSeconds(0.05f);
        }

        if (goodbye)
        {
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void EndDialogue(bool accept)
    {
        if (accept)
        {
        }
        else
        {
            string s = currentDialogue.sentences[Random.Range(0, currentDialogue.sentences.Count - 1)];
            StopAllCoroutines();
            StartCoroutine(Type("", true));
        }
    }

    private void OnDestroy()
    {
        if (_salesMan != null) _salesMan.InitDialogue -= StartDialogue;
    }
}