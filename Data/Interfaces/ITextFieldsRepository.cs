using MotoHelp.Models;

namespace MotoHelp.Data.Interfaces
{
    public interface ITextFieldsRepository
    {
        public TextField GetTextFieldByPageName(string pageName);
        public IEnumerable<TextField> TextFields { get; }
        public void Edit(TextField textField);
    }
}
