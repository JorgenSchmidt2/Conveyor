namespace ConveyorUtility.Bunker.Core.Responses
{
    public class ObjectResponse<T>
    {
        public bool Status { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
    }
}