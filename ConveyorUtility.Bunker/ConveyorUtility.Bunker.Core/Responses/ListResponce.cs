using ConveyorUtility.Bunker.Core.Enitites;

namespace ConveyorUtility.Bunker.Core.Responses
{
    public class ListResponce<T>
    {
        public bool Status { get; set; }
        public List<T> ObjectList { get; set; }
        public string Message { get; set; }
    }
}