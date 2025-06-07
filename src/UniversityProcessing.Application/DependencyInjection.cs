namespace UniversityProcessing.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // MediatR + автоматическая регистрация обработчиков
        services.AddMediatR(
            cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Автоматическая регистрация валидаторов
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Регистрация поведения валидации
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Регистрация сервисов приложения
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}
