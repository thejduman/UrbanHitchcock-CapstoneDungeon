using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private DialogueUI dialogueUI;

    private List<GameObject> tempResponseButtons = new List<GameObject>();

    private void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();
    }
    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0;

        foreach(Response response in responses)
        {
            GameObject repsonseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            repsonseButton.gameObject.SetActive(true);
            repsonseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            repsonseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response));
        
            tempResponseButtons.Add(repsonseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }

    private void OnPickedResponse(Response response)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons)
        {
            Destroy(button);
        }
        tempResponseButtons.Clear();

        dialogueUI.ShowDialogue(response.DialogueObject);
    }
}
