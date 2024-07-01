namespace ChoppSoft.Infra.Bases
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; private set; }
        public object Entity { get; private set; }

        public static ServiceResult Successful()
        {
            return new ServiceResult()
            {
                Success = true,
                Errors = new List<string>(),
                Entity = null
            };
        }

        public static ServiceResult Successful(object entity)
        {
            return new ServiceResult()
            {
                Success = true,
                Errors = new List<string>(),
                Entity = entity
            };
        }

        public static ServiceResult Failed(string errorMessage, object entity = null)
        {
            return new ServiceResult()
            {
                Success = false,
                Errors = new List<string>() { errorMessage },
                Entity = entity
            };
        }

        public static ServiceResult Failed(List<string> errors, object entity = null)
        {
            return new ServiceResult()
            {
                Success = false,
                Errors = errors,
                Entity = entity
            };
        }
    }
}
