namespace BudgettingCore.Models
{
    public class ServerResult
    {
       public object Result { get; set; }
       public bool Succeeded { get; set; }
       public object Errors { get; set; }
    }
}
