using System;
using System.Collections.Generic;

namespace RGame {
    public class TyrellDialog : Dialog {
        private const string CONTROL = "Jestem na rutynowej kontroli.. AllSafe ciągle je przeprowadza..";
        private const string FINANCIALS = "Cięcia budżetowe.. redukcja etatów.";
        private const string TAKE_CARD = "Próbuje niepostrzeżenie zabrać kartę";
        private const string LET_HIM_GO = "Czekam aż Tyrell odejdzie";
        private const string NEXT = "[dalej]";
        private const string END = "[zakończ]";
        private const string SILENCE = "[milcz]";
        private const string FAILED = "[Niestety.. przegrałeś!]";

        private Menu menu = new Menu();

        private bool mounted = false;
        private int state = 0;

        public TyrellDialog( bool mounted ) {
            this.mounted = mounted;

            menu.AddOption( CONTROL );
            menu.AddOption( SILENCE );
        }

        public void Draw() {
            Console.Write(Speakers.TYRELL);
            if ( state == 0 ) {
                Console.WriteLine( "Eliot? A co Ty tu robisz? *podchodzi i ściska Ci rękę*" );
            } else if ( state == 1 ) {
                if ( mounted ) {
                    Console.WriteLine( "I dlatego wysłali programistę?" );
                } else {
                    Console.WriteLine( "A co to? *spogląda za Twoje plecy i patrzy na Ciebie z przerażeniem* Ochrona.. ochrona!!! *do łazienki wbiegają uzbrojeni ochroniarze i natychmiast przygniatają Cię do ziemi*" );
                }
            } else if ( state == 2 ) {
                Console.WriteLine( "Ciekawy zbieg okoliczności.. obaj działamy dziś w terenie, a mi jak zawsze miło Cię spotkać. Opowiem Ci historię.. przeglądałem ostatnio zainfekowany serwer ECorp *EvilCorp* i znalazłem coś ciekawego.." );
            } else if ( state == 3 ) {
                Console.WriteLine( "Wiem, że to Ty wrobiłeś Colbyego.. spokojnie - nie wydam Cię. Fascynował mnie tylko powód, dla którego to zrobiłeś.." );
            } else if ( state == 4 ) {
                Console.WriteLine( "Dowiedziałem się, że Twój ojciec u nas pracował.. zmarł na białaczkę jak kilka innych osób.. mimo zbiorowego pozwu rodzin nie udowodniono oczywistego związku z ECorp *EvilCorp* ..a więc zemsta?" );
            } else if ( state == 5 ) {
                Console.WriteLine( "Prymitywne emocje.. rozczarowałem się Tobą, ale nie przejmuj się ostatecznie wszyscy jesteśmy ludźmi.. poza mną oczywiści.. żartowałem. Trzymaj się i miłego długie powrotu do domu, ja tymczasem wracam do swojego biura.. śmigłowcem.." );
            } else if ( state == 6 ) {
                Console.WriteLine( "*odwraca się i odchodzi, z kieszeni wystaje mu jakaś biała karta.. co robisz?*" );
            } else if ( state == 7 ) {
                Console.WriteLine( "*udało się - Tyrell nic nie zauważył*" );
            }
            Console.WriteLine();

            menu.Draw();
        }

        public bool HandleKeyPress( char choice ) {
            if ( menu.HandleKeyPress( choice) ) {
                return true;
            } else if ( choice == ( char ) 32 ) {
                if ( menu.GetCurrent() == CONTROL ) {
                    state = 1;
                    if ( mounted ) {
                        menu = new Menu( new List<string>() { FINANCIALS, SILENCE } );
                    } else {
                        menu = new Menu( new List<string>() { FAILED } );
                    }
                } else if ( menu.GetCurrent() == FAILED ) {
                    GameController.Instance().GameOver();
                } else if ( menu.GetCurrent() == FINANCIALS || ( state == 0 && menu.GetCurrent() == SILENCE ) || ( state == 1 && menu.GetCurrent() == SILENCE ) ) {
                    state = 2;
                    menu = new Menu( new List<string>() { NEXT });
                } else if ( menu.GetCurrent() == NEXT ) {
                    state++;
                    if ( state == 6 ) {
                        menu = new Menu( new List<string>() { LET_HIM_GO, TAKE_CARD } );
                        MainQuest.OnTyrellLeft();
                    }
                } else if ( menu.GetCurrent() == LET_HIM_GO ) {
                    GameController.Instance().SetDialog( null );
                } else if ( menu.GetCurrent() == TAKE_CARD ) {
                    state = 7;
                    menu = new Menu( new List<string>() { END } );
                    GameController.Instance().GetEquipment().Add( ItemsRepository.Instance().Get( "magnetic_card" ) );
                } else if ( menu.GetCurrent() == END ) {
                    GameController.Instance().SetDialog( null );
                }

                return true;
            }

            return false;
        }
    }
}
