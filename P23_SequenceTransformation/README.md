Aplikacja służy do zarządzania kontaktami. Aplikacja działa w trybie offline, przechowując dane w plikach tekstowych.

Model danych (Models/Contact.cs):

    Klasa Contact reprezentuje pojedynczy kontakt. Posiada atrybuty takie jak:
    Id: unikalny identyfikator kontaktu.
    FirstName: imię kontaktu.
    LastName: nazwisko kontaktu.
    PhoneNumber: numer telefonu.
    Email: adres e-mail.

Logika zarządzania kontaktami (Services/ContactManager.cs):

    Klasa ContactManager zarządza listą kontaktów, w tym:
    Ładowanie kontaktów: Metoda LoadContacts() wczytuje dane z pliku tekstowego i tworzy listę kontaktów.
    Zapisywanie kontaktów: Metoda SaveContacts() zapisuje aktualny stan listy kontaktów do pliku.
    Dodawanie, aktualizacja i usuwanie kontaktów: Metody AddContact(), UpdateContact() i DeleteContact() umożliwiają użytkownikowi zarządzanie kontaktami.
    Wyświetlanie kontaktów: Metoda ListContacts() wyświetla wszystkie dostępne kontakty w konsoli.

Interfejs użytkownika (Program.cs):

    Główna klasa Program zawiera pętlę, która prezentuje użytkownikowi menu z opcjami do zarządzania kontaktami.
    Użytkownik może dodawać nowe kontakty, aktualizować istniejące, usuwać je oraz przeglądać listę kontaktów.

Sequence Transformation:

Sequence Transformation to wzorzec projektowy, który polega na przekształceniu danych lub obiektów w sekwencji, aby można je było łatwiej przetwarzać, zmieniać lub prezentować.

    Każdy kontakt jest reprezentowany jako obiekt klasy Contact, co pozwala na łatwe manipulowanie danymi. Umożliwia to korzystanie z właściwości i metod obiektów, co jest bardziej czytelne i łatwiejsze w utrzymaniu niż operowanie na surowych danych tekstowych.

    Klasa ContactManager przechowuje kontakty w liście (List<Contact>), co pozwala na dynamiczne dodawanie, usuwanie i modyfikowanie kontaktów.
    Operacje takie jak dodawanie nowych kontaktów czy usuwanie istniejących kontaktów są przykładami transformacji sekwencyjnej danych, gdzie stan kolekcji jest modyfikowany na podstawie akcji użytkownika.

    Wzorzec ten również odnosi się do sposobu, w jaki aplikacja zarządza stanem danych. Każda operacja, taka jak dodanie lub aktualizacja kontaktu, skutkuje transformacją stanu aplikacji (np. dodawanie kontaktu do listy oraz zapisywanie zmienionego stanu do pliku).