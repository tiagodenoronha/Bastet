using System.Collections.Generic;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer
{
	public class QueueService : IQueueService
	{
		public void InsertAnswerIntoCRM(object response) => throw new System.NotImplementedException();
		public void SendToMachineLearningQueue(IEnumerable<string> keyPhrases) => throw new System.NotImplementedException();
	}
}