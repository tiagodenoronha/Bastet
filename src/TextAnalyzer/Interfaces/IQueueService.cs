namespace TextAnalyzer.Interfaces
{
	public interface IQueueService
	{
		void InsertKeywordAndSentimentoIntoCRM(object response);
		void InsertAnswerIntoCRM(object response);
	}
}