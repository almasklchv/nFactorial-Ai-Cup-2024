using ExcelAI.API.StrartupConfiguration;

var startup = new StartupConfiguration();

startup.AddConfigurationJSON("Configuration/jwt.json", 
                            "Configuration/openai.json", 
                            "Configuration/fileStorage.json", 
                            "Configuration/metrics.json");

startup.ConfigureServices();
startup.ConfigureAuth();
startup.ConfigureApplicationContext();
startup.CORSAllowAll();

startup.BuildApp();

startup.ConfigureMiddleware();
//startup.ConfigureMigrationsOnStartup();
startup.AddCORSPolicy();

startup.RunApp();
