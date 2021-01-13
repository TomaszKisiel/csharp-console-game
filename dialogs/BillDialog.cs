using System;
using System.Collections.Generic;

namespace RGame {
    public class BillDialog : Dialog {
        private const string ASK = "Bill..";
        private const string ESCAPE = "[zwolnij i pozwól oddalić się Billowi]";
        private const string NEXT = "[dalej]";
        private const string LOOK_ON_BILL = "[spójrz na Billa]";
        private const string DESTROY_BILL = "[zniszcz Billa psychicznie]";
        private const string END_TOUR = "Czy możemy już skończyć wycieczkę?";
        private const string FOLLOW_BILL = "[idę za Billem]";
        private const string YES = "Tak";
        private const string NOT_YET = "Jeszcze nie..";
        private const string SAM_ESMAIL = "Sam Esmail.";
        private const string SAM_SEPIOL = "Sam Sepiol.";
        private const string LIAM_SEPIOL = "Liam Sepiol.";
        private const string VISIT = "Chodzi o zwiedzanie.";
        private const string NOTHING = "W niczym, tylko się rozglądam.";
        private const string LEAVE = "Odchodzę";
        private const string BREAK_IN = "Zostawiam Billa i odchodzę";

        private bool CheatAttemptPossible;
        private int state = 0;

        private Menu menu = new Menu();

        public BillDialog( bool CheatAttemptPossible ) {
            this.CheatAttemptPossible = CheatAttemptPossible;

            if ( CheatAttemptPossible == true ) {
                menu.AddOption( VISIT );
            }

            menu.AddOption( NOTHING );
        }

