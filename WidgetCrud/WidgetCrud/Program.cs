using System;

namespace WidgetCrud
{
    class Program
    {
        static InMemWidgetDao dao = new InMemWidgetDao();


        static void Main(string[] args)
        {

            bool done = false;

            while( !done)
            {
                int choice = PrintMainMenu();
              switch( choice)
                {
                    case 1:
                        AddWidget();
                        break;
                    case 2:
                        RemoveWidgetById();
                        break;
                    case 3:
                        EditWidget();
                        break;
                    case 4:
                        GetWidgetById();
                        break;
                    case 5:
                        GetWidgetsByCat();
                        break;
                    case 6:
                        GetWidgetsByPage();
                        break;
                    case 7:
                        done = true;
                        break;

                }
            }
        }

        private static void RemoveWidgetById()
        {
            throw new NotImplementedException();
        }

        private static void AddWidget()
        {
            throw new NotImplementedException();
        }

        private static int PrintMainMenu()
        {
            throw new NotImplementedException();
        }
    }
}
