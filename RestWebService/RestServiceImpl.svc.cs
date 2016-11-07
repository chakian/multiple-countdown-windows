namespace RestWebService
{
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestServiceImpl.svc or RestServiceImpl.svc.cs at the Solution Explorer and start debugging.
    public class RestServiceImpl : IRestServiceImpl
    {
        public string GetAllCountdowns(string id)
        {
            return "test deneme";
        }
    }
}
