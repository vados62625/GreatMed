using MotoHelp.Service;
using MotoHelp.Models;

namespace MotoHelp.Data
{
    public class DBObjects
    {
        public static void Inital (DBContent content)
        {

            //if (!content.MHService.Any())
            //{
            //    content.MHService.AddRange(GMServices.Select(c => c.Value));
            //}
            //if (!content.MHDetail.Any())
            //{
            //    content.MHDetail.AddRange(MHDetails.Select(c => c.Value));
            //}            
            if (!content.MHCategory.Any())
            {
                content.MHCategory.AddRange(MHDetailCategories.Select(c => c.Value));
            }
            if (!content.MHDetail.Any())
            {
                content.MHDetail.AddRange(MHDetails.Select(c => c.Value));
            }

            content.SaveChanges();

        }

        private static Dictionary<string, MHDetail> mHDetail;
        private static Dictionary<string, MHCategory> mhCategory;

        public static Dictionary<string, MHDetail> MHDetails
        { 
            
            get
            {
                if (mHDetail == null)
                {
                    var list = new MHDetail[]
                    {
                        new MHDetail
                        {
                            Name = "Мотосигнализация Anti-theft MX-PARTS",
                            Description = "Беспроводная сигнализации с пультом дистанционного управления. Простой в использовании и просты в установке, что делает его очень удобным\r\n\r\nКорпус: Пластмасса\r\n\r\nРежим тревоги: микро-вибрации\r\n\r\nРежим управления: Пульт Дистанционного беспроводного управления Громкость: ? 120DB\r\n\r\nПродолжительность каждого сигнала тревоги: 40s\r\n\r\nДиапазон управления: до 20 м\r\n\r\nМощность: 1 * 9В БАТАРЕИ GF22 DC 9 В батареи\r\n\r\nРазмеры: 85*54*24 мм\r\n\r\nПульт дистанционного управления размеры: 50*40*13 мм\r\n\r\nВ Комплект Поставки Входят:\r\n\r\n1 х Сигнализации\r\n\r\n1 х Пульт дистанционного управления\r\n\r\nНе входит в комплект:\r\n\r\n1 x 9В крона батарея для блока\r\n\r\n1 x 12V 23A для пульта",
                            MHCategory = MHDetailCategories["Аксессуары"],
                            Price = 1470,
                            InStock = 30,
                            IsActive = true
                        },
                        new MHDetail
                        {
                            Name = "Шина Michelin 120/70-17 ROAD 5 58W M/C TL Передняя (2019)",
                            Description = "Используя новейшие комбинированные технологии MICHELIN 2CT и 2CT +, а также последние поколения соединений и прорезиненные протекторы, шины MICHELIN Road 5 предлагают вам лучшую сцепление с мокрой по сравнению с ее основными конкурентами\r\n\r\n(Согласно внутренним исследованиям Fontange, испытательного трека Michelin под наблюдением независимого свидетеля, сравнивая шины MICHELIN Road 5 с METZELER Roadtec 01, DUNLOP Road Smart 3, CONTINENTAL Road Attack 3, шинами PIRELLI Angel GT и BRIDGESTONE T30 EVO в габаритах 120/70 ZR17 (спереди) и 180/55 / ??ZR17 (сзади) на Suzuki Bandit 1250.)\r\n\r\nБез компромиссов на сухих дорогах. (Внешние испытания, проведенные испытательным центром MTE, на которые ссылается Michelin, сравнивают шины MICHELIN Road 5 с MICHELIN Pilot Road 4, METZELER Roadtec 01, DUNLOP Road Smart 3, CONTINENTAL Road Attack 3, шины PIRELLI Angel GT и BRIDGESTONE T30 EVO, размеры 120 / 70 ZR17 (спереди) и 180/55 / ZR17 (сзади) на Kawasaki Z900, обеспечивающие наилучшую сухую производительность по всему миру и № 1 для обработки)",
                            MHCategory = MHDetailCategories["Колеса и шины"],
                            Price = 13500,
                            InStock = 10,
                            IsActive = true
                        },
                        new MHDetail
                        {
                            Name = "Двигатель в сборе ZS172FMM-5 (PR250) 249см3, возд. охл, электростартер, 5 передач с баланисровочным валом",
                            MHCategory = MHDetailCategories["Двигатели"],
                            Price = 63990,
                            InStock = 1,
                            IsActive = true
                        },
                        new MHDetail
                        {
                            Name = "Линза в алюминиевом корпусе (125W) синяя",
                            Description = "Водонепроницаемый корпус, линза разработана под экстремальные условия эксплуатации. 3 режима (дальний свет, ближний свет, мигающий). Очень яркая даже при дневном свете.\r\n\r\nФактическая мощность: 15W\r\nТемпература окружающей среды : -40 --- 40 градусов по Цельсию\r\nFlux: 3000LMW\r\nЦветовой температуры: 6000K - 7000K\r\nНапряжение: 12V -80V DC\r\nМатериал: алюминиевый сплав\r\nВес: 650 г",
                            MHCategory = MHDetailCategories["Фары"],
                            Price = 2660,
                            InStock=6,
                            IsActive = true
                        },
                        new MHDetail
                        {
                            Name = "Фара для мотоцикла галогеновая H4 35W SpeedPark MX12 зеленая",
                            MHCategory = MHDetailCategories["Фары"],
                            Price = 2730,
                            InStock=3,
                            IsActive = true
                        },
                        new MHDetail
                        {
                            Name = "Глушитель (тюнинг) 300x90mm, креп. d-48mm (нержавейка, змеиная кожа, прямоток)",
                            MHCategory = MHDetailCategories["Глушители"],
                            InStock = 4,
                            Price = 3843,
                            IsActive = true
                        },
                    };

                    mHDetail = new Dictionary<string, MHDetail>();
                    foreach (var item in list)
                    {
                        mHDetail.Add(item.Name, item);
                    }

                }

                return mHDetail;

            } 
        
        }
        public static Dictionary<string, MHCategory> MHDetailCategories
        {

            get
            {
                if (mhCategory == null)
                {
                    var list = new MHCategory[]
                    {
                        new MHCategory
                        {
                            Name = "Двигатели",
                            Description = "При выборе мото-двигателя обычно обращают внимание на мощность. Но помимо этого показателя есть ряд других важных критериев. В первую очередь, это тип топлива. Бывают бензиновые и электрические мото-двигатели.",
                            Url = "engines"
                        },
                        new MHCategory
                        {
                            Name = "Фары",
                            Description = "Поездка на мотоцикле в темное время суток может стать более комфортной и безопасной с правильным освещением, отвечающим международным требованиям и российским стандартам. От его выбора зависит площадь видимости окружающей местности, а значит насколько своевременно вы среагируете на опасность. Остановить свой выбор стоит на led оборудовании.",
                            Url = "lights"
                        },
                        new MHCategory
                        {
                            Name = "Колеса и шины",
                            Description = "Наиболее значимым условием для безопасной и комфортной езды на мотоцикле является хорошее сцепление с дорогой. Это транспортному средству обеспечивают качественные колеса на мотоцикл. Наш сайт может предложить Вам самый большой ассортимент дисков, камер, колес и покрышек для мотоциклов.",
                            Url = "wheels-and-tires"
                        },
                        new MHCategory
                        {
                            Name = "Глушители",
                            Description = "Выхлопная система мотоцикла служит для отвода отработавших газов из двигателя, которые образуются там в результате его работы. Снизить шум выброса газов позволяют стоковые глушители для мотоциклов. Но если Вы любите звук выхлопа погромче, то Вам подойдёт прямоточный глушитель. Глушители могут быть не только функциональными, но и могуть стать украшением для Вашего мотоцикла. Современные глушители изготавливаются любых цветов и различных форм.",
                            Url = "mufflers"
                        },
                        new MHCategory
                        {
                            Name = "Аксессуары",
                            Description = "Различные аксессуары для Вашей техники. Противоугонные системы, сумки багажные и рюкзаки, кофры для мотоциклов скутеров, квадроциклов, рюкзаки, сумки на бак, сувениры, чехлы для мототехники, подсветка, сетки багажные на сиденье.",
                        },
                    };

                    mhCategory = new Dictionary<string, MHCategory>();
                    foreach (var item in list)
                    {
                        mhCategory.Add(item.Name, item);
                    }

                }

                return mhCategory;

            }

        }

    }
}
