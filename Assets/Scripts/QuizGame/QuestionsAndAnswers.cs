[System.Serializable]

public class QuestionsAndAnswers
{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer; 

  public string question   // property
  {
    get { return Question; }   // get method
    set { Question = value; }  // set method
  }

  public string[] answers
  {
    get { return Answers; }   // get method
    set { Answers = value; } 
  }

}
