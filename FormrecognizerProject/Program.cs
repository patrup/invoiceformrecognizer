using Azure;
using Azure.AI.FormRecognizer;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FormrecognizerProject
{
    public static class Program
    {

        private static readonly string endpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT"); //"PASTE_YOUR_FORM_RECOGNIZER_ENDPOINT_HERE";
        private static readonly string apiKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");//"PASTE_YOUR_FORM_RECOGNIZER_SUBSCRIPTION_KEY_HERE";
        private static readonly AzureKeyCredential credential = new AzureKeyCredential(apiKey);

        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                // new code:
                var recognizeContent = RecognizeContent(recognizerClient);
                Task.WaitAll(recognizeContent);

                var analyzeReceipt = AnalyzeReceipt(recognizerClient, receiptUrl);
                Task.WaitAll(analyzeReceipt);

                var analyzeBusinessCard = AnalyzeBusinessCard(recognizerClient, bcUrl);
                Task.WaitAll(analyzeBusinessCard);

                var analyzeInvoice = AnalyzeInvoice(recognizerClient, invoiceUrl);
                Task.WaitAll(analyzeInvoice);

                var analyzeId = AnalyzeId(recognizerClient, idUrl);
                Task.WaitAll(analyzeId);

                var trainModel = TrainModel(trainingClient, trainingDataUrl);
                Task.WaitAll(trainModel);

                var trainModelWithLabels = TrainModelWithLabels(trainingClient, trainingDataUrl);
                Task.WaitAll(trainModel);

                var analyzeForm = AnalyzePdfForm(recognizerClient, modelId, formUrl);
                Task.WaitAll(analyzeForm);

                var manageModels = ManageModels(trainingClient, trainingDataUrl);
                Task.WaitAll(manageModels);

            }
        }
        private static FormRecognizerClient AuthenticateClient()
        {
            var credential = new AzureKeyCredential(apiKey);
            var client = new FormRecognizerClient(new Uri(endpoint), credential);
            return client;
        }
        static private FormTrainingClient AuthenticateTrainingClient()
        {
            var credential = new AzureKeyCredential(apiKey);
            var client = new FormTrainingClient(new Uri(endpoint), credential);
            return client;
        }
    }
}
