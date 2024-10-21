
using System.Text.RegularExpressions;

namespace C_Course.zad01
{
    class Game
    {
        public Hero Hero { get; set; }
        readonly List<Location> Locations;
        DialogParser? NameParser;
        static bool ValidateName(string name)
        {
            name = name.Replace(" ", "");
            if (name.Length < 2) return false;
            if (!name.All(char.IsLetter)) return false;
            return true;
        }
        static bool Exit(char val)
        {
            return val == 'X' || val == 'x';
        }

        public static string ToFirstUpper(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }


        static int ProcessPlayerChoice(int upperBound, int lowerBound = -1)
        {

            while (true)
            {
                char temp = Console.ReadKey(true).KeyChar;
                if (Exit(temp))
                    Environment.Exit(0);
                try
                {
                    int choice = int.Parse(temp.ToString()) - 1;
                    if (choice < upperBound && choice > lowerBound)
                        return choice;
                    else Console.WriteLine("Wybierz poprawna opcje");
                }
                catch (FormatException) { Console.WriteLine("Wybierz poprawna opcje"); }

            }

        }

        static void TalkTo(NonPlayerCharacter npc, DialogParser parser)
        {
            Console.Clear();
            List<HeroDialogPart>? responses = npc.NpcDialogPartStartTalking(parser);
            NpcDialogPart? npcResponse;

            while (true)
            {
                for (int i = 0; i < responses.Count; i++)
                {
                    Console.WriteLine($"[{i+1}] {parser.ParseDialog(responses[i])}");
                }

                int choice = ProcessPlayerChoice(responses.Count);
                Console.Clear();
                npcResponse = responses[choice].Response;

                if (npcResponse == null)
                {
                    Console.WriteLine(parser.ParseDialog(responses[choice]));
                    break;
                }

                Console.WriteLine(parser.ParseDialog(npcResponse));

                if (npcResponse.Responses == null)
                    break;

                responses = npcResponse.Responses;
            }
            Console.WriteLine("\nWcisnij dowolny przycisk");
            Console.ReadKey(true);
        }

        static void ShowLocation(Location location)
        {
            Console.WriteLine("Znajdujesz sie w: " + location.Name + ". Co chcesz zrobic?");
            for (int i = 0; i < location.Characters.Count; i++)
                Console.WriteLine($"[{i + 1}] Porozmawiaj z {location.Characters[i].Name}");
            Console.WriteLine("[X] Zamknij program");
        }


        void SetHeroClass()
        {
            Console.Clear();
            Console.WriteLine("Witaj " + Hero.Name + ", wybierz swoja klase");
            int availableClasses = Enum.GetNames(typeof(EHeroClass)).Length;

            for (int i = 0; i < availableClasses; i++)
                Console.WriteLine(i + 1 + ". " + (EHeroClass)i);

            Hero.Class = (EHeroClass)ProcessPlayerChoice(availableClasses);
        }

        void SetHeroName()
        {
            Console.Clear();
            Console.WriteLine("Wpisz swoje imie");
            string name;
            while (true)
            {
                name = Console.ReadLine().Trim();
                name = Regex.Replace(name, @"\s+", " ");
                if (ValidateName(name))
                    break;
                else
                {
                    Console.WriteLine("Nazwa nieprawidlowa\n" +
                        "Nazwa moze zawierac jedynie znaki alfabetu, oraz musi zawierac co najmniej 2 niepuste znaki");
                }
            }
            Hero.Name = name;

        }
        void CreateHero()
        {
            SetHeroName();
            SetHeroClass();
        }
        void MainScreen()
        {
            Location currentLocation = Locations[0];
            while (true)
            {
                ShowLocation(currentLocation);
                int choice = ProcessPlayerChoice(currentLocation.Characters.Count);
                TalkTo(currentLocation.Characters[choice], NameParser);
                Console.Clear();
                //Location change
            }
        }
        public void Start()
        {
            Console.WriteLine("Witaj w grze Droga Wygnańca");
            Console.WriteLine("[1] Zacznij nową grę\n[X] Zamknij Program");
            ProcessPlayerChoice(1);
            Console.Clear();
            CreateHero();
            NameParser = new(Hero);
            Console.Clear();
            Console.WriteLine(ToFirstUpper(Hero.Class.ToString()) + " " + Hero.Name + " zaczyna swoja przygode");
            MainScreen();
        }
        public Game()
        {
            Hero = new();
            List<HeroDialogPart> heroDialogParts = [new("Rozszczepienie"), new("Oczyszający Plomień"), new("Uderzenie Grzechotnika"),
                new("Czego chcesz?"), new("Idz do diabla"), new("Pomoge ci"), new("Radz sobie sam")];
            List<NpcDialogPart> npcDialogParts = [
                new("Widziałam #HERONAME#, co zrobiłeś z Hillockiem. W Oriath obawiałabym się ciebie, tutaj nie mam takiego luksusu.\n" +
                "Weź jeden z tych klejnotów umiejętności. Będziesz go potrzebować.", heroDialogParts.GetRange(0, 3)),
                new("Wojownik, który zostanie przetestowany i zahartowany w cieśninach Wraeclast.\n" +
                "To pierwsza linia wiersza, który piszę o tobie, #HERONAME#.\n" +
                "Nazywam się Bestel, jestem kapitanem statku „Wesoła Mewa”. Niestety, moja Mewa przepadła. Moja załoga odeszła.\n" +
                "Ale mój rozum jeszcze pozostał...", heroDialogParts.GetRange(3,2)),
                new("W pobliżu Tarasów znajduje się wyspa. To tam moja Wesola Mewa osiadła na mieliźnie.\n" +
                "Patrzyłem, jak miejscowi opluwają lekarza okrętowego, ale jego apteczka może wciąż tam być, wśród drzazg i kości.\n" +
                "Jest w niej wszystko, czego Nessa może potrzebować.\n" +
                "Doktor \"Drżące Ręce\" Opden kiepsko radził sobie ze skalpelem, a jeszcze gorzej z piłą... ale znał się na aptekarstwie.\n" +
                "To tłumaczy jego trzęsące się ręce. Odzyskasz ja dla mnie #HERONAME#?")
                ];
            heroDialogParts[3].Response = npcDialogParts[2];
            npcDialogParts[2].Responses = heroDialogParts.GetRange(5, 2);
            NonPlayerCharacter Nessa = new("Nessa", npcDialogParts[0]);
            NonPlayerCharacter Bestel = new("Bestel", npcDialogParts[1]);
            Locations = [new Location("Lioneye's Watch", Bestel, Nessa)];

        }
    }
}
