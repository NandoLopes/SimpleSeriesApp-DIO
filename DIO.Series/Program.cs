using DIO.Series.Enum;

namespace DIO.Series
{
    public class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserSelection();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        ShowSeriesDetails();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Select a valid option!");
                        break;
                }
                userOption = GetUserSelection();
            }

            Console.WriteLine("Thank you for using Nandoflix!");
            Console.ReadLine();
        }

        private static void ListSeries()
        {
            Console.WriteLine("List Series");

            var lista = repository.Listed();

            if (lista.Count == 0)
            {
                Console.WriteLine("No series to show.");
                return;
            }

            foreach (var serie in lista)
            {
                string serieString = $"#ID {serie.getId()} - {serie.getTitle()}, {serie.getYear()}";

                if(serie.returnDeletionStatus()){
                    serieString += " [DELETED]";
                }
                Console.WriteLine(serieString);
            }
        }

        private static void InsertSeries()
        {
            Console.WriteLine("Insert new series");

            var newSeries = InsertSeriesData(-1);

            repository.Create(newSeries);
        }

        private static void UpdateSeries(){
            int seriesIndex = SelectSeries();

            var newSeries = InsertSeriesData(seriesIndex);

            repository.Update(seriesIndex, newSeries);
        }

        private static void ShowSeriesDetails(){
            int seriesIndex = SelectSeries();
            
            var series = repository.GetById(seriesIndex);

            Console.WriteLine(series);
        }

        private static void DeleteSeries(){
            Console.WriteLine("Delete series");
            int seriesIndex = SelectSeries();

            repository.ChangeDeletion(seriesIndex, DeletionStatusEnum.Delete);

            Console.WriteLine("The show was deleted.");
        }

        private static string GetUserSelection()
        {
            Console.WriteLine();
            Console.WriteLine(@"Select the desired option:
    1 - List series
    2 - Insert new series
    3 - Update series
    4 - Delete series
    5 - Show series details
    C - Clean screen
    X - Exit
    ");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

        private static Series InsertSeriesData(int IdSeries){
            int id;
            if (IdSeries == -1){
                id = repository.NextId();
            } else {
                id = IdSeries;
            }

            foreach (int seriesId in GenreEnum.GetValues(typeof(GenreEnum)))
            {
                Console.WriteLine("{0} - {1}", seriesId, GenreEnum.GetName(typeof(GenreEnum), seriesId));
            }

            Console.Write("Type the option from a genre above: ");
            int typedGenre = int.Parse(Console.ReadLine());

            Console.Write("Type the title: ");
            string typedTitle = Console.ReadLine();

            Console.Write("Type the year the series was launched: ");
            int typedYear = int.Parse(Console.ReadLine());

            Console.Write("Type the synopsis: ");
            string typedSynopsis = Console.ReadLine();

            return new Series(
                    Id: id,
                    Genre: (GenreEnum)typedGenre,
                    Title: typedTitle,
                    Year: typedYear,
                    Synopsis: typedSynopsis
                );
        }

        private static int SelectSeries(){
            Console.Write("Select the series Id: ");
            return int.Parse(Console.ReadLine());
        }
    }
}