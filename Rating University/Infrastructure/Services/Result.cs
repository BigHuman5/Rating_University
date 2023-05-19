namespace Rating_University.Infrastructure.Services
{
    public class Result
    {
        public bool Success { get; set; }

        public bool Failure => !this.Success;

        public string Message { get; set; }

        public static implicit operator Result(bool succeede) =>
            new Result { Success = succeede };

        public static implicit operator Result(string error) =>
            new Result
            {
                Success = false,
                Message = error
            };
    }
}
