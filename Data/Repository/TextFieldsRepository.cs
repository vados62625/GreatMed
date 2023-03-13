using Microsoft.EntityFrameworkCore;
using MotoHelp.Data.Interfaces;
using MotoHelp.Models;

namespace MotoHelp.Data.Repository
{
    public class TextFieldsRepository : ITextFieldsRepository
    {
        private readonly DBContent dbContent;
        public TextFieldsRepository(DBContent dBContent) {
            this.dbContent = dBContent;
        }
        public IEnumerable<TextField> TextFields => dbContent.TextFields.Include(c => c.TitlePictire);

        public void Edit(TextField textField)
        {
            if (textField.Id == default) 
            {
                dbContent.Entry(textField).State= EntityState.Added;
            }
            else
            {
                dbContent.Entry(textField).State= EntityState.Modified;
            }
            var picture = textField.TitlePictire;
            if (picture != null)
            {
                if (picture.Id == default)
                {
                    dbContent.Entry(picture).State = EntityState.Added;
                }
                else
                {
                    dbContent.Entry(picture).State = EntityState.Modified;
                }
            }
            dbContent.SaveChanges();
        }

        public TextField GetTextFieldByPageName(string pageName) => TextFields.FirstOrDefault(c => c.Name == pageName);
    }
}
