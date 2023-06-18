// See https://aka.ms/new-console-template for more information
using Models.DataAccessLayer;
using Models.Models;

//string URL = "http://localhost:51756/api/Osoba/";
//OsobaDAL osobaDAL = new OsobaDAL(URL);
OsobaDAL osobaDAL = new OsobaDAL();
int ponovi = 0;
do
{
    Console.WriteLine("-------------------MENI-------------------\n" +
    "0. Citaj sve Osobe\n" +
    "1. Citaj osobu po id\n" +
    "2. Dodaj osobu\n" +
    "3. Izmjeni podatke osobi\n" +
    "4. Izbrisi osobu po id\n" +
    "Broj: ");
    int meni = int.Parse(Console.ReadLine());
    switch (meni)
    {
        case 0:
            List<Osoba> osobe = osobaDAL.GetAllAsync().Result;
            foreach (var osobax in osobe)
            {
                Console.WriteLine("Id: " + osobax.Id.ToString() + " Osoba: " + osobax.Ime + " " + osobax.Prezime);
            }
            break;
        case 1:
            Console.WriteLine("Unesite osobu id: ");
            int osobaId = int.Parse(Console.ReadLine());

            Osoba osobax2 = osobaDAL.GetByIdAsync(osobaId).Result;
            if (osobax2 == null)
                Console.WriteLine("Nisam pronasao osobu!\n");
            else
                Console.WriteLine("Id: " + osobax2.Id.ToString() + " Osoba: " + osobax2.Ime + " " + osobax2.Prezime);
            break;
        case 2:
            //var request3 = new HttpRequestMessage(HttpMethod.Post, URL);

            Osoba osobaInsert = new Osoba();
            Console.WriteLine("Ime:");
            osobaInsert.Ime = Console.ReadLine();
            Console.WriteLine("Prezime:");
            osobaInsert.Prezime = Console.ReadLine();

            osobaDAL.InsertAsync(osobaInsert);
            break;
        case 3:
            Console.WriteLine("Unesite osobu id: ");
            int osobaIdx = int.Parse(Console.ReadLine());
            Osoba osobax4 = osobaDAL.GetByIdAsync(osobaIdx).Result;

            if (osobax4 == null)
                Console.WriteLine("Nisam pronasao osobu!\n");
            else
            {
                Console.WriteLine("Id: " + osobax4.Id.ToString() + " Osoba: " + osobax4.Ime + " " + osobax4.Prezime);
                Console.WriteLine("Novo ime: ");
                osobax4.Ime = Console.ReadLine();
                Console.WriteLine("Novo prezime: ");
                osobax4.Prezime = Console.ReadLine();

                //UPDATE
                osobaDAL.UpdateAsync(osobax4);
            }

            break;
        case 4:
            Console.WriteLine("Unesite osobu id: ");
            int osobaId2 = int.Parse(Console.ReadLine());
            osobaDAL.DeleteAsync(osobaId2);
            break;
        default:
            break;
    }

    Console.WriteLine("Ponovi? 0-da, 1-ne: ");
    ponovi = int.Parse(Console.ReadLine());

} while (ponovi!=1);
