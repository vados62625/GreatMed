using GreatMed.Service;

namespace GreatMed.Data
{
    public class DBObjects
    {
        public static void Inital (DBContent content)
        {
            
            if (!content.GMService.Any())
            {
                content.GMService.AddRange(GMServices.Select(c => c.Value));
            }

            content.SaveChanges();

        }

        private static Dictionary<string, GMService> gMService;

        public static Dictionary<string, GMService> GMServices 
        { 
            
            get
            {
                if (GMServices == null)
                {
                    var list = new GMService[]
                    {
                        new GMService {
                            Name = "Вакцинация от Covid19",
                            Description = "Вы можете записаться на процедуру и выбрать любую доступную вакцину",
                            Price = 1000,
                            IsActive = true
                        }
                        //new GMService { Name = "Вызов врача на дом", Description = "Вызовите врача, и он приедет в любое удобное для вас время" },
                        //new GMService { Name = "Медицинская страховка", Description = $"Оформите наш страховой медицинский полис и получите безлимитный доступ ко всем нашим услугам. Подробнее по телефону {Service.GMService.CompanyPhone}" },
                        //new GMService { Name = "Скорая помощь", Description = $"Для вызова нашей скорой помощи позвоните по номеру {Service.GMService.CompanyPhone}. Вызов бесплатный, вы оплачиваете только работу врачей" },
                        //new GMService { Name = "Запись к специалисту", Description = $"В нашей компании работают высококвалифицированные врачи, можете записаться на прием по телефону {Service.GMService.CompanyPhone}" },
                    };

                    gMService = new Dictionary<string, GMService>();
                    foreach (var item in list)
                    {
                        gMService.Add(item.Name, item);
                    }

                }

                return gMService;

            } 
        
        }

    }
}
