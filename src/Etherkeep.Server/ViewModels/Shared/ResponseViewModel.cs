using Etherkeep.Server.ViewModels.Shared;

namespace Etherkeep.Server.ViewModels.Shared
{
    public class ResponseViewModel<T>
    {
        public ResponseViewModel(T result)
        {
            this.Result = result;
        }

        public T Result { get; set; }
        public bool Success
        {
            get
            {
                return !(Result is ErrorViewModel);
            }
        }
    }
}
