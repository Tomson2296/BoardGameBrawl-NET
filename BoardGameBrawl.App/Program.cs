using BoardGameBrawl.App;

WebApplication.CreateBuilder(args)
    .RegisterServices()
    .Build()
    .SetupMiddleware()
    .Run();