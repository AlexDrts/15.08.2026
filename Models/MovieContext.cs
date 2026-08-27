using Microsoft.EntityFrameworkCore;

namespace mvc
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } 

        public MovieContext(DbContextOptions<MovieContext> options) 
            : base(options)
        {
            if (Database.EnsureCreated())
            {
                Movies.Add(new Movie
                {
                    Title = "Втеча з Шоушенка",
                    Director = "Френк Дарабонт",
                    Genre = "Драма",
                    ReleaseYear = 1994,
                    PosterPath = "https://uakino.best/uploads/post/The%20Shawshank%20Redemption/9NdY1WWLZKTjRAdDHrqWz4IdgdR.jpg",
                    Description = "Історія банкіра, несправедливо засудженого до довічного ув'язнення, і його шляху до свободи та надії."
                });
                Movies.Add(new Movie
                {
                    Title = "Шпигунський міст",
                    Director = "Стівен Спілберг",
                    Genre = "Історична драма / Трилер",
                    ReleaseYear = 2015,
                    PosterPath = "https://upload.wikimedia.org/wikipedia/uk/3/31/Bridge_of_Spies.jpg?utm_source=uk.wikipedia.org&utm_campaign=index&utm_content=original",
                    Description = "Адвокат Джеймс Донован отримує ризиковане завдання — захищати в суді радянського розвідника Рудольфа Абеля, а згодом веде таємні переговори про обмін полоненими на Глінікському мосту між Берліном і Потсдамом під час Холодної війни."
                });
                Movies.Add(new Movie
                {
                    Title = "Темний лицар",
                    Director = "Крістофер Нолан",
                    Genre = "Бойовик / Трилер",
                    ReleaseYear = 2008,
                    PosterPath = "https://ua-images.kinorium.com/movie/1080/352641.jpg?1742751548",
                    Description = "Бетмен протистоїть Джокеру - хаотичному злочинцю, який ставить під сумнів моральні межі Готема."
                });
                Movies.Add(new Movie
                {
                    Title = "Форд проти Феррарі",
                    Director = "Джеймс Менголд",
                    Genre = "Спортивна драма / Байопік",
                    ReleaseYear = 2019,
                    PosterPath = "https://upload.wikimedia.org/wikipedia/ru/e/ee/%D0%A4%D0%BE%D1%80%D0%B4_%D0%BF%D1%80%D0%BE%D1%82%D0%B8%D0%B2_%D0%A4%D0%B5%D1%80%D1%80%D0%B0%D1%80%D0%B8.jpg?utm_source=ru.wikipedia.org&utm_campaign=index&utm_content=original",
                    Description = "Автоконструктор Керролл Шелбі та безстрашний британський гонщик Кен Майлз об'єднуються, щоб створити для Ford революційний гоночний автомобіль, здатний перемогти непереможну команду Ferrari на легендарних перегонах \"24 години Ле-Мана\" 1966 року."
                });
                Movies.Add(new Movie
                {
                    Title = "Диво на Гудзоні",
                    Director = "Клінт Іствуд",
                    Genre = "Драма / Байопік",
                    ReleaseYear =2016,
                    PosterPath = "https://upload.wikimedia.org/wikipedia/ru/3/3a/%D0%A7%D1%83%D0%B4%D0%BE_%D0%BD%D0%B0_%D0%93%D1%83%D0%B4%D0%B7%D0%BE%D0%BD%D0%B5.jpg?utm_source=ru.wikipedia.org&utm_campaign=index&utm_content=original",
                    Description = "Реальна історія пілота Чеслі Салленбергера, який у січні 2009 року після зіткнення літака з зграєю птахів здійснив аварійну посадку пасажирського авіалайнера на річку Гудзон у Нью-Йорку, врятувавши життя всіх 155 людей на борту."
                });
                Movies.Add(new Movie
                {
                    Title = "Зелена миля",
                    Director = "Френк Дарабонт",
                    Genre = "Драма / Фентезі",
                    ReleaseYear = 1999,
                    PosterPath = "https://upload.wikimedia.org/wikipedia/uk/5/5e/Green_mile_%28%D0%97%D0%B5%D0%BB%D0%B5%D0%BD%D0%B0_%D0%BC%D0%B8%D0%BB%D1%8F%29.jpg?utm_source=uk.wikipedia.org&utm_campaign=index&utm_content=original",
                    Description = "Наглядач блоку смертників у в'язниці 1930-х років стає свідком незвичайного дару ув'язненого Джона Коффі — гіганта, звинуваченого у вбивстві, який насправді володіє здатністю зцілювати та відчувати чужий біль."
                });
                Movies.Add(new Movie
                {
                    Title = "Матриця",
                    Director = "Лана та Ліллі Вачовскі",
                    Genre = "Наукова фантастика",
                    ReleaseYear = 1999,
                    PosterPath = "https://upload.wikimedia.org/wikipedia/uk/f/f1/Matrix_poster.jpg?utm_source=uk.wikipedia.org&utm_campaign=index&utm_content=original",
                    Description = "Програміст дізнається, що реальність навколо нього - це симуляція, створена машинами."
                });
                Movies.Add(new Movie
                {
                    Title = "Топ Ган: Меверік",
                    Director = "Джозеф Косінскі",
                    Genre = "Бойовик / Драма",
                    ReleaseYear = 2022,
                    PosterPath = "https://upload.wikimedia.org/wikipedia/ru/7/7d/Top_Gun-_Maverick.jpg?utm_source=ru.wikipedia.org&utm_campaign=index&utm_content=original",
                    Description = "Легендарний пілот-винищувач Пiт \"Меверік\" Мітчелл повертається, щоб тренувати нове покоління курсантів для надскладної секретної місії, водночас протистоячи власним демонам минулого та тіні загиблого друга Гуся."
                });
                Movies.Add(new Movie
                {
                    Title = "Інтерстеллар",
                    Director = "Крістофер Нолан",
                    Genre = "Наукова фантастика / Драма",
                    ReleaseYear = 2014,
                    PosterPath = "https://upload.wikimedia.org/wikipedia/uk/2/29/Interstellar_film_poster2.jpg?utm_source=uk.wikipedia.org&utm_campaign=index&utm_content=original",
                    Description = "Група дослідників вирушає крізь червоточину в пошуках нового дому для людства."
                });
                Movies.Add(new Movie
                {
                    Title = "Пірати Карибського моря: Прокляття Чорної перлини",
                    Director = "Гор Вербінскі",
                    Genre = "Пригодницький фентезі-бойовик",
                    ReleaseYear = 2003,
                    PosterPath = "https://upload.wikimedia.org/wikipedia/uk/0/0e/Pirates_of_the_Caribbean_movie.jpg?utm_source=uk.wikipedia.org&utm_campaign=index&utm_content=original",
                    Description = "Ексцентричний пірат-капітан вирушає рятувати доньку губернатора, викрадену командою прокляттям приречених піратів, і об'єднується з молодим коваблем, який шукає власну помсту та кохання."
                });

                SaveChanges(); 
            }
        }
    }
}
