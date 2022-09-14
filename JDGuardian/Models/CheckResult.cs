namespace JDGuardian.Models
{
    public class CheckResult
    {
        public bool Is { get; set; }
        public string Message { get; set; }
        public WareBusiness WareBusiness { get; set; }

        public static CheckResult CreateErro(string msg)
        {
            return new CheckResult() { Is = false, Message = msg };
        }
    }
}