        public void Draw() {
            if ( state == 0 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "Dzień dobry. W czym mogę pomóc?" );
            } else if ( state == 1 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "Czy mogę prosić Pana nazwisko?" );
            } else if ( state == 2 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "Aaa.. tak. Mam Pana wpisanego. W zasadzie to nasza pora, czy możemy już zacząć zwiedzanie?" );
            } else if ( state == 3 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "*Bill przykłada kartę magnetyczną do skanera i przepuszcza Cię przez bramkę*" );
            } else if ( state == 4 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "Cały kompleks Steel Mountain podzielony jest na wiele różnych budynków, a każdy z nich jest dodatkowo podzielony na różne poziomy. Przejścia między poszczególnymi poziomami są chronione przez licznych ochroniarzy oraz drzwi z zamkami magnetycznymi, aby przez nie przejść trzeba posiadać odpowiednią kartę." );
            } else if ( state == 5 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "Zatrudniamy setki osób, dla których potrzeb posiadamy wewnętrzne centrum gastronomiczne, chill room'y i różne drobne sklepiki. Obiekt posiada również sypialnie, w których mogą odpocząć pracownicy jeżeli nie chcą wracać do domu lub są potrzebni przez dłuższy czas w pracy, na przykład ze względu na nagłą potrzebę migracji danych itp." );
            } else if ( state == 5 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "Ze względów bezpieczeństwa posiadamy tu sektor medyczny, a nawet wewnętrzne drogi przeciwpożarowe i prywatną straż pożarną na utrzymaniu.. to wszystko znajduje się tu.. w środku Steel Mountain.. *słyszysz szmer w słuchawce*" );
            } else if ( state == 6 ) {
                Console.Write( Speakers.MR_ROBOT );
                Console.WriteLine( "Ziemia do Eliota.. nie mamy czasu na monologi Billa. Pozbądź się przewodnika i bierz się do roboty.." );
            } else if ( state == 7 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "..jak do tej pory, mimo licznych prób, nikomu jeszcze nie udało się włamać do Steel Mountain, ani nawet do naszego systemu. Wszystko dzięki restrykcyjnym zasadom, które obejmują każdego pracownika.." );
            } else if ( state == 20 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "Tak?" );
            } else if ( state == 21 ) {
                Console.Write( Speakers.ELIOT );
                Console.WriteLine( "Pomyśl o tym.. *Bill patrzy z niezrozumieniem* ..pomyśl o tym Bill.. gdybyś umarł, czy kogoś by to obeszło? Czy naprawdę ktoś by się przeją? Tak.. może płakaliby przez dzień, ale bądźmy szczerzy. Każdy miałby to w dupie. Nikogo by to nie obchodziło. Te pare osób, które czułyby się zobowiązane pójść na twój pogrzeb, prawdopodobnie byłoby zirytowane i wyszłoby tak wcześnie, jak to możliwe. To jest właśnie to kim jesteś. To jest to czym jesteś. Jesteś niczym, dla wszystkich. Pomyśl o tym, Bill, bo jeśli to zrobisz, jeśli sobie na to pozwolisz.. Będziesz wiedział, że mówię ci prawdę. Więc zamiast marnować mój czas, zadzwoń po kogoś, kto coś znaczy, bo Ty Bill.. nic nie znaczysz!" );
            } else if ( state == 100 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "Przykro mi.. nie mam nikogo takiego w harmonogramie. Proszę porozmawiać z obsługą może uda się Panu zapisać na inny termin." );
            } else if ( state == 101 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "*Bill odwraca się* proszę nie zostawać z tyłu, w tych korytarzach naprawdę można się zgubić.. hmm.. chyba widzieliśmy już wszystko. Odprowadzę Pana do lobby." );
            } else if ( state == 102 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "Oczywiście.. w zasadzie to widzieliśmy już chyba wszystko co najważniejsze. Odprowadzę Pana do lobby." );
            } else if ( state == 103 ) {
                Console.Write( Speakers.BILL );
                Console.WriteLine( "*Bill ma łzy w oczach.. siada załamany na jednej z ławek i zakrywa twarz dłońmi* .. co robisz?" );
            }
            Console.WriteLine();


            menu.Draw();
        }

        public bool HandleKeyPress( char choice ) {
            if ( menu.HandleKeyPress( choice) ) {
                return true;
            } else if ( choice == ( char ) 32 ) {
                if ( menu.GetCurrent() == LEAVE || menu.GetCurrent() == NOTHING || menu.GetCurrent() == NOT_YET || menu.GetCurrent() == FOLLOW_BILL ) {
                    state = 0;
                    GameController.Instance().SetDialog( null );
                } else if ( menu.GetCurrent() == VISIT ) {
                    menu = new Menu( new List<string>() { LIAM_SEPIOL, SAM_SEPIOL, SAM_ESMAIL } );
                    state++;
                } else if ( menu.GetCurrent() == SAM_SEPIOL ) {
                    menu = new Menu( new List<string>() { YES, NOT_YET } );
                    state++;
                } else if ( menu.GetCurrent() == SAM_ESMAIL || menu.GetCurrent() == LIAM_SEPIOL ) {
                    ( (Bill) InteractablesRepository.Instance().Get("bill")).CheatAttemptPossible = false;
                    menu = new Menu( new List<string>() { LEAVE } );
                    state = 100;
                    MainQuest.OnBillFailed();
                } else if ( menu.GetCurrent() == YES ) {
                    ( (Bill) InteractablesRepository.Instance().Get("bill")).CheatAttemptPossible = false;
                    menu = new Menu( new List<string>() { NEXT } );
                    state++;
                } else if ( menu.GetCurrent() == NEXT ) {
                    state++;
                    if ( state == 7 ) {
                        menu = new Menu( new List<string>() { ASK, ESCAPE } );
                    }
                } else if ( menu.GetCurrent() == ASK ) {
                    menu = new Menu( new List<string>() { END_TOUR, DESTROY_BILL } );
                    state = 20;
                } else if ( menu.GetCurrent() == ESCAPE ) {
                    menu = new Menu( new List<string>() { FOLLOW_BILL } );
                    state = 101;
                    MainQuest.OnBillFailed();
                } else if ( menu.GetCurrent() == END_TOUR ) {
                    menu = new Menu( new List<string>() { FOLLOW_BILL } );
                    state = 102;
                    MainQuest.OnBillFailed();
                } else if ( menu.GetCurrent() == DESTROY_BILL ) {
                    menu = new Menu( new List<string>() { LOOK_ON_BILL } );
                    state++;
                } else if ( menu.GetCurrent() == LOOK_ON_BILL ) {
                    menu = new Menu( new List<string>() { BREAK_IN } );
                    state = 103;
                } else if ( menu.GetCurrent() == BREAK_IN ) {
                    MainQuest.OnBillDestroyed();
                    GameController.Instance().SetDialog( null );
                }

                return true;
            }

            return false;
        }
    }
}
