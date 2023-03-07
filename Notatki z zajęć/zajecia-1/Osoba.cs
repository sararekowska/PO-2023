using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_WZ_ININ2_2
{
    internal class Osoba
    {
        private string
            imię = "Nemo",
            nazwisko,
            imięNazwisko = "Nemo"
            ;
        //geter
        //zazwyczaj nazywany wg wzorca GetX()
        //- nie przyjmuje argumentów
        //- nie modyfikuje instancji
        //- zwraca dane, być może przetworzone
        public string WeźImięNazwisko()
        {
            return $"{Imię} {Nazwisko}";
        }
        //seter
        //zazwyczaj nazywany wg wzorca SetX(value)
        //- przyjmuje wartość
        //- modyfikuje instancję na podstawie przyjętych danych
        //- nie zwraca wartości
        public void UstawImięNazwisko(string wartość)
        {
            string[] rozbicie = wartość.Split(' ');
            Imię = rozbicie[0];
            Nazwisko = rozbicie[^1]; // ^x ~ A.Length - x
        }
        //właściwość
        //grupa metod get i/lub set
        //ze wspólnym typem zwracanym/przyjmowanym
        //na zewnątrz "udaje" pole
        //podobne narzędzia są np w JS, PHP, Pythonie
        public string ImięNazwisko
        {
            get => imięNazwisko;
            set
            {
                string[] rozbicie = value.Split(' ');
                Imię = rozbicie[0];
                nazwisko = rozbicie[^1];
                SklejImięNazwisko();
            }
        }

        public string Imię {
            get => imię;
            set
            {
                string
                    pierwsza = value.Substring(0,1).ToUpper(),
                    reszta = value.Substring(1).ToLower()
                    ;
                imię = pierwsza + reszta;
                SklejImięNazwisko();
            }
        }
        public string Nazwisko {
            get => nazwisko;
            set
            {
                nazwisko = value;
                SklejImięNazwisko();
            }
        }

        //definicja przeciążonych metod
        //których lista argumentów różni się
        //tylko argumentami opcjonalnymi
        //może powodować niejednoznaczność wywołań
        //Osoba(default) vs Osoba(default,default) rozwiązuje (?) ją
        //Przeciążenia bez parametrów opcjonalnych i
        //obsługujące wszystkie domyślne przypadki
        //nie sprawiają takiego problemu
        /*public Osoba(string imięNazwisko = "Nemo")
        {
            ImięNazwisko = imięNazwisko;
        }*/
        public Osoba(
            string imię = "Nemo",
            string nazwisko = ""
            )
        {
            Imię = imię;
            Nazwisko = nazwisko;
            SklejImięNazwisko();
        }

        private void SklejImięNazwisko()
        {
            imięNazwisko = $"{imię} {nazwisko}";
        }
    }
}
