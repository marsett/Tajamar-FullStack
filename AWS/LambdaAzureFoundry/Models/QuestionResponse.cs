namespace LambdaAzureFoundry.Models
{
    public class QuestionResponse
    {
        public string Respuesta { get; set; }
        public int Completion_Tokens { get; set; }
        public int Prompt_Tokens { get; set; }
        public int Total_Tokens { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
