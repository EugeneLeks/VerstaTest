# VerstaTest
Для запуска проекта необходим сервер PostgreSQL
в appsettings.json указаны данные для подключения:

*"VerstaTestDbContext": "Port=5432;Database=VerstaTestDb;Host=localhost;User Id=postgres;Password=123;"*

Также для запуска необходимо провести миграцию в базу
*Add-Migration MigrationName*
*Update-Database*

P.S. Реакт использовался мною в первый раз, поэтому решения во фронте нестабильные и неуверенные :)
