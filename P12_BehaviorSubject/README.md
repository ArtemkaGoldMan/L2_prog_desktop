Program składa się z dwóch głównych komponentów: symulatora danych (BatterySimulator) i czytnika danych (BatteryReader). Program działa w konsoli i wykorzystuje wzorzec BehaviorSubject, który umożliwia przechowywanie ostatnio odczytanej wartości i udostępnianie jej nowym subskrybentom.

Komponenty programu:

    BatterySimulator: Odpowiada za generowanie losowych odczytów poziomu baterii. Co 5 sekund zapisuje nowy poziom baterii do pliku tekstowego.
    BatteryReader: Odpowiada za monitorowanie folderu, w którym zapisywane są pliki z danymi. Gdy pojawi się nowy plik lub zostanie zmieniony istniejący, BatteryReader odczytuje ostatni poziom baterii i aktualizuje swoją wewnętrzną wartość.

Jak działa program:

    Inicjalizacja:
    Po uruchomieniu programu, tworzony jest obiekt BatterySimulator, który zaczyna generować dane co sekundę.
    Jednocześnie tworzony jest obiekt BatteryReader, który zaczyna monitorować folder z danymi.

    Generowanie danych:
    BatterySimulator losowo generuje wartość poziomu baterii w zakresie od 0% do 100% i zapisuje ją w pliku. Odczyty są zapisywane do pliku, który jest tworzony na podstawie bieżącej daty, co umożliwia gromadzenie danych przez wiele dni

Odczyt danych:

    BatteryReader używa FileSystemWatcher, aby nasłuchiwać zmiany w folderze z danymi. Kiedy pojawi się nowy plik lub zmieni się istniejący, wywoływana jest metoda OnChanged.
    W tej metodzie następuje odczyt ostatniego poziomu baterii z pliku, a następnie zaktualizowanie wewnętrznej wartości _lastBatteryReading.

BehaviorSubject:

    Nawiązanie do BehaviorSubject jest zrobione poprzez przechowywanie ostatniego odczytu baterii i udostępnianie go nowym subskrybentom.
    Gdy nowy subskrybent (np. użytkownik chcący sprawdzić aktualny poziom baterii) poprosi o ostatni odczyt, BatteryReader zwraca wartość _lastBatteryReading, co symuluje działanie BehaviorSubject.
    W każdej chwili, kiedy BatteryReader odczyta nową wartość, aktualizuje _lastBatteryReading, co pozwala nowym subskrybentom na uzyskanie aktualnych danych.

Interakcja z użytkownikiem:
    Użytkownik może wprowadzić polecenie, aby uzyskać ostatni poziom baterii. Używając polecenia s, program odczytuje ostatnią wartość z BatteryReader i wyświetla ją na konsoli.
    Użytkownik może również zakończyć działanie programu, wprowadzając q.