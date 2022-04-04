using ProjetoFinal.Models;

namespace ProjetoFinal.Data
{
    public static class SocialNetworkDBExtension
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SocialNetworkDBContext>();
                // Creates database if not exists
                if (context.Database.EnsureCreated())
                {
                    SocialNetworkDBInitializer.InsertData(context);
                }
            }
        }
    }
}
