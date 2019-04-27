using System.Collections.Generic;

namespace TextAnalyzer.Interfaces
{
	public interface IQueueService
	{
		void InsertAnswerIntoCRM(object response);
		void SendToMachineLearningQueue(IEnumerable<string> keyPhrases);
	}
}