using PO_WZ_ININ2_2;

/*
 1. Pobrać od użytkownika liczbę i utworzyć tablicę Osoba[]
    o tym rozmiarze, następnie w pętli w kolejnych komórkach umieścić
    kolejne nowe instancje i zapełnić danymi pobranymi od użytkownika.
    Potem w osobnej pętli wypisać informacje o osobach
 2. Dopisać pola (mogą być publiczne):
    - miejsceZamieszkania (string)
    - wiek (ushort?)
 3. Zdefiniować właściwość tylko do odczytu Format,
    zwracającą napis wg wzorca "Jan Kowalski (25 lat), Gdynia"
 4. W seterze ImięNazwisko sprawdzić, czy fraza ma więcej
    niż jeden wyraz i jeśli nie, to ustawiamy tylko imię,
    a nazwisko czyścimy
 5. W SklejImięNazwisko sprawdzić czy jest nazwisko. W wypadku
    braku ustawiamy na samo imię
 */

P11();

//konstruktor
//argumenty nazwane (również w Pythonie)
void P11()
{
    Osoba osoba = new Osoba(
        nazwisko: "Kowalski",
        imię: "Jan"
        );
    Console.WriteLine(
        osoba.Imię
        );
}

//przykład użycia konstruktora
void P10()
{
    Osoba osoba = new Osoba(
        "Julian Kowalski"
        );
    Console.WriteLine(
        osoba.ImięNazwisko
        );
}

//przykład użycia setera,
//który waliduje/koryguje dane
void P9()
{
    Osoba osoba = new Osoba()
    {
        ImięNazwisko = "jan jakiś"
    };
    Console.WriteLine(
        osoba.ImięNazwisko
        );
}

//tworzymy tablicę referencji od razu instancjując
//nowy obiekt dla każdej komórki i deklarując jego wstępne dane
//wszystko dzieje się w jednej instrukcji
void P8()
{
    Osoba[] osoby = { 
        new Osoba() { ImięNazwisko = "Adam Wiśniewski" },
        new Osoba() { ImięNazwisko = "Beata Lipowicz" },
        new Osoba() { ImięNazwisko = "Celina Jabłońska" },
        new Osoba() { ImięNazwisko = "Damian Dąbrowski" },
        new Osoba() { ImięNazwisko = "Edward Topolski" },
    };
    foreach (Osoba osoba in osoby)
        Console.WriteLine(osoba.ImięNazwisko);
}

//po instancjacji tablicy powinniśmy w pętli
//dla każdej komórki instancjować nową osobę
void P7()
{
    Osoba[] osoby = new Osoba[3];
    for(int i = 0; i < osoby.Length; i++)
        osoby[i] = new Osoba();
    foreach (Osoba osoba in osoby)
        Console.WriteLine(osoba.Imię);
}

//przykład wypluwa wyjątek null-owej referencji
//tworzenie tablicy o określonym rozmiarze dla typu referencyjnego
//daje nam puste referencje (null), a nie "świeże" instancje
void P6()
{
    Osoba[] osoby = new Osoba[3];
    foreach(Osoba osoba in osoby)
        Console.WriteLine(osoba.Imię);
}

//użycie właściwości
//przypisanie do właściwości jest możliwe przy deklaracji
void P5()
{
    Osoba osoba = new Osoba()
    {
        ImięNazwisko = "Damian Dawid Dębowski"
    };
    Console.WriteLine(
        osoba.ImięNazwisko
        );
}

//użycie metody setera dla danych do przetworzenia
void P4()
{
    Osoba osoba = new Osoba();
    osoba.UstawImięNazwisko("Beata Maria Lipowicz");
    Console.WriteLine(
        osoba.WeźImięNazwisko()
        );
}
//użycie metody getera dla danych przetworzonych
void P3()
{
    Osoba osoba = new Osoba()
    {
        Imię = "Adam",
        Nazwisko = "Dąbrowski"
    };
    Console.WriteLine(
        osoba.WeźImięNazwisko()
        );
}

//Specyficzne w C#:
//skrótowe new(), od .NET 5.0
//inicjalizator (deklarator?)
void P2()
{
    Osoba osoba = new()
    {
        Imię = "Jan",
        Nazwisko = "Kowalski"
    };
    Console.WriteLine(
        $"{osoba.Imię} {osoba.Nazwisko}"
        );
}

//podstawy, użycie pól, instancjacja
//różnica między referencją a instancją
void P1()
{
    Osoba
        o1,
        o2,
        o3
        ;
    
    o1 = new Osoba();
    o1.Nazwisko = "Jakiś";

    o2 = new Osoba();
    o2.Imię = o1.Imię;
    o2.Nazwisko = o1.Nazwisko;

    o3 = o1;

    o1.Imię = "Jan";
    o2.Imię = "Julian";
    o3.Imię = "Jerzy";

    Console.WriteLine(
        $"Osoba nazywa się {o1.Imię} {o1.Nazwisko}."
        );
    Console.WriteLine(
        $"Osoba nazywa się {o2.Imię} {o2.Nazwisko}."
        );
    Console.WriteLine(
        $"Osoba nazywa się {o3.Imię} {o3.Nazwisko}."
        );

    //o1 i o3 referują na tą samą instancję
    //o2 referuje na osobną instancję, tzw klon
}