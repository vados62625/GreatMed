using MotoHelp.Data.Interfaces;

namespace MotoHelp.Data
{
    public class DataManager
    {
        public DataManager(ICallsRepository callsRepository, IGetDetails getDetails, IGetServices getServices, IGetDetailCategories categories, IImagesRepository imagesRepository, ITextFieldsRepository textFieldsRepository)
        {
            CallsRepository = callsRepository;
            GetDetails = getDetails;
            GetServices = getServices;
            GetDetailCategories = categories;
            ImagesRepository = imagesRepository;
            TextFieldsRepository = textFieldsRepository;
        }
        public ICallsRepository CallsRepository { get; set; }
        public IGetDetails GetDetails { get; set; }
        public IGetDetailCategories GetDetailCategories { get; set; }
        public IGetServices GetServices { get; set; }
        public IImagesRepository ImagesRepository { get; set; }
        public ITextFieldsRepository TextFieldsRepository { get; set; }
    }
}
