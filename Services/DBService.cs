using prakt8_leshukov.Models;

namespace prakt8_leshukov.Services
{
    public class DBService
    {
        private Prakt8Context context;
        private static DBService? instance;
        public Prakt8Context Context => context;
        public static DBService Instance
        {
            get
            {

                if (instance == null)
                    instance = new DBService();
                return instance;
            }
        }
        private DBService()
        {
            context = new Prakt8Context();
        }
    }
}
