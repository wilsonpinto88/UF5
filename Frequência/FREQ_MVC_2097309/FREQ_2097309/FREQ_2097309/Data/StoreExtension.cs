using FREQ_2097309.Models;

namespace FREQ_2097309.Data
{
    public static class StoreExtension
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<StoreContext>();
                    // Creates the database if not exists
                    if (context.Database.EnsureCreated())
                    {
                        StoreDBInitializer.InsertData(context);
                    }
                }
            }
        }
    }
}
